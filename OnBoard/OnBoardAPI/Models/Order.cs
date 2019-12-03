using OnBoardAPI.Models.Enums;
using System.Collections.Generic;

namespace OnBoardAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public User User { get; set; }

        public OrderState OrderState { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}