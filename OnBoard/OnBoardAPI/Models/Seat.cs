using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class Seat
    {
        public int SeatId { get; set; }

        public int SeatNumber { get; set; }

        public User User { get; set; }
    }
}
