using System;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReadBooks
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override async void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("ios=ea6fc345-1671-4945-9fbe-7cc344cda0d8;" +
                            "android=ea623267-b35a-495a-9cf7-c5775ff56f78",
                            typeof(Analytics), typeof(Crashes));

            bool didAppCrash = await Crashes.HasCrashedInLastSessionAsync();
            if(didAppCrash)
            {
                await MainPage.DisplayAlert("Oops, sorry", "It appears we ran into a problem in your last session, sorry about that.", "Don't worry");
            }
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
