﻿using OnBoardUWP.Models;
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
    public sealed partial class Chat : Page
    {
        private HomepageViewModel homepage;
        private ChatViewModel chatmodel;

        public Chat()
        {
            homepage = App.HomepageModel;
            chatmodel = new ChatViewModel(homepage.Seat.User);
            this.InitializeComponent();
        }
        

        public void SendButton_Click(object sender, RoutedEventArgs args)
        {
            chatmodel.SendMessage(messageTextBox.Text, homepage.Seat.User);
        }

        public void DestinatorSet(object sender, SelectionChangedEventArgs args)
        {
            var selectedUser = args.AddedItems[0];
            chatmodel.SetMessageDestinator((User)selectedUser);
        }


    }

}
