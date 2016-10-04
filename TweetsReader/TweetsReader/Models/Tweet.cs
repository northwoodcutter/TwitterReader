using Newtonsoft.Json;
using System.ComponentModel;

namespace TweetsReader.Models
{
    public class Tweet : INotifyPropertyChanged
    {
       
        public string text;
       

        public string Text
        {
            get { return text; }
            set
            {
                text = value;
                OnPropertyChanged("Text");
            }
        }
        [JsonProperty("user")]
        public User User { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
