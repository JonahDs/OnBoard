using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class ShoppingCartViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();

        private ObservableCollection<OrderDetail> _orderedProducts;
        public ObservableCollection<OrderDetail> OrderedProducts { get { return this._orderedProducts; } set { Set(ref _orderedProducts, value); } }

        public User LoggedUser { get; set; }

        private double _totalPrice;
        public double TotalPrice { get { return this._totalPrice; } set { Set(ref _totalPrice, value); } }

        public ShoppingCartViewModel(User loggedUser)
        {
            LoggedUser = loggedUser;
            OrderedProducts = new ObservableCollection<OrderDetail>();
            TotalPrice = 0;
        }

        public void groupProducts(ObservableCollection<Product> products)
        {
            products.ToList().ForEach(p =>
            {
                var product = OrderedProducts.Where(r => r.Product.ProductId == p.ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.OrderedAmount++;
                }
                else
                {
                    var od = new OrderDetail
                    {
                        Product = p,
                        OrderedAmount = 1
                    };
                    OrderedProducts.Add(od);
                }
            });
            getTotalPrice();
        }

        public void getTotalPrice()
        {
            var price = 0.00;
            OrderedProducts.ToList().ForEach(p =>
            {
                price = p.Product.ProductPrice * p.OrderedAmount;
                TotalPrice += price;
            });
        }

        public async void placeOrder()
        {
            Order orderdto = new Order()
            {
                Passenger = LoggedUser,
                OrderState = "Pending",
                OrderDetails = OrderedProducts
            };
            try
            {
                Uri uri = new Uri($"http://localhost:50236/api/order/place/{orderdto}");
                var jsonString = JsonConvert.SerializeObject(orderdto);

                HttpStringContent content = new HttpStringContent(jsonString, encoding: Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType: "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(uri, content);
                responseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
            App.FoodViewModel.SelectedProducts.Clear();
        }
    }
}
