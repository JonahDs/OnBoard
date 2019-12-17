using OnBoardUWP.Models;
using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace OnBoardUWP.Views
{
    public sealed partial class MusicPlayer : Page
    {
        public MusicPlayerViewModel vm;
        public MusicPlayer()
        {
            this.InitializeComponent();
            vm = new MusicPlayerViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            base.OnNavigatedTo(e);
            vm.Playlist = (Playlist)e.Parameter;                   
        }

        private async void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {
                mediaSimple.Source = new Uri(((Music)e.ClickedItem).Link);
            }
            catch
            {
                await new MessageDialog("The selected song could not be found").ShowAsync();
            }
            
        }
    }
}
