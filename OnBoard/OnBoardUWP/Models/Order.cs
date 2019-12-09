using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Order
    {
        public User Passenger { get; set; }

        public string OrderState { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}
