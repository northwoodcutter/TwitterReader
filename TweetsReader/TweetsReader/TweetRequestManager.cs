using Java.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using TweetsReader.Models;

namespace TweetsReader
{
    public class TweetRequestManager
    {
        //List<Tweet> tweets;

        //public async Task<List<Tweet>> SearchTweets(string query)
        //{
        //    tweets = new List<Tweet>();
        //    string url = "https://api.twitter.com/1.1/search/tweets.json?q=" + query;
        //    HttpWebRequest searchRequest = (HttpWebRequest)WebRequest.Create(url);
        //    searchRequest.Headers["Authorization"] = "Authorization: OAuth oauth_consumer_key=\"EX8i1TWEWcIUldEkXcjB8G9XJ\", "
        //        + "oauth_nonce=\"f8fe567286d5304fbd3bdb8f36384a66\", oauth_signature=\"aegKGGu51qjPtJcme%2Bdv%2Ft1X708%3D\", "
        //        + "oauth_signature_method=\"HMAC-SHA1\", oauth_timestamp=\"1474896549\", "
        //        + "oauth_token=\"776021525761822720-qexWOueBitE7W5zowv9OlyUUtus1rA4\", oauth_version=\"1.0\"";
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
        //    //searchRequest.BeginGetResponse(new AsyncCallback(ReadWebRequestCallback), searchRequest);
        //    return tweets;
        //}

        //private void ReadWebRequestCallback(IAsyncResult callbackResult)
        //{
        //    HttpWebRequest request = (HttpWebRequest)callbackResult.AsyncState;
        //    using (HttpWebResponse response = (HttpWebResponse)request.EndGetResponse(callbackResult))
        //    {
        //        using (StreamReader httpWebStreamReader = new StreamReader(response.GetResponseStream()))
        //        {
        //            string results = httpWebStreamReader.ReadToEnd();
        //            dynamic stuff = JsonConvert.DeserializeObject(results);

        //            foreach (JObject item in stuff)
        //            {
        //                foreach (JProperty trend in item["user"])
        //                {
        //                    Tweet tweet = new Tweet();
        //                    if (trend.Name == "name")
        //                    {
        //                        tweet.ScreenName = trend.Name;
        //                        Debug.WriteLine(trend.Name);
        //                    }
        //                    else if (trend.Name == "text")
        //                    {
        //                        tweet.Text = trend.Name;
        //                        Debug.WriteLine(tweet.Text);
        //                    }
        //                    else if (trend.Name == "profile_image_url")
        //                    {
        //                        tweet.ImageUrl = trend.Name;
        //                        Debug.WriteLine(trend.Name);
        //                    }
        //                    tweets.Add(tweet);
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
