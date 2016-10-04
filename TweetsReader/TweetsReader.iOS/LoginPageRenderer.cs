using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using TweetsReader.Models;
using TweetsReader.Views;
using Xamarin.Auth;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(LoginPage), typeof(TweetsReader.iOS.LoginPageRenderer))]
namespace TweetsReader.iOS
{
    public class LoginPageRenderer: PageRenderer
    {
        bool done = false;

        public override void ViewDidAppear(bool animated)
        {
            base.ViewDidAppear(animated);
            if (done)
                return;

            var auth = new OAuth1Authenticator(
                consumerKey: "EX8i1TWEWcIUldEkXcjB8G9XJ",
                consumerSecret: "7MDbtP5quwfrV0SyLpYtGoABajgG465EYfXlUiXt1apbCqVNAv",
                requestTokenUrl: new Uri("https://api.twitter.com/oauth/request_token"),
                authorizeUrl: new Uri("https://api.twitter.com/oauth/authorize"),
                accessTokenUrl: new Uri("https://api.twitter.com/oauth/access_token"),
                callbackUrl: new Uri("https://apps.twitter.com/"));

            auth.Completed += async (sender, eventArgs) =>
            {
                if (eventArgs.IsAuthenticated)
                {
                    Account account = eventArgs.Account;
                    IDictionary<string, string> userParams = new Dictionary<string, string>();
                    userParams.Add("screen_name", "brodsky_joseph");
                    var request = new OAuth1Request("GET",
                        new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json"), userParams, account, false);
                    var response = await request.GetResponseAsync();
                    var tweetsUser = await response.GetResponseTextAsync();
                    List<Tweet> twitts = JsonConvert.DeserializeObject<List<Tweet>>(tweetsUser);
                    App.Current.MainPage = new ListPage(twitts);
                }
                else
                {
                    App.Current.MainPage = new ErrorLogin();

                }
            };
            done = true;
            PresentViewController(auth.GetUI(), true, null);
        }
    }
}
