using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using w10app.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace w10app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MoviePage : Page
    {
        Service Service = new Service();

        public MoviePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // connect to service
            HttpClient MyHttpClient = new HttpClient();
            MyHttpClient.DefaultRequestHeaders.Add("SOAPAction", Service.SOAPAction);

            // request for movie
            StringContent Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,NameViet", "", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            HttpResponseMessage Response = await MyHttpClient.PostAsync(Service.URL, Content);
            String SoapResponse = await Response.Content.ReadAsStringAsync();
            List<String> Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    String[] ListData = Service.SplitData(Data[i]);
                    Movie Movie = new Movie{
                        Id = ListData[0],
                        Image = ListData[1],
                        Name = ListData[2]
                    };
                    ListMovie.Add(Movie);
                }
                MovieGridView.ItemsSource = ListMovie;
            }
        }

        private void DetailMovieClick(object sender, ItemClickEventArgs e)
        {
            Movie MovieClicked = (Movie)e.ClickedItem;
            PageContent.Navigate(typeof(DetailMoviePage), MovieClicked);
        }
    }
}
