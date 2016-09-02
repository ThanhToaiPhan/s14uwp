using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using w10app.Models;
using Windows.Security.Authentication.Web;
using Facebook;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace w10app
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LoginPage : Page
    {
        List<Object> ListParams = new List<Object>();

        public LoginPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ListParams = (List<Object>)e.Parameter;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            //List<User> ListUser = ((App)Application.Current).ListUser;
            //String Email = EmailTextBox.Text;
            //String Password = PasswordTextBox.Password;
            //foreach (User User in ListUser)
            //{
            //    if (User.Email.CompareTo(Email) == 0 && User.Password.CompareTo(Password) == 0)
            //    {
            //        ((App)Application.Current).CurrentUser = User;
            //        NavigateFrame(ListParams);
            //        break;
            //    }   
            //}
            //if (((App)Application.Current).CurrentUser == null)
            //{
            //    LoginErrorTextBlock.Text = "Sai tên đăng nhập hoặc mật khẩu!";
            //}
        }

        private async void LoginFacebookButtonClick(object sender, RoutedEventArgs e)
        {
            String ClientID = "741576099310968";
            String Scope = "public_profile,email";
            String CallbackUri = WebAuthenticationBroker.GetCurrentApplicationCallbackUri().AbsoluteUri.ToString();
            String ResponseType = "token";
            String Display = "popup";

            FacebookClient FB = new FacebookClient();
            var LoginUrl = FB.GetLoginUrl(new
            {
                client_id = ClientID,
                redirect_uri = CallbackUri,
                scope = Scope,
                display = Display,
                response_type = ResponseType
            });

            WebAuthenticationResult WebAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, LoginUrl);
            if (WebAuthenticationResult.ResponseStatus == WebAuthenticationStatus.Success)
            {
                var CallbackUrl = new Uri(WebAuthenticationResult.ResponseData.ToString());
                var FacebookOAuthResult = FB.ParseOAuthCallbackUrl(CallbackUrl);

                FacebookClient FBClient = new FacebookClient(FacebookOAuthResult.AccessToken);
                dynamic Result = await FBClient.GetTaskAsync("me");
                String Id = Result.id;
                String Email = Result.email;
                String Username = Result.name;
                var AccessToken = FacebookOAuthResult.AccessToken;
                NavigateFrame(ListParams);
            }
            else
            {
                LoginErrorTextBlock.Text = "Lỗi xảy ra khi đăng nhập Facebook!";
            }
        }

        private void NavigateFrame(List<Object> ListParams)
        {
            switch ((String)ListParams[0])
            {
                case "MainPage":
                    PageContent.Navigate(typeof(MainPage));
                    break;
                case "DetailMoviePage":
                    PageContent.Navigate(typeof(DetailMoviePage), (Movie)ListParams[1]);
                    break;
            }
        }
    }
}
