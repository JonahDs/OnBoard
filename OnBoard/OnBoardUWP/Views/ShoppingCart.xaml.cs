using OnBoardUWP.Models;
using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public sealed partial class ShoppingCart : Page
    {
        public ShoppingCartViewModel viewModel;

        public ShoppingCart()
        {
            viewModel = new ShoppingCartViewModel(App.HomepageModel.Seat.User);
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            viewModel.groupProducts(App.FoodViewModel.SelectedProducts);
            base.OnNavigatedTo(e);
        }

        private void goBackToCatalog(object sender, RoutedEventArgs e)
        {
            this.shoppingcartFrame.Navigate(typeof(Food));
        }

        private async void placeOrder(object sender, RoutedEventArgs e)
        {
            viewModel.placeOrder();
            this.shoppingcartFrame.Navigate(typeof(Food));
            await new MessageDialog("", "Your order has been placed!").ShowAsync();
        }
    }
}
