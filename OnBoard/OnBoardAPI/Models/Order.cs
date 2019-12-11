using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using OnBoardAPI.Models.Enums;
using System.Collections.Generic;

namespace OnBoardAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public Passenger Passenger { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public OrderState OrderState { get; set; }

        public IEnumerable<OrderDetail> OrderDetails { get; set; }
    }
}