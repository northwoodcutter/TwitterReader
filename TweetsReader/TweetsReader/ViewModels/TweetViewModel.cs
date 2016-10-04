using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

using TweetsReader.Models;

namespace TweetsReader.ViewModels
{
    class TweetViewModel : INotifyPropertyChanged
    {
        public ICommand ShowDetailCommand { protected set; get; }
      
        List<Tweet> tweets;
        public List<Tweet> Tweets
        {
            get
            {
                return tweets;
            }
            set
            {
                if (tweets == value)
                {
                    return;
                }
                    tweets = value;
                    OnPropertyChanged();
            }
        }
        public void InitTweetViewModel(List<Tweet> tweets)
        {
            this.tweets = tweets;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (propertyName == null)
                throw new ArgumentNullException("Can't call OnPropertyChanged with a null property name.", propertyName);

            PropertyChangedEventHandler propChangedHandler = PropertyChanged;
            if (propChangedHandler != null)
                propChangedHandler(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
