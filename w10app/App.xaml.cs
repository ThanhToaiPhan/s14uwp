using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using w10app.Models;

namespace w10app
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        public User CurrentUser;

        //public List<Actor> ListActor = new List<Actor>();
        //public List<Clip> ListClip = new List<Clip>();
        //public List<Comment> ListComment = new List<Comment>();
        //public List<GameShow> ListGameShow = new List<GameShow>();
        //public List<Movie> ListMovie = new List<Movie>();
        //public List<Producer> ListProducer = new List<Producer>();
        //public List<Rating> ListRating = new List<Rating>();
        //public List<User> ListUser = new List<User>();
        //public static readonly Random Random = new Random();
        //public static readonly Object Synclock = new Object();
        public App()
        {
            Microsoft.ApplicationInsights.WindowsAppInitializer.InitializeAsync(
                Microsoft.ApplicationInsights.WindowsCollectors.Metadata |
                Microsoft.ApplicationInsights.WindowsCollectors.Session);
            this.InitializeComponent();
            this.Suspending += OnSuspending;
        }

        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame == null)
            {
                rootFrame = new Frame();

                rootFrame.NavigationFailed += OnNavigationFailed;

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {

                }

                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                rootFrame.Navigate(typeof(MainPage), e.Arguments);
            }
            Window.Current.Activate();
        }

        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            deferral.Complete();
        }

        //public int RandomNumber(int MinValue, int MaxValue)
        //{
        //    lock(Synclock)
        //    {
        //        return Random.Next(MinValue, MaxValue);
        //    }
        //}

        //public void CreateDemoData()
        //{
        //    //List Producer Demo
        //    ListProducer.Add(new Producer() { Id = 1, Name = "Lê Phương Nam" });
        //    ListProducer.Add(new Producer() { Id = 2, Name = "Nguyễn Quang Dũng" });

        //    //List Actor Demo
        //    ListActor.Add(new Actor() { Id = 1, Name = "Bình Minh" });
        //    ListActor.Add(new Actor() { Id = 2, Name = "Minh Thảo" });
        //    ListActor.Add(new Actor() { Id = 3, Name = "Phương Khánh" });
        //    ListActor.Add(new Actor() { Id = 4, Name = "Nhã Phương" });
        //    ListActor.Add(new Actor() { Id = 5, Name = "Chí Tài" });
        //    ListActor.Add(new Actor() { Id = 6, Name = "Hoài Linh" });

        //    //List User Demo
        //    ListUser.Add(new User() { Id = 1, Username = "Marcus Farnham", Password = "password", Email = "user999@email.com", Point = 10000, Image = "Assets/Image/avatar.jpg" });
        //    ListUser.Add(new User() { Id = 2, Username = "Jaron Jenkins", Password = "password", Email = "user1@email.com", Point = 130, Image = "Assets/Image/avatar.jpg" });
        //    ListUser.Add(new User() { Id = 3, Username = "Claud Cantrell", Password = "password", Email = "user2@email.com", Point = 10, Image = "Assets/Image/avatar.jpg" });
        //    ListUser.Add(new User() { Id = 4, Username = "Xander Moses", Password = "password", Email = "user3@email.com", Point = 100, Image = "Assets/Image/avatar.jpg" });
        //    ListUser.Add(new User() { Id = 5, Username = "Napier Goddard", Password = "password", Email = "user4@email.com", Point = 50, Image = "Assets/Image/avatar.jpg" });
        //    ListUser.Add(new User() { Id = 6, Username = "Nicky Joiner", Password = "password", Email = "user5@email.com", Point = 410, Image = "Assets/Image/avatar.jpg" });
        //    ListUser.Add(new User() { Id = 7, Username = "Desmond Blackwood", Password = "password", Email = "user6@email.com", Point = 150, Image = "Assets/Image/avatar.jpg" });

        //    //List Comment Demo
        //    ListComment.Add(new Comment() { Id = 1, Date = new DateTime(2016, 1, 1), User = ListUser[1], Content = "a", ListSubComment = new List<Comment>() });
        //    ListComment.Add(new Comment() { Id = 2, Date = new DateTime(2016, 1, 2), User = ListUser[2], Content = "b", ListSubComment = new List<Comment>() });
        //    ListComment.Add(new Comment() { Id = 3, Date = new DateTime(2016, 1, 3), User = ListUser[4], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListSubComment = new List<Comment>() });
        //    ListComment.Add(new Comment() { Id = 4, Date = new DateTime(2016, 1, 4), User = ListUser[2], Content = "c", ListSubComment = new List<Comment>() });
        //    ListComment.Add(new Comment() { Id = 5, Date = new DateTime(2016, 1, 5), User = ListUser[5], Content = "d", ListSubComment = new List<Comment>() });
        //    ListComment[3].ListSubComment.Add(new Comment() { Id = 6, Date = new DateTime(2016, 1, 6), User = ListUser[5], Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi." });
        //    ListComment[3].ListSubComment.Add(new Comment() { Id = 7, Date = new DateTime(2016, 1, 7), User = ListUser[6], Content = "e" });
        //    ListComment[1].ListSubComment.Add(new Comment() { Id = 8, Date = new DateTime(2016, 1, 8), User = ListUser[1], Content = "f" });
        //    ListComment.Sort((x, y) => y.Date.CompareTo(x.Date));

        //    //List Movie Demo
        //    ListMovie.Add(new Movie() { Id = 1, Image = "Assets/Image/film1.jpg", Name = "49 Ngày (HD)", Time = "120 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment, Type = "Phim bộ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });

        //    ListMovie.Add(new Movie() { Id = 2, Image = "Assets/Image/film2.jpg", Name = "Tôi thấy hoa vàng trên cỏ xanh (HD)", Time = "90 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment,  Type = "Phim lẻ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    ListMovie.Add(new Movie() { Id = 3, Image = "Assets/Image/film3.jpg", Name = "Nàng tiên cá (HD)", Time = "120 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment, Type = "Phim bộ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    ListMovie.Add(new Movie() { Id = 4, Image = "Assets/Image/film4.jpg", Name = "Công chúa Teen và Ngũ Hổ Tướng (HD)", Time = "90 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment,  Type = "Phim lẻ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    ListMovie.Add(new Movie() { Id = 5, Image = "Assets/Image/film5.jpg", Name = "Em là bà bội của anh (HD)", Time = "120 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment, Type = "Phim bộ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    ListMovie.Add(new Movie() { Id = 6, Image = "Assets/Image/film6.jpg", Name = "Gái già Xì tin (HD)", Time = "90 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment, Type = "Phim lẻ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    ListMovie.Add(new Movie() { Id = 7, Image = "Assets/Image/film7.jpg", Name = "Tèo em (HD)", Time = "120 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment, Type = "Phim bộ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    ListMovie.Add(new Movie() { Id = 8, Image = "Assets/Image/film8.jpg", Name = "Trùm cỏ (HD)", Time = "90 phút", ListProducer = ListProducer, ListActor = ListActor, Trailer = "https://www.youtube.com/watch?v=ZIM1HydF9UA", Link = "http://ads.indolink.vn/Video/main.mp4", Country = "Việt Nam", ReleaseYear = 2016, NumberView = 1323, NumberComment = 36, Content = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum auctor massa id ante sollicitudin blandit. Vivamus massa augue, sollicitudin non justo aliquam, tempus volutpat felis. Sed at fringilla nisl, vitae dictum ipsum. Interdum et malesuada fames ac ante ipsum primis in faucibus. Pellentesque rutrum odio ut lacus malesuada, ut faucibus turpis malesuada. Praesent nec tortor diam. Duis facilisis augue risus, et consequat sem tincidunt eget. Curabitur et purus dignissim, consectetur elit quis, pellentesque nisi.", ListComment = ListComment, Type = "Phim lẻ", Episode = "20", Source = "phims14.vn", ListRelevantMovie = new List<Movie>() });
        //    foreach (Movie Movie in ListMovie)
        //    {
        //        Random Random = new Random();
        //        for (int i = 0; i < 4; i++)
        //        {
        //            Movie.ListRelevantMovie.Add(ListMovie[RandomNumber(0, 8)]);
        //        }
        //    }

        //    //List Clip Demo
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip1.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 3.2 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip2.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 2.4 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip3.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 3 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip4.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 4.3 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip5.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 4 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip6.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 4.5 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip7.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn",Rating = 4.7 });
        //    ListClip.Add(new Clip() { Image = "Assets/Image/clip8.png", Name = "Clip vui nhộn", Time = "5 phút", Type = "Hài hước", Episode = "1", Source = "phims14.vn", Rating = 5 });

        //    //List GameShow Demo
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow1.jpg", Name = "Ca sĩ giấu mặt", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 4.4 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow2.jpg", Name = "Hội quán tiếu lâm (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 1.2 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow3.jpg", Name = "Ơn giời! Cậu đây rồi (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 3.1 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow4.jpg", Name = "Sàn đấu thời gian (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 2.5 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow5.jpg", Name = "Hóa đơn may mắn (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 3.3 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow6.jpg", Name = "VietNam Next Top Model (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 4.2 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow7.jpg", Name = "Thách thức danh hài (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 3.1 });
        //    ListGameShow.Add(new GameShow() { Image = "Assets/Image/gameshow8.jpg", Name = "Vui ơi là vui (HD)", Time = "60 phút", Type = "Game Show", Episode = "20", Source = "phims14.vn", Detail = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi non neque in erat fringilla cursus sit amet a lorem.", Rating = 4 });

        //    //List Rating Demo
        //    foreach (Movie Movie in ListMovie)
        //    {
        //        Double Point = 0;
        //        Random Random = new Random();
        //        Object Synclock = new Object();
        //        foreach (User User in ListUser)
        //        {
        //            Rating Rating = new Rating() { User = User, PhimS14Content = Movie, Point = RandomNumber(1, 6)};
        //            ListRating.Add(Rating);
        //            Point += Rating.Point;
        //        }
        //        Movie.Rating = Math.Round(Point / ListUser.Count, 1);
        //    }
        //}
    }
}
