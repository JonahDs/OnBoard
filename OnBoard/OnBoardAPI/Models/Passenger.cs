using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class Passenger: User
    {
        public int SeatNumber { get; set; }
        public long BookingNr { get; set; }
    }
}
