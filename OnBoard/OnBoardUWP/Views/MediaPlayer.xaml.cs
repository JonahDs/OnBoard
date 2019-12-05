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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace OnBoardUWP.Views
{
    public sealed partial class MediaPlayer : Page
    {
        public MediaPlayerViewModel vm;
        public MediaPlayer()
        {
            this.InitializeComponent();
            vm = new MediaPlayerViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {   
            base.OnNavigatedTo(e);
            vm.Playlist = (Playlist)e.Parameter;
        }

        private void ListView_ItemClick(object sender, ItemClickEventArgs e)
        {   
            //mediaSimple.MediaPlayer.AutoPlay = true;
        }
    }
}
