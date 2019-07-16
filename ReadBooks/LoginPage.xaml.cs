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
                throw new Exception("There was an error logging you in");
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
