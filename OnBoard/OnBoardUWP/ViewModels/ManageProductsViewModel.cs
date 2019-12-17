using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    class ManageProductsViewModel : BindableBase
    {
        private ObservableCollection<Product> _products;
        public ObservableCollection<Product> Products { get { return this._products; } set { Set(ref _products, value); } }

        private HttpClient client = new HttpClient();

        public RelayCommand SaveChangesCommand { get; set; }
        
        private Dictionary<int, double> productsWithPercentage = new Dictionary<int, double>();

        public ManageProductsViewModel()
        {
            GetProducts();
            SaveChangesCommand = new RelayCommand(_ => SaveChanges());
        }

        public async void GetProducts()
        {
            var list = await GlobalMethods.ApiCall<List<Product>>("http://localhost:50236/api/product", client);
            Products = new ObservableCollection<Product>(list);
        }

        public bool ResetProductAndPercentage(int productId, double percentage)
        {
            if(percentage > 100)
            {
                return false;
            }
            if (productsWithPercentage.ContainsKey(productId))
            {
                productsWithPercentage.Remove(productId);
            }
            productsWithPercentage.Add(productId, percentage);
            return true;
        }

        public async void SaveChanges()
        {
            var tasks = new List<Task>();
            productsWithPercentage.ToList().ForEach(async t =>
            {
                tasks.Add(ChangeSalePrice(t.Key, t.Value));
            });
            await Task.WhenAll(tasks);
            GetProducts();
        }

        private async Task ChangeSalePrice(int productid, double percentage)
        {
            try
            {
                Uri uri = new Uri($"http://localhost:50236/api/product/products/{productid}/sale{percentage}");

                HttpStringContent content = new HttpStringContent("", encoding: Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType: "application/json");
                HttpResponseMessage responseMessage = await client.PutAsync(uri, content);
                responseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                ShowMessageDialog("Something went wrong while saving, try again!");
            }
        }

        private async void ShowMessageDialog(string text)
        {
            var messageDialog = new MessageDialog(text);
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.Commands.Add(new UICommand("Close"));
            await messageDialog.ShowAsync();
        }
    }
}
