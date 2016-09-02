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
using Windows.UI.Xaml.Media.Imaging;
using w10app.Models;
using Windows.UI.Popups;
using System.Net.Http;
using System.Text;
using Windows.UI.Xaml.Documents;
using Windows.UI;
using System.Globalization;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace w10app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DetailMoviePage : Page
    {
        Movie CurrentMovie = new Movie();
        String CurrentMovieId;
        String Critic;
        String Value;
        int CurrentEpisode = 0;
        List<Episode> ListEpisode = new List<Episode>();
        List<Comment> ListComment = new List<Comment>();
        List<Comment> ListCommentResult = new List<Comment>();
        Service Service = new Service();
        public static Random Random = new Random();
        public DetailMoviePage()
        {
            this.InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            CurrentMovieId = (String)e.Parameter;
            // connect to service
            HttpClient MyHttpClient = new HttpClient();
            MyHttpClient.DefaultRequestHeaders.Add("SOAPAction", Service.SOAPAction);

            // request for menu
            StringContent Content = new StringContent(Service.CreateRequest("Menu", "Name,Icon", "", "Windows Phone", ""), Encoding.UTF8, "text/xml");
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

            // request for movie
            Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,ImageBanner,NameViet,Quality,Point,IDCategory,IDCountry,Year,NumberView,Content", "IDMovie|" + CurrentMovieId, "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                String[] ListData = Service.SplitData(Data[2]);
                CurrentMovieId = ListData[0];
                MovieImageImageBrush.ImageSource = new BitmapImage(new Uri(ListData[1]));
                MovieNameTextBlock.Text = ListData[2] + " (" + ListData[3] + ")";
                MovieRatingTextBlock.Text = ListData[4];
                MovieRatingCallisto.Value = Double.Parse(ListData[4]);
                MovieTypeTextBlock.Text = ListData[5];
                if (!ListData[5].Contains("Phim bộ"))
                {
                    EpisodeGridView.Visibility = (Visibility)1;
                }
                MovieCountryTextBlock.Text = ListData[6];
                MovieYearTextBlock.Text = ListData[7];
                MovieNumberViewTextBlock.Text = ListData[8];
                MovieContentTextBlock.Text = ListData[9];
            }

            // request for series
            Content = new StringContent(Service.CreateRequest("MovieSeries", "Episode,Link", "IDMovie|" + CurrentMovieId, "Windows Phone", ""), Encoding.UTF8, "text/xml");
            Response = await MyHttpClient.PostAsync(Service.URL, Content);
            SoapResponse = await Response.Content.ReadAsStringAsync();
            Data = Service.DecodeSoapResponse(SoapResponse);
            if (Data.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                for (int i = 2; i < Data.Count; i++)
                {
                    Episode Episode = Service.ConvertDataToEpisode(Data[i]);
                    ListEpisode.Add(Episode);
                }
                EpisodeGridView.ItemsSource = ListEpisode;
            }
        }

        public void ShowComment(ListView ListView, int NumberComment, List<Comment> ListComment, List<Comment> ListCommentResult)
        {
            int Count = ListComment.Count;
            for (int i = ListComment.Count; i < Count + NumberComment; i++)
            {
                if (i < ListCommentResult.Count)
                {
                    ListComment.Add(ListCommentResult[i]);
                }
            }
            ListView.ItemsSource = null;
            ListView.ItemsSource = ListComment;
        }


        public async void CreateListComment(List<String> Data)
        {
            List<Comment> ListCommentTemp = new List<Comment>();
            List<Comment> ListComment = new List<Comment>();
            String ListUserID = "";
            for (int i = 2; i < Data.Count; i++)
            {
                String[] ListData = Service.SplitData(Data[i]);
                Comment Comment = new Comment();
                Comment.Id = int.Parse(ListData[0]);
                Comment.IdParent = int.Parse(ListData[5]);
                Comment.Date = DateTime.Parse(ListData[1]);
                Comment.Content = ListData[3];
                Comment.ListSubComment = new List<Comment>();
                ListUserID += ListData[2] + ",";
                ListCommentTemp.Add(Comment);
            }
            // connect to service
            HttpClient MyHttpClient = new HttpClient();
            MyHttpClient.DefaultRequestHeaders.Add("SOAPAction", Service.SOAPAction);

            // request for user
            StringContent Content = new StringContent(Service.CreateRequest(ListUserID, "ID", "User", "Windows Phone", ""), Encoding.UTF8, "text/xml");
            HttpResponseMessage Response = await MyHttpClient.PostAsync(Service.URL, Content);
            String SoapResponse = await Response.Content.ReadAsStringAsync();
            List<String> Data2 = Service.DecodeSoapResponse(SoapResponse);
            if (Data2.Count <= 2)
            {
                Service.ShowMessageDialogServerError();
            }
            else
            {
                List<User> ListUser = new List<User>();
                for (int i = 2; i < Data2.Count; i++)
                {
                    User User = Service.ConvertDataToUser(Data2[i]);
                    ListUser.Add(User);
                }
                for (int i = 0; i < ListCommentTemp.Count; i++)
                {
                    ListCommentTemp[i].UserImage = ListUser[i].Image;
                    ListCommentTemp[i].UserName = ListUser[i].Username;
                }
                for (int i = 0; i < ListCommentTemp.Count; i++)
                {
                    for (int j = 0; j < ListCommentTemp.Count; j++)
                    {
                        if (ListCommentTemp[j].IdParent == ListCommentTemp[i].Id)
                        {
                            ListCommentTemp[i].ListSubComment.Add(ListCommentTemp[j]);
                        }
                    }
                    if (ListCommentTemp[i].IdParent == 0)
                    {
                        ListCommentResult.Add(ListCommentTemp[i]);
                    }
                }
                ListCommentResult.Sort((x, y) => y.Date.CompareTo(x.Date));
            }
        }

        public void DetailMovieClick(object sender, ItemClickEventArgs e)
        {
            Movie MovieClicked = (Movie)e.ClickedItem;
            PageContent.Navigate(typeof(DetailMoviePage), MovieClicked);
        }

        private void CommentClick(object sender, RoutedEventArgs e)
        {
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
            //        ListParams.Add((Object)"DetailMoviePage");
            //        ListParams.Add((Object)CurrentMovie);
            //        PageContent.Navigate(typeof(LoginPage), ListParams);
            //    }
            //}
            //else
            //{
            //    Comment Comment = new Comment()
            //    {
            //        Id = ((App)Application.Current).ListComment.Count + 1,
            //        Date = DateTime.Now,
            //        Content = CommentTextBox.Text,
            //        User = ((App)Application.Current).CurrentUser
            //        //User = ((App)Application.Current).ListUser[0]
            //    };
            //    if (String.IsNullOrWhiteSpace(Comment.Content))
            //    {
            //        MessageDialog Dialog = new MessageDialog("Vui lòng nhập nội dung bình luận!");
            //        Dialog.Commands.Add(new UICommand("Đóng", null, 1));
            //        await Dialog.ShowAsync();
            //        CommentTextBox.Text = String.Empty;
            //    }
            //    else
            //    {
            //        CurrentMovie.ListComment.Add(Comment);
            //        CurrentMovie.ListComment.Sort((x, y) => y.Date.CompareTo(x.Date));
            //        CommentTextBox.Text = String.Empty;
            //        ListCommentListView.ItemsSource = null;
            //        ListCommentListView.ItemsSource = CurrentMovie.ListComment;
            //    }
            //}
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
            //        ListParams.Add((Object)"DetailMoviePage");
            //        ListParams.Add((Object)CurrentMovie);
            //        PageContent.Navigate(typeof(LoginPage), ListParams);
            //    }
            //}
            //else
            //{
            //    PhimS14Content PhimS14ContentRated = (PhimS14Content)CurrentMovie;
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
            //    MovieRating.Text = PhimS14ContentRated.Rating.ToString();
            //}
        }

        public void ReplyTapped(object sender, TappedRoutedEventArgs e)
        {
            Grid Grid = ((FrameworkElement)((FrameworkElement)sender).Parent).Parent as Grid;
            DependencyObject TextBlockChild = VisualTreeHelper.GetChild(Grid, 3);
            TextBlock TextBlock = TextBlockChild as TextBlock;
            DependencyObject GridChild = VisualTreeHelper.GetChild(Grid, 4);
            Grid = GridChild as Grid;
            if (Grid.Visibility != 0)
            {
                Grid.Visibility = 0;
                TextBlock.Text = " Hide Comment";
                DependencyObject ListViewChild = VisualTreeHelper.GetChild(Grid, 0);
                ListView ListView = ListViewChild as ListView;
                Comment Comment = (Comment)((FrameworkElement)sender).DataContext;
                ListView.ItemsSource = Comment.ListSubComment;
            }
        }

        private void SubCommentClick(object sender, RoutedEventArgs e)
        {
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
            //        ListParams.Add((Object)"DetailMoviePage");
            //        ListParams.Add((Object)CurrentMovie);
            //        PageContent.Navigate(typeof(LoginPage), ListParams);
            //    }
            //}
            //else
            //{
            //    Grid Grid = ((FrameworkElement)((FrameworkElement)sender).Parent).Parent as Grid;
            //    DependencyObject TextBoxChild = VisualTreeHelper.GetChild(Grid, 1);
            //    TextBox TextBox = TextBoxChild as TextBox;
            //    DependencyObject ListViewChild = VisualTreeHelper.GetChild(Grid, 0);
            //    ListView ListView = ListViewChild as ListView;
            //    Comment SubComment = new Comment()
            //    {
            //        Id = ((App)Application.Current).ListComment.Count + 1,
            //        Date = DateTime.Now,
            //        Content = TextBox.Text,
            //        User = ((App)Application.Current).CurrentUser
            //        //User = ((App)Application.Current).ListUser[0]
            //    };
            //    if (String.IsNullOrWhiteSpace(SubComment.Content))
            //    {
            //        MessageDialog Dialog = new MessageDialog("Vui lòng nhập nội dung bình luận!");
            //        Dialog.Commands.Add(new UICommand("Đóng", null, 1));
            //        await Dialog.ShowAsync();
            //        CommentTextBox.Text = String.Empty;
            //    }
            //    else
            //    {
            //        Comment Comment = (Comment)((FrameworkElement)sender).DataContext;
            //        Comment.ListSubComment.Add(SubComment);
            //        Comment.ListSubComment.Sort((x, y) => y.Date.CompareTo(x.Date));
            //        TextBox.Text = String.Empty;
            //        ListView.ItemsSource = null;
            //        ListView.ItemsSource = Comment.ListSubComment;
            //    }
            //}
        }

        public void ShowCommentTapped(object sender, TappedRoutedEventArgs e)
        {
            TextBlock TextBlock = ((FrameworkElement)sender) as TextBlock;
            switch (TextBlock.Text)
            {
                case " Hide Comment":
                    TextBlock.Text = " Show Comment";
                    Grid Grid = ((FrameworkElement)sender).Parent as Grid;
                    DependencyObject GridChild = VisualTreeHelper.GetChild(Grid, 4);
                    Grid = GridChild as Grid;
                    Grid.Visibility = (Visibility)1;
                    DependencyObject ListViewChild = VisualTreeHelper.GetChild(Grid, 0);
                    ListView ListView = ListViewChild as ListView;
                    ListView.ItemsSource = null;
                    
                    break;
                case " Show Comment":
                    TextBlock.Text = " Hide Comment";
                    Grid = ((FrameworkElement)sender).Parent as Grid;
                    GridChild = VisualTreeHelper.GetChild(Grid, 4);
                    Grid = GridChild as Grid;
                    Grid.Visibility = 0;
                    ListViewChild = VisualTreeHelper.GetChild(Grid, 0);
                    ListView = ListViewChild as ListView;
                    Comment Comment = (Comment)((FrameworkElement)sender).DataContext;
                    ListView.ItemsSource = Comment.ListSubComment;
                    break;
            }
        }

        public async void ShowMoreCommentClick(object sender, RoutedEventArgs e)
        {
            if (ListComment.Count >= ListCommentResult.Count)
            {
                MessageDialog Dialog = new MessageDialog("Không thể tải thêm bình luận!");
                Dialog.Commands.Add(new UICommand("Đóng", null, 1));
                await Dialog.ShowAsync();
            }
            else
            {
                //ShowComment(ListCommentListView, 3, ListComment, ListCommentResult);
            }
        }

        private void EpisodeClick(object sender, RoutedEventArgs e)
        {
            Button Button = sender as Button;
            TextBlock TextBlock = VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(VisualTreeHelper.GetChild(Button, 0), 0), 0) as TextBlock;
            CurrentEpisode = int.Parse(TextBlock.Text) - 1;
            BannerGrid.Visibility = (Visibility)1;
            MovieMedia.Visibility = 0;
            Uri MediaUri = new Uri(ListEpisode[CurrentEpisode].Link);
            MovieMedia.Source = MediaUri;
        }

        private void WatchMovieTapped(object sender, TappedRoutedEventArgs e)
        {
            BannerGrid.Visibility = (Visibility)1;
            MovieMedia.Visibility = 0;
            Uri MediaUri = new Uri(ListEpisode[CurrentEpisode].Link);
            MovieMedia.Source = MediaUri;
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

        private void FullScreenClick(object sender, RoutedEventArgs e)
        {
            if (AppBar.Visibility == 0)
            {
                AppBar.Visibility = (Visibility)1;
            }
            else
            {
                AppBar.Visibility = 0;
            }
        }

        private async void PivotChanged(object sender, SelectionChangedEventArgs e)
        {
            PivotItem PivotItem = (PivotItem)(sender as Pivot).SelectedItem;
            switch (PivotItem.Header.ToString())
            {
                case "Thông tin":
                    break;
                case "Liên quan":
                    if (ActorGridView.Items.Count == 0)
                    {
                        // connect to service
                        HttpClient MyHttpClient = new HttpClient();
                        MyHttpClient.DefaultRequestHeaders.Add("SOAPAction", Service.SOAPAction);

                        // request for actor
                        StringContent Content = new StringContent(Service.CreateRequest("Person", "Image,Name", "IDMovie|" + CurrentMovieId, "Windows Phone", ""), Encoding.UTF8, "text/xml");
                        HttpResponseMessage Response = await MyHttpClient.PostAsync(Service.URL, Content);
                        String SoapResponse = await Response.Content.ReadAsStringAsync();
                        List<String> Data = Service.DecodeSoapResponse(SoapResponse);
                        if (Data.Count <= 2)
                        {
                            Service.ShowMessageDialogServerError();
                        }
                        else
                        {
                            List<Person> ListPerson = new List<Person>();
                            for (int i = 2; i < Data.Count; i++)
                            {
                                Person Person = Service.ConvertDataToPerson(Data[i]);
                                ListPerson.Add(Person);
                            }
                            ActorGridView.ItemsSource = ListPerson;
                        }

                        // request for relevant movie
                        Critic = "IDCategory";
                        Value = Random.Next(1, 15).ToString();
                        Content = new StringContent(Service.CreateRequest("Movie", "IDMovie,Image,Name", Critic + "|" + Value, "Windows Phone", ""), Encoding.UTF8, "text/xml");
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
                                String[] ListData = Service.SplitData(Data[i]);
                                Movie Movie = new Movie();
                                Movie.Id = ListData[0];
                                Movie.Image = ListData[1];
                                Movie.Name = ListData[2];
                                ListMovie.Add(Movie);
                            }
                            MovieGridView.ItemsSource = ListMovie;
                        }
                    }
                    break;
                case "Bình luận":
                    Uri Uri = new Uri("http://www.microsoft.com");
                    FacebookCommentWebView.Navigate(Uri);
                    break;
            }
        }
    }
}
