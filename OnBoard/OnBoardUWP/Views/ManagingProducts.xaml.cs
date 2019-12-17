using OnBoardUWP.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
    public sealed partial class ManagingProducts : Page
    {
        ManageProductsViewModel viewmodel;
        public ManagingProducts()
        {
            viewmodel = new ManageProductsViewModel();
            this.InitializeComponent();
        }

        public async void PercentageEntered(object sender, TextChangedEventArgs args)
        {

            TextBox text = sender as TextBox;
            var percentage = text.Text;
            if (percentage != "")
            {
                int productId = (int)text.Tag;
                bool succes = false;
                try
                {
                    succes = viewmodel.ResetProductAndPercentage(productId, Convert.ToDouble(percentage));
                }
                catch
                {
                    await new MessageDialog("Invalid input").ShowAsync();
                }

                if (!succes)
                {
                    await new MessageDialog("We are sorry", "You have entered a percentage higher than 100! Reconsider your choice").ShowAsync();
                    text.Text = "0";
                }
            }
        }


        private void Textbox_BeforeChange(object sender, TextBoxBeforeTextChangingEventArgs args)
        {
            args.Cancel = args.NewText.Any(c => !char.IsDigit(c));
        }
    }
}
