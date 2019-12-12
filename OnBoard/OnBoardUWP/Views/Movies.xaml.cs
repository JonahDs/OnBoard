using OnBoardUWP.Models;
using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace OnBoardUWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Movies : Page
    {
        public MovieViewModel movieViewModel;
        public Movies()
        {
            movieViewModel = App.MovieViewModel;
            this.InitializeComponent();
        }

        /// <summary>
        /// gets called whenever the user clicks on one of the listed movies
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private async void MovieSelected(object sender, ItemClickEventArgs args)
        {
            // Fetch the rest of the movie details before navigating, task and await if needed to ensure this
            await movieViewModel.FetchMovieDetails(((Movie)args.ClickedItem).ImdbID);
            Frame.Navigate(typeof(SpecificMovie), null, new DrillInNavigationTransitionInfo());
        }

       

    }
}
