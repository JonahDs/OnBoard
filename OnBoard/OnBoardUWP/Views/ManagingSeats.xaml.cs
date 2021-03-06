﻿using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
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

        //ICollection<int> selectedSeats = new List<int>();
        public ManagingSeats()
        {
            homepageViewModel = App.HomepageModel;
            seatViewModel = new SeatViewModel();
            DataContext = seatViewModel;
            this.InitializeComponent();
        }

        public void Refresh(object sender, RoutedEventArgs args)
        {
            homepageViewModel.Refresh();
        }

    }
}

