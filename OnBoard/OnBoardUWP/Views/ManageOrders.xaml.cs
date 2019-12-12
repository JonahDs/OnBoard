using OnBoardUWP.Models;
using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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

namespace OnBoardUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ManageOrders : Page
    {
        OrderHistoryViewModel viewmodel = new OrderHistoryViewModel();
        public ManageOrders()
        {
            viewmodel.GetAllOrders();
            this.InitializeComponent();
        }

        private void ToggleFlipped(object sender, RoutedEventArgs args)
        {
            ToggleSwitch toggle = sender as ToggleSwitch;
            int tag = (int)toggle.Tag;
            if (toggle.IsOn)
            {
                viewmodel.UpdateOrderState(tag, toggle.OnContent.ToString());
            } else
            {
                viewmodel.UpdateOrderState(tag, toggle.OnContent.ToString());
            }
        }
    }
}
