using System;
using System.Text;
using System.Net;
using System.IO;
using System.Security.Cryptography;
using Xamarin.Auth;
using System.Reactive.Concurrency;

namespace TweetsReader.Droid
{
    public class VerifyTwitterAppHelper
    {
        private static string oauth_token = "776021525761822720-qexWOueBitE7W5zowv9OlyUUtus1rA4";
        private static string oauth_token_secret = "aG64CTaiZZS55wFmHTAcLJzLdFvCilJeJWnuS3YSOoNs6";
        private static string oauth_consumer_key = "EX8i1TWEWcIUldEkXcjB8G9XJ";
        private static string oauth_consumer_secret = "7MDbtP5quwfrV0SyLpYtGoABajgG465EYfXlUiXt1apbCqVNAv";

        public static string ConsumerKey
        {
            get
            {
                return oauth_consumer_key;
            }
            set
            {
                oauth_consumer_key = value;
            }
        }

        public static string ConsumerSecret
        {
            get
            {
                return oauth_consumer_secret;
            }
            set
            {
                oauth_consumer_secret = value;
            }
        }

        public static string Token
        {
            get
            {
                return oauth_token;
            }
            set
            {
                oauth_token = value;
            }
        }

        public static string TokenSecret
        {
            get
            {
                return oauth_token_secret;
            }

            set
            {
               oauth_token_secret = value;
            }
        }

        async public static void VerifyApp(AuthenticatorCompletedEventArgs e)
        {
            //string authHeader = GetAuthHeader();
            //HttpWebRequest verifyRequest = (HttpWebRequest)WebRequest.Create("https://api.twitter.com/1.1/account/verify_credentials.json");
            //verifyRequest.Method = "GET";
            //verifyRequest.ContentType = "application/x-www-form-urlencoded";
            //verifyRequest.Headers.Add("Authorization", authHeader);
            //HttpWebResponse response = (HttpWebResponse)verifyRequest.GetResponse();
            //Stream receiveStream = response.GetResponseStream();
            //StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            //Console.WriteLine("Response stream received.");
            //Console.WriteLine(readStream.ReadToEnd());
            //response.Close();
            //readStream.Close();

           var request = new OAuth1Request(
           "GET",
           new Uri("https://api.twitter.com/1.1/account/verify_credentials.json"),
           null,
           e.Account, true);
         }

        public static string GetAuthHeader()
        {
            string oauth_version = "1.0";
            string oauth_signature_method = "HMAC-SHA1";
            string oauth_nonce = Convert.ToBase64String(new UTF8Encoding().GetBytes(DateTime.Now.Ticks.ToString()));
            var timeSpan = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            var oauth_timestamp = Convert.ToInt64(timeSpan.TotalSeconds).ToString();
            var resource_url = "https://api.twitter.com/1.1/statuses/update.json";

            var baseFormat = "oauth_consumer_key={0}&oauth_nonce={1}&oauth_signature_method={2}" +
                 "&oauth_timestamp={3}&oauth_token={4}&oauth_version={5}";

            var baseString = string.Format(baseFormat,
                                        oauth_consumer_key,
                                        oauth_nonce,
                                        oauth_signature_method,
                                        oauth_timestamp,
                                        oauth_token,
                                        oauth_version);

            baseString = string.Concat("GET&", Uri.EscapeDataString(resource_url),
                         "&", Uri.EscapeDataString(baseString));

            var compositeKey = string.Concat(Uri.EscapeDataString(oauth_consumer_secret),
                       "&", Uri.EscapeDataString(oauth_token_secret));

            string oauth_signature;
            using (HMACSHA1 hasher = new HMACSHA1(new UTF8Encoding().GetBytes(compositeKey)))
            {
                oauth_signature = Convert.ToBase64String(
                    hasher.ComputeHash(new UTF8Encoding().GetBytes(baseString)));
            }

            string headerFormat = "OAuth oauth_consumer_key=\"{0}\", oauth_nonce=\"{1}\", oauth_signature=\"{2}\", oauth_signature_method=\"{3}\", " +
               "oauth_timestamp=\"{4}\", " +
               "oauth_token=\"{5}\", " +
               "oauth_version=\"{6}\"";

            var authHeader = string.Format(headerFormat,
                                     Uri.EscapeDataString(oauth_consumer_key),
                                     Uri.EscapeDataString(oauth_nonce),
                                     Uri.EscapeDataString(oauth_signature),
                                     Uri.EscapeDataString(oauth_signature_method),
                                     Uri.EscapeDataString(oauth_timestamp),
                                     Uri.EscapeDataString(oauth_token),
                                     Uri.EscapeDataString(oauth_version)
                             );
            return authHeader;
        }
    }
}