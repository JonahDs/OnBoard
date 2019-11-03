using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class UserFlight
    {
        public Flight Flight { get; set; }

        public int FlightId { get; set; }

        public User User { get; set; }

        public int UserId { get; set; }

        public int SeatNumber { get; set; }
    }
}
