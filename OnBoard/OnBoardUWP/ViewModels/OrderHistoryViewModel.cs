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
        public ObservableCollection<Order> Orders { get { return this._orders; } set { Set(ref _orders, value); } }

        public User LoggedUser { get; set; }

        public OrderHistoryViewModel()
        {
            Orders = new ObservableCollection<Order>();
        }

        /// <summary>
        /// Calls the api for the orders from the passenger
        /// </summary>
        /// <returns></returns>
        public async void GetOrdersFromUser(User loggedUser)
        {
            try
            {
                Orders = await GlobalMethods.ApiCall<ObservableCollection<Order>>($"http://localhost:50236/api/order/orders/{loggedUser.Id}", client);
            }
            catch { }

        }

        public async void GetAllOrders()
        {
            try
            {
                Orders = await GlobalMethods.ApiCall<ObservableCollection<Order>>("http://localhost:50236/api/order/orders", client);
            }
            catch { }
        }

        public async void UpdateOrderState(int orderId, string state)
        {
            try
            {
                Uri uri = new Uri($"http://localhost:50236/api/order/updateState/{orderId}/{state}");

                HttpStringContent content = new HttpStringContent("", encoding: Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType: "application/json");
                HttpResponseMessage responseMessage = await client.PutAsync(uri, content);
                responseMessage.EnsureSuccessStatusCode();
            }
            catch (Exception)
            {
                //throw;
            }
        }
    }
}
