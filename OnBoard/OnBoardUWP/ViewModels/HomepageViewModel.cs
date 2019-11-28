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

        public Flight Flight
        {
            get
            {
                return _flight;
            }
            set
            {
                Set(ref _flight, value);
            }
        }

        private Seat _seat;

        public Seat Seat
        {
            get
            {
                return _seat;
            }
            set
            {
                Set(ref _seat, value);
            }
        }

        private HttpClient client = new HttpClient();

        /// <summary>
        /// Creates a viewmodel and seeding the flight property
        /// </summary>
        public HomepageViewModel()
        {
            GetFlightInformation();
            GetSeatInstance();
        }

        /// <summary>
        /// Calls the api for a flight object, making sure the call succeeds to only work with 20X messages
        /// </summary>
        /// <returns></returns>
        private async void GetFlightInformation()
        {
            Flight = await GlobalMethods.ApiCall<Flight>("http://localhost:50236/api/flight", client);
        }

        public async void GetSeatInstance()
        {
            Seat = await GlobalMethods.ApiCall<Seat>("http://localhost:50236/api/user", client);
        }

        
    }
}
