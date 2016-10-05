using System;
using Android.App;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Xamarin.Auth;
using TweetsReader.Views;
using System.Collections.Generic;
using TweetsReader.Helpers;
using TweetsReader.Models;
using Newtonsoft.Json;

[assembly: ExportRenderer(typeof(LoginPage), typeof(TweetsReader.Droid.LoginPageRenderer))]
namespace TweetsReader.Droid
{
    public class LoginPageRenderer: PageRenderer
    {
        bool done = false;
        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
            {
                return;
            }

            if (!done)
            {
                Authenticate();
                done = true;
            }
        }

        private void Authenticate()
        {
            var activity = this.Context as Activity;
            var auth = new OAuth1Authenticator(
                consumerKey: VerifyTwitterAppHelper.ConsumerKey,
                consumerSecret: VerifyTwitterAppHelper.ConsumerSecret,
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
                    userParams.Add("screen_name", Settings.SettingsAuthorName);
                    var request = new OAuth1Request("GET",
                        new Uri("https://api.twitter.com/1.1/statuses/user_timeline.json"), userParams, account, false);
                    var response = await request.GetResponseAsync();
                    var tweetsUser = await response.GetResponseTextAsync();
                    List<Tweet> twitts = JsonConvert.DeserializeObject<List<Tweet>>(tweetsUser);
                    App.Current.MainPage = new NavigationPage(new ListPage(twitts));
                }
                else
                {
                    App.Current.MainPage = new ErrorLogin();
                    VerifyTwitterAppHelper.Token = "";

                }
            };

            auth.AllowCancel = false;
            activity.StartActivity(auth.GetUI(activity));
        }

        //async void Search(String query)
        //{
        //    string url = "https://api.twitter.com/1.1/search/tweets.json?q=" + query;
        //    HttpWebRequest searchRequest = (HttpWebRequest)WebRequest.Create(url);
        //    searchRequest.Headers.Add("Authorization", VerifyTwitterAppHelper.GetAuthHeader());
        //    searchRequest.Method = "GET";
        //    searchRequest.ContentType = "application/x-www-form-urlencoded;charset=UTF-8";
        //    searchRequest.Accept = "application/json";
        //    HttpWebResponse response = (HttpWebResponse)await searchRequest.GetResponseAsync();
        //    using (Stream stream = response.GetResponseStream())
        //    {
        //        using (StreamReader reader = new StreamReader(stream))
        //        {
        //            reader.ReadToEnd();
        //        }
        //    }
        //}

    }
}