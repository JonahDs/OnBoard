using OnBoardAPI.Models;
using OnBoardAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.DTO
{
    public class OrderDTO
    {
        public Passenger Passenger { get; set; }

        public OrderState OrderState { get; set; }

        public IEnumerable<OrderDetailDTO> OrderDetails { get; set; }
    }
}
