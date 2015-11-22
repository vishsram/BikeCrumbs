using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.WindowsAzure.MobileServices;


namespace TrackPhone
{
    public partial class Login : PhoneApplicationPage
    {
        public Login()
        {
            InitializeComponent();
        }
        async private void MSLoginButton_Click(object sender, RoutedEventArgs e)
        {
            await Authorize(MobileServiceAuthenticationProvider.MicrosoftAccount);
        }

        async private void TwitterLoginButton_Click(object sender, RoutedEventArgs e)
        {
            await Authorize(MobileServiceAuthenticationProvider.Twitter);
        }

        async private void GoogleLoginButton_Click(object sender, RoutedEventArgs e)
        {
            await Authorize(MobileServiceAuthenticationProvider.Google);
        }

        async private void FBLoginButton_Click(object sender, RoutedEventArgs e)
        {
            await Authorize(MobileServiceAuthenticationProvider.Facebook);
        }

        async private System.Threading.Tasks.Task Authorize(MobileServiceAuthenticationProvider mobileServiceAuthenticationProvider)
        {
            string message;
            try
            {
                var user = await App.MobileService.LoginAsync(mobileServiceAuthenticationProvider);
                if (user != null)
                {
                    message =
                        string.Format("You are now logged in - {0}", user.UserId);
                    MessageBox.Show(message);
                    
                    //var d = new MessageBox.Show(message);
                    //await d.ShowAsync();
                }
            }
            catch { message = "You must log in. Login Required"; MessageBox.Show(message); }

        }

    }
}