using TweetsReader.Models;
using Xamarin.Forms;

namespace TweetsReader.Views
{
    public partial class DetailPage : ContentPage
    {
        Tweet Tweet { get; set; }
        public DetailPage(Tweet tweet)
        {
            InitializeComponent();
            Tweet = tweet;
            this.BindingContext = Tweet;
        }
    }
}
