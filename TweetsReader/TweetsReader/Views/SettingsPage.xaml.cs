using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetsReader.Helpers;

using Xamarin.Forms;

namespace TweetsReader.Views
{
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            AuthorEntry.Text = Settings.SettingsAuthorName;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Settings.SettingsAuthorName = AuthorEntry.Text;
        }
    }
}
