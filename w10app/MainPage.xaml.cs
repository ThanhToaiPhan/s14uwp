using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using w10app.Models;
using System.Net;
using Windows.UI.Popups;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text;
using System.Net.Http;
using System.Xml.Linq;
using Windows.UI.Xaml.Media.Imaging;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace w10app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        Service Service = new Service();

        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            // connect to service
            HttpClient MyHttpClient = new HttpClient();
            MyHttpClient.DefaultRequestHeaders.Add("SOAPAction", Service.SOAPAction);

            // request for menu
            StringContent Content = new StringContent(Service.CreateRequest("Movie", "ID", "IDCategory|15", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            HttpResponseMessage Response = await MyHttpClient.PostAsync(Service.URL, Content);
            String SoapResponse = await Response.Content.ReadAsStringAsync();
            List<String> Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Menu> ListMenu = new List<Menu>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Menu Menu = Service.ConvertDataToMenu(Data[i]);
                    ListMenu.Add(Menu);
                }
                MenuListView.ItemsSource = ListMenu;
            }

            // request for movie in banner
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,ImageBanner,NameViet,Quality,Point", "Banner|1", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Movie Movie = Service.ConvertDataToMovie(Data[i]);
                    ListMovie.Add(Movie);
                }
                BannerFlipView.ItemsSource = ListMovie;
            }

            // request for s14 movie
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,NameViet,Quality,Point", "PointIMDB|DESC,Limit|6", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Movie Movie = Service.ConvertDataToMovie(Data[i]);
                    ListMovie.Add(Movie);
                }
                Movies14GridView.ItemsSource = ListMovie;
            }

            // request for new movie series
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,NameViet,Quality,Point", "IDCategory|16,Year|DESC,Limit|6", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Movie Movie = Service.ConvertDataToMovie(Data[i]);
                    ListMovie.Add(Movie);
                }
                MovieSeriesNewGridView.ItemsSource = ListMovie;
            }

            // request for new movie
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,NameViet,Quality,Point", "IDCategory|15,Year|DESC,Limit|6", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Movie Movie = Service.ConvertDataToMovie(Data[i]);
                    ListMovie.Add(Movie);
                }
                MovieNewGridView.ItemsSource = ListMovie;
            }

            // request for hot movie series
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,NameViet,Quality,Point", "IDCategory|16,NumberView|DESC,Limit|6", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Movie Movie = Service.ConvertDataToMovie(Data[i]);
                    ListMovie.Add(Movie);
                }
                MovieSeriesHotGridView.ItemsSource = ListMovie;
            }

            // request for hot movie
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,NameViet,Quality,Point", "IDCategory|15,NumberView|DESC,Limit|6", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<Movie> ListMovie = new List<Movie>();
                for (int i = 2; i < Data.Count; i++)
                {
                    Movie Movie = Service.ConvertDataToMovie(Data[i]);
                    ListMovie.Add(Movie);
                }
                MovieHotGridView.ItemsSource = ListMovie;
            }
        }

        private void HomeClick(object sender, RoutedEventArgs e)
        {
            PageContent.Navigate(typeof(MainPage));
        }

        private void MovieClick(object sender, RoutedEventArgs e)
        {
            PageContent.Navigate(typeof(MoviePage));
        }

        private void GameShowClick(object sender, RoutedEventArgs e)
        {

        }

        private void ClipClick(object sender, RoutedEventArgs e)
        {

        }

        private void ForumClick(object sender, RoutedEventArgs e)
        {

        }

        private void RatingClick(object sender, RoutedEventArgs e)
        {

        }

        private void TermClick(object sender, RoutedEventArgs e)
        {

        }

        public void DetailMovieClick(object sender, ItemClickEventArgs e)
        {
            Movie MovieClicked = (Movie)e.ClickedItem;
            PageContent.Navigate(typeof(DetailMoviePage), MovieClicked.Id);
        }

        private async void RatingTapped(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog Dialog = new MessageDialog("Cảm ơn đánh giá của bạn!");
            Dialog.Commands.Add(new UICommand("Đóng", null, 2));
            await Dialog.ShowAsync();
            //Callisto.Controls.Rating RatingBar = (Callisto.Controls.Rating)(FrameworkElement)sender;
            //Double RatingPoint = RatingBar.Value;
            //User CurrentUser = ((App)Application.Current).CurrentUser;
            //if (CurrentUser == null)
            //{
            //    MessageDialog Dialog = new MessageDialog("Bạn cần đăng nhập trước!");
            //    Dialog.Commands.Add(new UICommand("Đăng nhập", null, 1));
            //    Dialog.Commands.Add(new UICommand("Hủy", null, 2));
            //    IUICommand Result = await Dialog.ShowAsync();
            //    if ((int)Result.Id == 1)
            //    {
            //        List<Object> ListParams = new List<Object>();
            //        ListParams[0] = "MainPage";
            //        PageContent.Navigate(typeof(LoginPage), ListParams);
            //    }
            //}
            //else
            //{
            //    PhimS14Content PhimS14ContentRated = (PhimS14Content)((FrameworkElement)sender).DataContext;
            //    List<Rating> ListRating = new List<Rating>();
            //    Double TotalPoint = 0;
            //    int TotalUser = 0;
            //    Boolean Matched = false;
            //    foreach (Rating Rating in ((App)Application.Current).ListRating)
            //    {
            //        if (Rating.PhimS14Content.Id == PhimS14ContentRated.Id)
            //        {
            //            TotalUser += 1;
            //            if (Rating.User.Id == CurrentUser.Id)
            //            {
            //                Rating.Point = RatingBar.Value;
            //                Matched = true;
            //            }
            //            TotalPoint += Rating.Point;
            //        }
            //    }
            //    if (Matched)
            //    {
            //        PhimS14ContentRated.Rating = Math.Round(TotalPoint / TotalUser, 1);
            //    }
            //    else
            //    {
            //        Rating Rating = new Rating() { User = CurrentUser, PhimS14Content = PhimS14ContentRated, Point = RatingBar.Value };
            //        ((App)Application.Current).ListRating.Add(Rating);
            //        TotalPoint += Rating.Point;
            //        TotalUser += 1;
            //        PhimS14ContentRated.Rating = Math.Round(TotalPoint / TotalUser, 1);
            //    }
            //    MessageDialog Dialog = new MessageDialog("Cảm ơn đánh giá của bạn!");
            //    Dialog.Commands.Add(new UICommand("Đóng", null, 2));
            //    await Dialog.ShowAsync();
            //    PageContent.Navigate(typeof(MainPage));
        }

        private void HamburgerClick(object sender, RoutedEventArgs e)
        {
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void MenuSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Menu Menu = e.AddedItems.First() as Menu;
            switch (Menu.Name)
            { 
                case "Trang chủ":
                    PageContent.Navigate(typeof(MainPage));
                    break;
                case "Phim":
                    PageContent.Navigate(typeof(MoviePage));
                    break;
            }
            MenuSplitView.IsPaneOpen = !MenuSplitView.IsPaneOpen;
        }

        private void SearchClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
