using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManagingSeats : Page
    {
        HomepageViewModel homepageViewModel;
        SeatViewModel seatViewModel;

        ICollection<int> selectedSeats = new List<int>();
        public ManagingSeats()
        {
            homepageViewModel = App.HomepageModel;
            seatViewModel = new SeatViewModel();
            this.InitializeComponent();
        }

        private async void SelectedUser(object sender, RoutedEventArgs e)
        {
            var seatNr = Convert.ToInt16((sender as CheckBox).Tag);
            if (selectedSeats.Count < 2 && (sender as CheckBox).IsChecked == true)
            {
                selectedSeats.Add(seatNr);
            }
            else
            {
                var messageDialog = new MessageDialog("You can only select 2 passangers so switch seats.");
                messageDialog.Commands.Add(new UICommand("Ok"));
                messageDialog.Commands.Add(new UICommand("Close"));

                //Uncheck the falsly checked button
                (sender as CheckBox).IsChecked = false;
                await messageDialog.ShowAsync();
            }
        }

        private void DeselectUser(object sender, RoutedEventArgs e)
        {
            selectedSeats.Remove(Convert.ToInt16((sender as CheckBox).Tag));
        }

        private void Switch(object sender, RoutedEventArgs e)
        {
            seatViewModel.SwitchUsersWithId(selectedSeats as List<int>);
        }

    }
}

