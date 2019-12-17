using OnBoardUWP.ViewModels;
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
    public sealed partial class Login : Page
    {
        HomepageViewModel homepage;
        public Login()
        {
            homepage = App.HomepageModel;
            this.InitializeComponent();
        }
        
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            homepage.IsLoading = true;
            try
            {
                await homepage.GetSeatInstance(int.Parse(seatNumber.Text));
            }
            catch (Exception ex)
            {
                homepage.IsLoading = false;
                await new MessageDialog(ex.Message, "Sorry, we coudn't fetch any account with given information :(").ShowAsync();
                return;
            }
            homepage.IsLoading = false;
            Frame.Navigate(typeof(Navigation));
        }

        public async void ButtonAir_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await homepage.GetCrewMemberInstance(int.Parse(hostedId.Text));
            }
            catch (Exception ex)
            {
                await new MessageDialog(ex.Message, "Sorry, we coudn't fetch any account with given information :(").ShowAsync();
                return;
            }
            Frame.Navigate(typeof(CrewNavigation));

        }

        private void Textbox_BeforeChange(object sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }

    }
}
