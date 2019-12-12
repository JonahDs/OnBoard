using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetAll();
        IEnumerable<Order> GetOrdersByUserId(int userId);
        void PlaceOrder(Order order);
        Order GetOrderById(int orderId);
        void updatedOrderState(Order o);
    }
}
