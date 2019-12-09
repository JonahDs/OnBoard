using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class OrderDetail
    {
        public Product Product { get; set; }

        public Order Order { get; set; }

        public int ProductId { get; set; }

        public int OrderId { get; set; }

        public int OrderedAmount { get; set; }

        public OrderDetail() { }

        public OrderDetail(Order order, Product product, int orderedAmount)
        {
            OrderId = order.OrderId;
            ProductId = product.ProductId;
            Order = order;
            Product = Product;
            OrderedAmount = orderedAmount;
        }
    }
}
