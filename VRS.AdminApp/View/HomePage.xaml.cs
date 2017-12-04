using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VRS.AdminApp.Controller;
using VRS.AdminApp.VRSServiceReference;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace VRS.AdminApp.View
{
    public sealed partial class HomePage : Page
    {
        HomeController controller;

        public HomePage()
        {
            this.InitializeComponent();
            controller = new HomeController();
            
            var rents = controller.GetRents();
            rentsListView.ItemsSource = rents;
        }
    }
}
