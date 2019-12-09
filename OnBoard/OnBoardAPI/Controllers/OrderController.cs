using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.DTO;
using OnBoardAPI.Models;
using OnBoardAPI.Models.Enums;

namespace OnBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IUserRepository _userRepository;

        public OrderController(IOrderRepository orderRepository, IProductRepository productRepository, IUserRepository userRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _userRepository = userRepository;
        }

        /// <summary>
        /// Get all orders and return it with a 200 status code
        /// </summary>
        /// <returns></returns>
        [HttpGet("orders")]
        public ActionResult<IEnumerable<Order>> GetAllOrders()
        {
            return new OkObjectResult(_orderRepository.GetAll());
        }

        [HttpPost("place/{orderdto}")]
        public ActionResult PlaceOrder(OrderDTO orderdto)
        {
            Order order = new Order()
            {
                Passenger = _userRepository.GetUserWithId(orderdto.Passenger.Id),
                //(Passenger)orderdto.Passenger,
                OrderState = orderdto.OrderState
            };

            IList<OrderDetail> orderDetails = new List<OrderDetail>();
            orderdto.OrderDetails.ToList().ForEach(o =>
            {
                orderDetails.Add(new OrderDetail()
                {
                    Order = order,
                    Product = _productRepository.GetProductById(o.ProductId),
                    ProductId = o.ProductId,
                    OrderedAmount = o.OrderedAmount
                });
            });

            order.OrderDetails = orderDetails;
            _orderRepository.PlaceOrder(order);
            return Ok();
        }
    }
}