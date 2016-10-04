using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TweetsReader.Views
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            //InitializeComponent();
            var loginPage = new LoginPage();
            Navigation.PushModalAsync(loginPage);
        }
    }
}
