using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VRS.AdminApp.Controller;
using VRS.AdminApp.View;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace VRS.AdminApp
{
    public sealed partial class LoginPage : Page
    {
        LoginController controller;

        public LoginPage()
        {
            this.InitializeComponent();
            controller = new LoginController();

            imageBackground.Source = new BitmapImage(new Uri(this.BaseUri, "Assets/login_background.jpg"));
        }

        private async void BtLogin_Click(object sender, RoutedEventArgs e)
        {
            tbError.Text = "";

            var username = tbUsername.Text;
            var password = tbPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                tbError.Text = "Username and password are required";
                return;
            }

            var authenticated = await controller.VerifyUser(username, password);
            if (!authenticated)
            {
                tbError.Text = "Authentication failed";
                return;
            }

            var a = this.Frame.Name;
            this.Frame.Navigate(typeof(HomePage));
        }
    }
}
