using OnBoardAPI.Models.Enums;
using System.Collections.Generic;

namespace OnBoardAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Passenger Passenger { get; set; }

        public OrderState OrderState { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }
    }
}