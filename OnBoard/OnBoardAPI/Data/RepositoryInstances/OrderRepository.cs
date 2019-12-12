using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.RepositoryInstances
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Context _context;
        private readonly DbSet<Order> _orders;

        public OrderRepository(Context context)
        {
            _context = context;
            _orders = context.Order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders.Include(o => o.OrderDetails).ThenInclude(o => o.Product).ToList();
        }

        public Order GetOrderById(int orderId)
        {
            return _orders.FirstOrDefault(t => t.OrderId == orderId);
        }

        public IEnumerable<Order> GetOrdersByUserId(int userId)
        {
            return _orders.Where(o => o.Passenger.Id == userId).Include(o => o.OrderDetails).ThenInclude(o => o.Product).ToList();
        }

        public void PlaceOrder(Order order)
        {
            _orders.Add(order);
            _context.SaveChanges();
        }

        public void updatedOrderState(Order o)
        {
            _context.Update(o);
            _context.SaveChanges();
        }
    }
}
