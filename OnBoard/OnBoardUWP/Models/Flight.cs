using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Flight 
    {
        public IEnumerable<Seat> Seats { get; set; }

        public int FlightId { get; set; }

        public string FlightName { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime EstimatedArrival { get; set; }

        public string Destination { get; set; }

        public Flight()
        {
            Seats = new List<Seat>();
        }
    }
}
