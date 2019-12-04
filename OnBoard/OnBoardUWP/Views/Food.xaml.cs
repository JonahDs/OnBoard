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
    public sealed partial class Food : Page
    {
        public FoodViewModel viewModel;

        //private int _numValue = 0;

        //public int NumValue {
        //    get { return _numValue; }
        //    set {
        //        _numValue = value;
        //    }
        //}

        public Food()
        {
            viewModel = new FoodViewModel();
            this.InitializeComponent();
        }

        private void BGRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;
            string foodCategory = rb.Tag.ToString();
            viewModel.FilterProducts(foodCategory);
            this.UpdateLayout();
        }

        //private void quantity_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    TextBox tb = sender as TextBox;
        //    if (tb.Text == null)
        //    {
        //        return;
        //    }

        //    if (!int.TryParse(tb.Text, out _numValue))
        //        tb.Text = _numValue.ToString();
        //}

        //private void cmdUp_Click(object sender, RoutedEventArgs e)
        //{
        //    Button bt = sender as Button;
        //    var id = Convert.ToInt32(bt.Tag.ToString());
        //    viewModel.AddQuantity(id);
        //    this.UpdateLayout();
        //}

        //private void cmdDown_Click(object sender, RoutedEventArgs e)
        //{
        //    NumValue--;
        //}

        private void AddProduct(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            var productId = Convert.ToInt32(bt.Tag.ToString());
            viewModel.AddProductToBasket(productId);
        }

        private void ToShoppingCart(object sender, RoutedEventArgs e)
        {
            this.foodFrame.Navigate(typeof(ShoppingCart), viewModel);
        }
    }
}
