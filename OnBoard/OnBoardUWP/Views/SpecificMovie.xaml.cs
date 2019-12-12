using OnBoardUWP.Models;
using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
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
    public sealed partial class SpecificMovie : Page
    {
        public MovieViewModel movieViewModel;

        public SpecificMovie()
        {
            this.InitializeComponent();
            movieViewModel = App.MovieViewModel;
            Movie m = movieViewModel.CurrentlyViewedMovie;
        }

        private void OpenMediaPlayer(object sender, RoutedEventArgs args)
        {
            if (!MoviePopup.IsOpen)
            {
                MoviePopup.IsOpen = true;
            }
        }

        private void BackToMovies(object sender, RoutedEventArgs e)
        {
            movieDetailFrame.Navigate(typeof(Movies));
        }
    }
}
