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
    public sealed partial class Navigation : Page
    {
        public Navigation()
        {
            this.InitializeComponent();
            mainFrame.Navigate(typeof(Homepage));
        }

        private void NavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            NavigationViewItem selectedItem = (NavigationViewItem)args.SelectedItem;

            string selectedTag = selectedItem.Tag.ToString();

            switch (selectedTag)
            {
                case "home":
                    mainFrame.Navigate(typeof(Homepage), null, new DrillInNavigationTransitionInfo());
                    break;
                case "food":
                    mainFrame.Navigate(typeof(Food), null, new EntranceNavigationTransitionInfo());
                    break;
                case "movies":
                    mainFrame.Navigate(typeof(Movies), null, new DrillInNavigationTransitionInfo());
                    break;
                case "music":
                    mainFrame.Navigate(typeof(MusicPlaylists), null, new DrillInNavigationTransitionInfo());
                    break;
                case "chat":
                    mainFrame.Navigate(typeof(Chat), null, new DrillInNavigationTransitionInfo());
                    break;
            }
        }


        private void nav_Loaded(object sender, RoutedEventArgs e)
        {
            nav.IsPaneOpen = false;
        }
    }
}
