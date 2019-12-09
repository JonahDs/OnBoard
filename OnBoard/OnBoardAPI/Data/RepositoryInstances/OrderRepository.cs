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
            return _orders.ToList();
        }

        public void PlaceOrder(Order order)
        {
            _orders.Add(order);
            _context.SaveChanges();
        }
    }
}
