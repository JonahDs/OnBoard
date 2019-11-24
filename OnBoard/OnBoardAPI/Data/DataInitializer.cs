using Microsoft.AspNetCore.Identity;
using OnBoardAPI.Models;
using OnBoardAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data
{
    public class DataInitializer
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _manager;

        public DataInitializer(Context context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                #region Products
                Product chocolateBar = new Product { ProductName = "Chocolate Bar", ProductPrice = 5.00, ProductType = ProductType.Snack, ProductDescription = "Sweet Chocolate", Sale = 0 };

                Product apple = new Product { ProductName = "Apple", ProductPrice = 100.00, ProductType = ProductType.Snack, ProductDescription = "Appel kut", Sale=20 };

                Product hamburgerWithFries = new Product { ProductName = "Hamburger with fries", ProductPrice = 12.50, ProductType = ProductType.Dinner, ProductDescription = "Dikke hamburger junge" };


                IEnumerable<Product> products = new List<Product> { apple, hamburgerWithFries, chocolateBar };
                _context.Product.AddRange(products);
                #endregion

                #region PassangerGroups
                PassengerGroup group1 = new PassengerGroup();
                #endregion

                #region Passangers
                IList<Passenger> passengers;
                User passenger1 = new Passenger
                {
                    BookingNr = 95120659,
                    Firstname = "Jonah",
                    Name = "De Smet"
                };

                User passenger2 = new Passenger
                {
                    BookingNr = 95120659,
                    Firstname = "Johanna",
                    Name = "De Bruycker"
                };

                User passenger3 = new Passenger
                {
                    BookingNr = 95120659,
                    Firstname = "Bram",
                    Name = "De Bleecker"
                };

                passengers = new List<Passenger> { (Passenger)passenger1, (Passenger)passenger2, (Passenger)passenger3 };
                #endregion

                // Adding the passangers to passenger groups
                group1.Passengers = passengers;

                #region Seats
                IList<Seat> seats;
                Seat s1p1 = new Seat
                {
                    SeatNumber = 1,
                    User = passenger1
                };

                Seat s2p2 = new Seat
                {
                    SeatNumber = 2,
                    User = passenger2
                };

                Seat s3p3 = new Seat
                {
                    SeatNumber = 3,
                    User = passenger3
                };
                seats = new List<Seat> { s1p1, s2p2, s3p3 };
                #endregion

                #region Flight
                Flight Flight = new Flight
                {
                    FlightName = "Brussels Airlines 747",
                    Arrival = new DateTime(2019, 09, 13),
                    Departure = DateTime.Today,
                    Destination = "Bonaire",
                    EstimatedArrival = new DateTime(2019, 09, 13, 5, 2, 00),
                    Seats = seats
                };
                #endregion

                // Adding the seats to the flight

                _context.Flight.Add(Flight);

                await _context.SaveChangesAsync();
            }
        }
    }
}
