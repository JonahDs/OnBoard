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
                Product chocolateBar = new Product { ProductName = "Chocolate Bar", ProductPrice = 5.00, ProductType = ProductType.Snack, ProductDescription = "Sweet Chocolate", ImageUrl = "https://5.imimg.com/data5/JT/VB/MY-33382055/brown-chocolate-bar-500x500.jpg" };

                Product apple = new Product { ProductName = "Apple", ProductPrice = 100.00, ProductType = ProductType.Snack, ProductDescription = "Appel kut", Sale = 20, SalePrice = 80.00, ImageUrl = "https://www.lekkervanbijons.be/sites/default/files/styles/large/public/sp_image/kanzi_appel_4_0.jpg?itok=NO3Ad1rZ" };

                Product hamburgerWithFries = new Product { ProductName = "Hamburger with fries", ProductPrice = 12.50, ProductType = ProductType.Dinner, ProductDescription = "Dikke hamburger junge", ImageUrl = "https://www.lekkervanbijons.be/sites/default/files/styles/large/public/sp_image/kanzi_appel_4_0.jpg?itok=NO3Ad1rZ" };

                Product pear = new Product { ProductName = "Pear", ProductPrice = 10.00, ProductType = ProductType.Snack, ProductDescription = "Peer kut", Sale = 30, SalePrice = 7.00, ImageUrl = "https://debuurman.nu/wp-content/uploads/2019/02/conferance-peer-600x600.jpg" };

                Product spaghetti = new Product { ProductName = "Spaghetti", ProductPrice = 12.50, ProductType = ProductType.Dinner, ProductDescription = "Somebody toucha my spaghet", ImageUrl = "https://www.lekkervanbijons.be/sites/default/files/styles/large/public/sp_image/kanzi_appel_4_0.jpg?itok=NO3Ad1rZ" };

                Product cheesecake = new Product { ProductName = "Cheesecake", ProductPrice = 8.50, ProductType = ProductType.Snack, ProductDescription = "Cheesy", ImageUrl = "https://www.lekkervanbijons.be/sites/default/files/styles/large/public/sp_image/kanzi_appel_4_0.jpg?itok=NO3Ad1rZ" };


                IEnumerable<Product> products = new List<Product> { apple, hamburgerWithFries, chocolateBar, pear, spaghetti, cheesecake };
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
