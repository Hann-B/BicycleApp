using Bicycle.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Bicycle.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OAuthNativeFlowPage : ContentPage
    {
        Account account;
        AccountStore store;

        public OAuthNativeFlowPage()
        {
            InitializeComponent();
            

            store = AccountStore.Create();
            account = store.FindAccountsForService(Constants.AppName).FirstOrDefault();

        }

        async void GuestLoginClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new NavigationPage(new StartPage()));
        }

        void GoogleLoginClicked(object sender, EventArgs e)
        {
            string clientId = null;
            string redirectUri = null;

            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    clientId = Constants.iOSClientId;
                    redirectUri = Constants.iOSRedirectUrl;
                    break;

                case Device.Android:
                    clientId = Constants.AndroidClientId;
                    redirectUri = Constants.AndroidRedirectUrl;
                    break;
            }

            var authenticator = new OAuth2Authenticator(
                clientId,
                null,
                Constants.Scope,
                new Uri(Constants.AuthorizeUrl),
                new Uri(redirectUri),
                new Uri(Constants.AccessTokenUrl),
                null,
                true);

            authenticator.Completed += OnAuthCompleted;
            authenticator.Error += OnAuthError;
            authenticator.BrowsingCompleted += Authenticator_BrowsingCompleted;

            AuthenticationState.Authenticator = authenticator;

            var presenter = new Xamarin.Auth.Presenters.OAuthLoginPresenter();
             presenter.Login(authenticator);
            ////Entering a Break State Here, Why? 
            //var x = 8 + 9;
            //the redirect should be to the home page..not formated yet BTW
        }

        private void Authenticator_BrowsingCompleted(object sender, EventArgs e)
        {
            var test = 9;
        }

        async void OnAuthCompleted(object sender, AuthenticatorCompletedEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            User user = null;
            if (e.IsAuthenticated)
            {
                // If the user is authenticated, request their basic user data from Google
                // UserInfoUrl = https://www.googleapis.com/oauth2/v2/userinfo
                var request = new OAuth2Request("GET", new Uri(Constants.UserInfoUrl), null, e.Account);
                var response = await request.GetResponseAsync();
                if (response != null)
                {
                    // Deserialize the data and store it in the account store
                    // The users email address will be used to identify data in SimpleDB
                    string userJson = await response.GetResponseTextAsync();
                    user = JsonConvert.DeserializeObject<User>(userJson);
                }

                if (account != null)
                {
                    store.Delete(account, Constants.AppName);
                }

                await store.SaveAsync(account = e.Account, Constants.AppName);
                await DisplayAlert("Email address", user.Email, "OK");
            }
        }

        void OnAuthError(object sender, AuthenticatorErrorEventArgs e)
        {
            var authenticator = sender as OAuth2Authenticator;
            if (authenticator != null)
            {
                authenticator.Completed -= OnAuthCompleted;
                authenticator.Error -= OnAuthError;
            }

            Debug.WriteLine("Authentication error: " + e.Message);
        }

        void LinkedInLoginClicked(object sender, EventArgs e)
        {
            var auth = new OAuth2Authenticator(
                clientId: "780t4zo7innee3",
                clientSecret: "LvxUbEa4BlVRgiCv",
                scope: "r_fullprofile r_contactinfo",
                authorizeUrl: new Uri("https://www.linkedin.com/uas/oauth2/authorization"),
                redirectUrl: new Uri("https://hlb.auth0.com/login/callback"),
                accessTokenUrl: new Uri("https://www.linkedin.com/uas/oauth2/accessToken")

            );

            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.AllowCancel = true;
            auth.Error += async (o, evented) => {
                var x = 8;
                Debug.WriteLine("Helloe world");
            };

            auth.Completed += async (o, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    string dd = eventArgs.Account.Username;
                    var values = eventArgs.Account.Properties;
                    var access_token = values["access_token"];
                    try
                    {

                        var request = HttpWebRequest.Create(string.Format(@"https://api.linkedin.com/v1/people/~:(id,firstName,lastName,headline,picture-url,summary,educations,three-current-positions,honors-awards,site-standard-profile-request,location,api-standard-profile-request,phone-numbers)?oauth2_access_token=" + access_token + "&format=json", ""));
                        request.ContentType = "application/json";
                        request.Method = "GET";

                        using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                        {
                            Debug.WriteLine("Stautus Code is: {0}", response.StatusCode);

                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                var content = reader.ReadToEnd();
                                if (!string.IsNullOrWhiteSpace(content))
                                {

                                    Debug.WriteLine(content);
                                }
                                var result = JsonConvert.DeserializeObject<dynamic>(content);
                            }
                        }
                    }
                    catch (Exception exx)
                    {
                        Debug.WriteLine(exx.ToString());
                    }
                }
            };
        }

        void InstagramLoginClicked(object sender, EventArgs e)
        {
            var auth = new OAuth2Authenticator(
                clientId: "76a2a3753cac4e80a5e84dffd7e8dac7",
                clientSecret: "73d2bb8c6e704512b09f9f3a5f170d07",
                scope: "public_content",
                authorizeUrl: new Uri("https://api.instagram.com/oauth/authorize/?client_id=CLIENT-ID&redirect_uri=REDIRECT-URI&response_type=code"),
                redirectUrl: new Uri("http://your-redirect-uri?code=CODE"),
                accessTokenUrl: new Uri("https://api.instagram.com/oauth/access_token")

            );

            // If authorization succeeds or is canceled, .Completed will be fired.
            auth.AllowCancel = true;
            auth.Completed += async (o, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    string dd = eventArgs.Account.Username;
                    var values = eventArgs.Account.Properties;
                    var access_token = values["access_token"];
                    try
                    {

                        var request = HttpWebRequest.Create(string.Format(@"https://api.instagram.com/v1/users/{user-id}/?access_token=" + access_token + "&format=json", ""));
                        request.ContentType = "application/json";
                        request.Method = "GET";

                        using (HttpWebResponse response = await request.GetResponseAsync() as HttpWebResponse)
                        {
                            Debug.WriteLine("Stautus Code is: {0}", response.StatusCode);

                            using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                            {
                                var content = reader.ReadToEnd();
                                if (!string.IsNullOrWhiteSpace(content))
                                {

                                    Debug.WriteLine(content);
                                }
                                var result = JsonConvert.DeserializeObject<dynamic>(content);
                            }
                        }
                    }
                    catch (Exception exx)
                    {
                        Debug.WriteLine(exx.ToString());
                    }
                }
            };
        }
    }
}