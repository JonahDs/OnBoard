using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.ViewModels
{
    public class FoodViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        public ObservableCollection<Product> Products { get; set; }
        //public IEnumerable<Product> ProductsOnSale => Products?.Where(p => p.Sale > 0);
        public ObservableCollection<Product> ProductsOnSale { get; set; }

        private Product _product;
        public Product Product { get { return this._product; } set { Set(ref _product, value); } }

        /// <summary>
        /// Constructor that calls getProducts() method
        /// </summary>
        public FoodViewModel()
        {
            Products = new ObservableCollection<Product>();
            ProductsOnSale = new ObservableCollection<Product>();
            GetProducts();
        }
        

        /// <summary>
        /// Calls the api for the products
        /// </summary>
        /// <returns></returns>
        private async void GetProducts()
        {
            Uri requestUri = new Uri("http://localhost:50236/api/product");

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {

                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ObservableCollection<Product>>(httpResponseBody);
                foreach (Product prod in data)
                {
                    Products.Add(prod);
                }
                foreach (Product p in Products) if (p.Sale > 0)
                {
                    ProductsOnSale.Add(p);
                }
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }

        }
    }
}
