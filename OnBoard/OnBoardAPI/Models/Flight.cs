﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class Flight
    {
        public IEnumerable<Seat> Seats { get; set; }

        public int FlightId { get; set; }

        public string FlightName { get; set; }

        public DateTime Departure { get; set; }

        public DateTime Arrival { get; set; }

        public DateTime EstimatedArrival { get; set; }

        public string Origin { get; set; }

        public string Destination { get; set; }

        public double StartLatitude { get; set; }

        public double StartLongitude { get; set; }

        public double EndLatitude { get; set; }

        public double EndLongitude { get; set; }

        public Flight()
        {
            Seats = new List<Seat>();
        }
    }
}
