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
        private readonly DbSet<OrderDetail> _orderDetails;

        public OrderRepository(Context context)
        {
            _context = context;
            _orders = context.Order;
        }

        public IEnumerable<Order> GetAll()
        {
            return _orders.ToList();
        }

        public IEnumerable<Order> GetOrdersById(int userId)
        {
            //IEnumerable<Order> orders = _orders.Where(o => o.Passenger.Id == userId);
            //IList<OrderDTO> orderDTOs = new List<OrderDTO>();
            //orders.ToList().ForEach(order =>
            //{
            //    var orderdto = new OrderDTO()
            //    {
            //        Passenger = order.Passenger,
            //        OrderState = order.OrderState,
            //    };

            //    IList<OrderDetailDTO> orderDetailDTOs = new List<OrderDetailDTO>();
            //    order.OrderDetails.ToList().ForEach(orderdetail =>
            //    {
            //        OrderDetailDTO orderDetailDTO = new OrderDetailDTO()
            //        {
            //            OrderedAmount = orderdetail.OrderedAmount,
            //            Product = orderdetail.Product,
            //            ProductId = orderdetail.ProductId
            //        };
            //        orderDetailDTOs.Add(orderDetailDTO);
            //    });
            //    orderdto.OrderDetails = orderDetailDTOs;
            //    orderDTOs.Add(orderdto);
            //});

            //return orderDTOs;
            //_orderDetails.Where(o => o.Order.Passenger.Id == userId).Include(o => o.Product).Include(o => o.Order);
            return _orders.Where(o => o.Passenger.Id == userId).Include(o => o.OrderDetails).ThenInclude(o => o.Product).ToList();
        }

        public void PlaceOrder(Order order)
        {
            _orders.Add(order);
            _context.SaveChanges();
        }
    }
}
