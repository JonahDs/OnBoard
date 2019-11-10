using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.ViewModels
{
    /// <summary>
    /// Provides data accessible to the entire app
    /// </summary>
    public class HomepageViewModel : BindableBase
    {
        private Flight _flight;

        public Flight Flight {
            get {
                return _flight;
            }
            set {
                Set(ref _flight, value);
            }
        }

        private HttpClient client = new HttpClient();

        /// <summary>
        /// Creates a viewmodel and seeding the flight property
        /// </summary>
        public HomepageViewModel() => GetFlightInformation();

        /// <summary>
        /// Calls the api for a flight object, making sure the call succeeds to only work with 20X messages
        /// </summary>
        /// <returns></returns>
        private async void GetFlightInformation()
        {
            Uri requestUri = new Uri("http://localhost:50236/api/flight");

            HttpResponseMessage httpResponse = new HttpResponseMessage();
            string httpResponseBody = "";

            try
            {   

                httpResponse = await client.GetAsync(requestUri);
                httpResponse.EnsureSuccessStatusCode();
                httpResponseBody = await httpResponse.Content.ReadAsStringAsync();
                Flight = JsonConvert.DeserializeObject<Flight>(httpResponseBody);
            }
            catch (Exception ex)
            {
                httpResponseBody = "Error: " + ex.HResult.ToString("X") + " Message: " + ex.Message;
            }
           
        }
    }
}
