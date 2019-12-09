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
        void PlaceOrder(Order order);
    }
}
