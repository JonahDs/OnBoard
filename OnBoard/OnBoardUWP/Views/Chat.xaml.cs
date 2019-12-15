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
    public sealed partial class Chat : Page
    {
        private HomepageViewModel homepage;
        private ChatViewModel chatmodel;
        private bool isCrewmember = false;
        private bool sendAll = false;

        public Chat()
        {
            homepage = App.HomepageModel;
            if (ReferenceEquals(homepage.Seat, null))
            {
                ///A crewmember is logged
                chatmodel = new ChatViewModel(homepage.CrewMember, homepage.Flight.Seats);
                isCrewmember = true;
            }
            else
            {
                chatmodel = new ChatViewModel(homepage.Seat.User);

            }
            this.InitializeComponent();
        }


        public void SendButton_Click(object sender, RoutedEventArgs args)
        {
            if (isCrewmember == true)
            {
                chatmodel.SendMessage(messageTextBox.Text, homepage.CrewMember, sendAll);
            }
            else
            {
                chatmodel.SendMessage(messageTextBox.Text, homepage.Seat.User, sendAll);
            }
        }

        public void DestinatorSet(object sender, SelectionChangedEventArgs args)
        {
            var selectedUser = args.AddedItems[0];
            chatmodel.SetMessageDestinator((User)selectedUser);
        }

        public void CheckboxClicked(object sender, RoutedEventArgs args)
        {
            CheckBox c = sender as CheckBox;
            if(c.IsChecked == true)
            {
                sendAll = true;
            }
            else
            {
                sendAll = false;
            }
        }


    }

}
