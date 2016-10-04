using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TweetsReader.Models
{
    public class User
    {
        private ulong statusID;
        public string screenName;
        public string imageUrl;
        public ulong StatusID
        {
            get { return statusID; }
            set
            {
                statusID = value;
                OnPropertyChanged("StatusID");
            }
        }
        [JsonProperty("screen_name")]
        public string ScreenName
        {
            get { return screenName; }
            set
            {
                screenName = value;
                OnPropertyChanged("ScreenName");
            }
        }
        [JsonProperty("profile_image_url")]
        public string ImageUrl
        {
            get { return imageUrl; }
            set
            {
                imageUrl = value;
                OnPropertyChanged("ImageUrl");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
