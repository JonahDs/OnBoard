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
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CrewNavigation : Page
    {
        public CrewNavigation()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(ManageOrders), null, new DrillInNavigationTransitionInfo());
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem selectedItem = (NavigationViewItem)args.SelectedItem;

            string selectedTag = selectedItem.Tag.ToString();

            switch (selectedTag)
            {
                case "seats":
                    mainFrame.Navigate(typeof(ManagingSeats), null, new DrillInNavigationTransitionInfo());
                    break;
                case "orders":
                    mainFrame.Navigate(typeof(ManageOrders), null, new DrillInNavigationTransitionInfo());
                    break;
                case "chat":
                    mainFrame.Navigate(typeof(Chat), null, new DrillInNavigationTransitionInfo());
                    break;
                case "products":
                    mainFrame.Navigate(typeof(ManagingProducts), null, new DrillInNavigationTransitionInfo());

                    break;

            }
        }

        private void nav_Loaded(object sender, RoutedEventArgs e)
        {
            nav.IsPaneOpen = false;
        }
    }
}
