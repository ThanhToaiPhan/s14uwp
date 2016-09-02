using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using w10app.Models;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;

namespace w10app
{
    class Service
    {
        private static readonly HashSet<char> _base64Characters = new HashSet<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V',
            'W', 'X', 'Y', 'Z', 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r',
            's', 't', 'u', 'v', 'w', 'x', 'y', 'z', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '/', '='
        };

        public String URL = "http://wsdl.s14.com.vn/Service.asmx";
        public String SOAPAction = "http://indolink.vn/RequestTransaction";
        public XNamespace XMLNamespace = "http://indolink.vn/";

        public String CreateRequest(String Table,
                                    String Field,
                                    String Condition,
                                    String SoftCall,
                                    String Version)
        {
            return @"<?xml version='1.0' encoding='utf-8'?><soap:Envelope xmlns:xsi='http://www.w3.org/2001/XMLSchema-instance' xmlns:xsd='http://www.w3.org/2001/XMLSchema' xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/'><soap:Body><RequestTransaction xmlns='http://indolink.vn/'><Table>" + Table + "</Table><Field>" + Field + "</Field><Condition>" + Condition + "</Condition><SoftCall>" + SoftCall + "</SoftCall><Version>" + Version + "</Version></RequestTransaction></soap:Body></soap:Envelope>";
        }

        public List<String> DecodeSoapResponse(String SoapResponse)
        {
            List<String> Data = new List<String>();
            XDocument XMLResponse = XDocument.Parse(SoapResponse);
            String StringResult = XMLResponse.Descendants(XMLNamespace + "RequestTransactionResult").FirstOrDefault().Value;
            String[] Separator1 = { "|" };
            String[] ListResult = StringResult.Split(Separator1, StringSplitOptions.None);
            Data.Add(ListResult[0]);
            Data.Add(ListResult[1]);
            Byte[] ByteResult = Convert.FromBase64String(ListResult[2]);
            StringResult = Encoding.UTF8.GetString(ByteResult);
            String[] Separator2 = { "<row>" };
            ListResult = StringResult.Split(Separator2, StringSplitOptions.None);
            for (int i = 0; i < ListResult.Count(); i++)
            {
                Data.Add(ListResult[i]);
            }
            return Data;
        }

        public String[] DecodeBase64(String Data)
        {
            Byte[] ByteResult = Convert.FromBase64String(Data);
            String StringResult = Encoding.UTF8.GetString(ByteResult);
            String[] Separator = { "<row>" };
            String[] ListResult = StringResult.Split(Separator, StringSplitOptions.None);
            return ListResult;
        }
    
        public static bool IsBase64String(String String)
        {
            if (string.IsNullOrEmpty(String))
            {
                return false;
            }
            else if (String.Any(c => !_base64Characters.Contains(c)))
            {
                return false;
            }
            try
            {
                Convert.FromBase64String(String);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public void ConvertDataToButton(Button Button, String Data)
        {
            String[] ListData = SplitData(Data);
            DependencyObject Grid = VisualTreeHelper.GetChild(Button, 0);
            DependencyObject Presenter = VisualTreeHelper.GetChild(Grid, 0);
            DependencyObject StackPanel = VisualTreeHelper.GetChild(Presenter, 0);
            Image Image = VisualTreeHelper.GetChild(StackPanel, 0) as Image;
            TextBlock TextBlock = VisualTreeHelper.GetChild(StackPanel, 1) as TextBlock;
            Uri ImageUri = new Uri(ListData[1]);
            Image.Source = new BitmapImage(ImageUri);
            TextBlock.Text = ListData[0];
        }

        public async void ShowMessageDialogServerError()
        {
            MessageDialog Dialog = new MessageDialog("Lỗi truy xuất máy chủ!");
            Dialog.Commands.Add(new UICommand("Đóng", null, 2));
            await Dialog.ShowAsync();
        }

        public String[] SplitData(String Data)
        {
            String[] Separator = { "|" };
            String[] ListData = Data.Split(Separator, StringSplitOptions.None);
            return ListData;
        }

        public Movie ConvertDataToMovie(String Data)
        {
            String[] ListData = SplitData(Data);
            Movie Movie = new Movie();
            Movie.Id = ListData[0];
            Movie.Image = ListData[1];
            Movie.Name = ListData[2] + " (" + ListData[3] + ")";
            Movie.Rating = Double.Parse(ListData[4]);
            return Movie;
        }

        public void ConvertDataToTextBlock(TextBlock TextBlock, List<String> Data)
        {
            String[] ListData = SplitData(Data[2]);
            String Result = ListData[1];
            for (int i = 3; i < Data.Count; i++)
            {
                ListData = SplitData(Data[i]);
                Result += ", " + ListData[1];
            }
            TextBlock.Text = Result;
        }

        public User ConvertDataToUser(String Data)
        {
            String[] ListData = SplitData(Data);
            User User = new User();
            User.Username = ListData[2];
            User.Image = ListData[5];
            return User;
        }

        public String ConvertDataToLink(String Data)
        {
            String[] ListData = SplitData(Data);
            return ListData[2];
        }

        public Menu ConvertDataToMenu(String Data)
        {
            String[] ListData = SplitData(Data);
            Menu Menu = new Menu();
            Menu.Name = ListData[0];
            Menu.Icon = ListData[1];
            return Menu;
        }

        public Episode ConvertDataToEpisode(String Data)
        {
            String[] ListData = SplitData(Data);
            Episode Episode = new Episode();
            Episode.Number = ListData[0];
            Episode.Link = ListData[1];
            return Episode;
        }

        public Person ConvertDataToPerson(String Data)
        {
            String[] ListData = SplitData(Data);
            Person Person = new Person();
            Person.Image = ListData[0];
            Person.Name = ListData[1];
            return Person;
        }
    }
}
