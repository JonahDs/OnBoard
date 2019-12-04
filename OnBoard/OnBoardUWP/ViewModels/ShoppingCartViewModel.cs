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
    public class ShoppingCartViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();

        private ObservableCollection<OrderDetail> _orderedProducts;
        public ObservableCollection<OrderDetail> OrderedProducts { get { return this._orderedProducts; } set { Set(ref _orderedProducts, value); } }

        private double _totalPrice;
        public double TotalPrice { get { return this._totalPrice; } set { Set(ref _totalPrice, value); } }

        public ShoppingCartViewModel()
        {
            OrderedProducts = new ObservableCollection<OrderDetail>();
            TotalPrice = 0;
        }

        public void groupProducts(ObservableCollection<Product> products)
        {
            products.ToList().ForEach(p =>
            {
                var product = OrderedProducts.Where(r => r.ProductId == p.ProductId).FirstOrDefault();
                if (product != null)
                {
                    product.OrderedAmount++;
                }
                else
                {
                    var od = new OrderDetail
                    {
                        Product = p,
                        ProductId = p.ProductId,
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
    }
}
