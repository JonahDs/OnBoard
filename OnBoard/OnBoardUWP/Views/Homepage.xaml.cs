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


namespace OnBoardUWP.Views
{

    public sealed partial class Homepage : Page
    {
        
        public HomepageViewModel ViewModel;

        public Homepage()
        {
            this.InitializeComponent();
            // Using the, in app.cs initialized, viewmodel for databinding
            ViewModel = App.HomepageModel;
            
        }

        private void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            mainSplitView.IsPaneOpen = !mainSplitView.IsPaneOpen;
        }

        
    }
}
