using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public User User { get; set; }

        public string OrderState { get; set; }
    }
}
