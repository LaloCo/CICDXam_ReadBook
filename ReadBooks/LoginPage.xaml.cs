using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ReadBooks
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        async void LoginButton_Clicked(object sender, System.EventArgs e)
        {
            try
            {
                //TODO: adding login
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                {
                    { "user", "eduardo@lpa.com" },
                    { "network", "WiFi" }
                };
                AppCenterHelper.TrackEvent("logged_in", keyValuePairs);
                await Navigation.PopModalAsync(true);
            }
            catch(Exception ex)
            {
                Dictionary<string, string> keyValuePairs = new Dictionary<string, string>
                {
                    { "Signal", "Strong" },
                    { "NewUser", "False" },
                    { "WiFi", "On" }
                };
                AppCenterHelper.TrackError(ex, keyValuePairs);
            }
        }
    }
}
