using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VRS.AdminApp.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
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
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CreateRentPage : Page
    {
        CreateRentPageController controller;
        private Rent rent;
        List<Client> clients;
        private Vehicle vehicle;
        private double price;

        public CreateRentPage()
        {
            this.InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested +=
            App_BackRequested;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            controller = new CreateRentPageController();
            vehicle = (Vehicle) e.Parameter;
            tbPlate.Text = vehicle.Plate;

            if (Frame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }
        }

        private async void BtSearchClient_Click(object sender, RoutedEventArgs e)
        {
            var clientName = tbClientName.Text;
            if (string.IsNullOrEmpty(clientName))
            {
                return;
            }

            clients = (await controller.GetUsersForName(clientName)).ToList();
            cbClient.ItemsSource = clients.Select(x => x.Name+" "+x.Surname);
            if (clients.Count() > 0)
            {
                cbClient.SelectedIndex = 0;
            }
        }

        private void DateChanged(object sender, DatePickerValueChangedEventArgs e)
        {
            double days = (dpEnd.Date - dpStart.Date).TotalDays;
            price = 100 * ((int) days);
            tbPrice.Text = "Price: " +price+ " EUR";
        }

        private async void CreateRentClick(object sender, RoutedEventArgs e)
        {
            rent = new Rent();
            rent.VehicleId = vehicle.Id;
            rent.StartDate = dpStart.Date.Date;
            rent.FinishDate = dpEnd.Date.Date;
            rent.Finished = false;
            rent.ClientId = clients[cbClient.SelectedIndex].Id;
            rent.Price = price;

            var successful = await controller.CreateRent(rent);
            if (successful){
                Frame.GoBack();
            }
        }

        private void App_BackRequested(object sender,
        Windows.UI.Core.BackRequestedEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;
            if (rootFrame == null)
                return;

            // Navigate back if possible, and if the event has not 
            // already been handled .
            if (rootFrame.CanGoBack && e.Handled == false)
            {
                e.Handled = true;
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
                rootFrame.GoBack();
            }
        }
    }
}
