using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class PassengerGroup
    {
        public IEnumerable<Passenger> Passengers { get; set; }

        public PassengerGroup()
        {
            Passengers = new List<Passenger>();
        }
    }
}
