using System;
using System.Collections.Generic;
using System.Diagnostics;
using TweetsReader.Models;
using TweetsReader.ViewModels;
using Xamarin.Forms;

namespace TweetsReader.Views
{
    public partial class ListPage : ContentPage
    {
        readonly TweetViewModel tweetVM;

        List<Tweet> tweets;

        public ListPage(List<Tweet> tweets)
        {
            InitializeComponent();
            this.tweets = tweets;
            tweetVM = new TweetViewModel();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();          
            try
            {
                tweetVM.InitTweetViewModel(tweets);
                BindingContext = tweetVM;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }

        private async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Tweet selectedTweet = e.SelectedItem as Tweet;
            App.Current.MainPage = new DetailPage(selectedTweet);
          
        }
    }
}
