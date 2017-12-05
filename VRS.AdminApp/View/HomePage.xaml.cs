using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using VRS.AdminApp.Controller;
using VRS.AdminApp.Model;
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
        ObservableCollection<Rent> rents;
        ObservableCollection<User> users;
        ObservableCollection<Vehicle> vehicles;
        ObservableCollection<Client> clients;

        public HomePage()
        {
            this.InitializeComponent();
            controller = new HomeController();
        }

        private void RootPivot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var pivot = (PivotItem)(sender as Pivot).SelectedItem;
            switch (pivot.Header.ToString())
            {
                case "Rents":
                     LoadRents(false);
                    break;
                case "Users":
                    LoadUsers(false);
                    break;
                case "Vehicles":
                    LoadVehicles(false);
                    break;
                case "Clients":
                    LoadClients(false);
                    break;
            }
        }

        private async void LoadClients(bool isUpdate)
        {
            if (clients != null && !isUpdate)
            {
                return;
            }

            clients = new ObservableCollection<Client>(await controller.GetClients());
            clientsListView.ItemsSource = clients;
        }

        private async void LoadVehicles(bool update)
        {
            if (vehicles != null && !update)
            {
                return;
            }

            vehicles = new ObservableCollection<Vehicle>(await controller.GetVehicles());
            vehilesListView.ItemsSource = vehicles;
        }

        private async void LoadUsers(bool update)
        {
            if (users != null && !update)
            {
                return;
            }

            users = new ObservableCollection<User>(await controller.GetUsers());
            usersListView.ItemsSource = users;
        }

        private async void LoadRents(bool update)
        {
            if (rents != null && !update)
            {
                return;
            }

            rents = new ObservableCollection<Rent>(await controller.GetRents());
            rentsListView.ItemsSource = rents;
        }

        private async void RentsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Finish rental?",
                Content = "This will register the car as available.",
                CloseButtonText = "Cancel",
                PrimaryButtonText = "Yes"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
    }
}
