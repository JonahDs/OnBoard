using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public void SaveChanges()
        {
            productsWithPercentage.ToList().ForEach(async t =>
            {
                try
                {
                    Uri uri = new Uri($"http://localhost:50236/api/product/products/{t.Key}/sale{t.Value}");

                    HttpStringContent content = new HttpStringContent("", encoding: Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType: "application/json");
                    HttpResponseMessage responseMessage = await client.PutAsync(uri, content);
                    responseMessage.EnsureSuccessStatusCode();
                }
                catch (Exception)
                {
                    throw;
                }
            });

        }
    }
}
