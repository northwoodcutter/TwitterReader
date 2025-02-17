using System.Collections.Generic;
using System.Threading.Tasks;
using TweetsReader.Models;
using TweetsReader.Views;
using Xamarin.Forms;

namespace TweetsReader
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new StartPage());      
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
