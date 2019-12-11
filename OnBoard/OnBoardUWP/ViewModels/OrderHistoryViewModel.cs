using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class OrderHistoryViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();

        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders{ get { return this._orders; } set { Set(ref _orders, value); } }

        public User LoggedUser { get; set; }

        public OrderHistoryViewModel(User loggedUser)
        {
            LoggedUser = loggedUser;
            Orders = new ObservableCollection<Order>();
            GetOrders();
        }

        /// <summary>
        /// Calls the api for the orders from the passenger
        /// </summary>
        /// <returns></returns>
        private async void GetOrders()
        {
            var userId = LoggedUser.Id;
            Uri requestUri = new Uri($"http://localhost:50236/api/order/orders/{userId}");

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {
                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<ObservableCollection<Order>>(httpResponseBody);
                data.ToList().ForEach(o =>
                {
                    Orders.Add(o);
                    //Order order = new Order()
                    //{
                    //    Passenger = o.Passenger,
                    //    OrderState = o.OrderState
                    //};

                    //ICollection<OrderDetail> orderDetails = new Collection<OrderDetail>();
                    //o.OrderDetails.ToList().ForEach(od =>
                    //{
                    //    orderDetails.Add(new OrderDetail()
                    //    {
                    //        OrderedAmount = od.OrderedAmount,
                    //        Product = od.Product
                    //    });
                    //});
                    //order.OrderDetails = orderDetails;
                    //Orders.Add(order);
                });
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
        }
    }
}
