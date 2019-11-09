using OnBoardAPI.Models.Enums;

namespace OnBoardAPI.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public OrderState OrderState { get; set; }
    }
}