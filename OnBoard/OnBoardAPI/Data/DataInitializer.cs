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
                Product chocolateBar = new Product { ProductName = "Chocolate Bar", ProductPrice = 5.00, ProductType = ProductType.Snacks, ProductDescription = "Sweet Chocolate", SalePrice = 5.00, ImageUrl = "http://assets.stickpng.com/thumbs/580b57fbd9996e24bc43c0d2.png" };

                Product apple = new Product { ProductName = "Apple", ProductPrice = 100.00, ProductType = ProductType.Snacks, ProductDescription = "Appel kut", Sale = 20, SalePrice = 80.00, ImageUrl = "https://gallery.yopriceville.com/var/resizes/Free-Clipart-Pictures/Fruit-PNG/Large_Red_Apple_PNG_Clipart.png?m=1507172114" };

                Product hamburgerWithFries = new Product { ProductName = "Hamburger with fries", ProductPrice = 12.50, ProductType = ProductType.Dinner, ProductDescription = "Dikke hamburger junge", SalePrice = 12.50, ImageUrl = "https://www.freepnglogos.com/uploads/burger-png/burger-png-the-eatery-steak-special-16.png" };

                Product pear = new Product { ProductName = "Pear", ProductPrice = 10.00, ProductType = ProductType.Snacks, ProductDescription = "Peer kut", Sale = 30, SalePrice = 7.00, ImageUrl = "https://www.pngarts.com/files/3/Sliced-Pear-PNG-Image-Background.png" };

                Product spaghetti = new Product { ProductName = "Spaghetti", ProductPrice = 12.50, ProductType = ProductType.Dinner, ProductDescription = "Somebody toucha my spaghet", SalePrice = 12.50, ImageUrl = "https://www.trzcacak.rs/myfile/full/454-4546713_spaghetti-with-sauce-png.png" };

                Product cake = new Product { ProductName = "Cake", ProductPrice = 8.50, ProductType = ProductType.Snacks, ProductDescription = "Hmmmm cake", SalePrice = 8.50, ImageUrl = "https://images.squarespace-cdn.com/content/v1/538500e4e4b0fa9e95efc7b9/1558977907797-27MUKZZPLWI74TIPOGED/ke17ZwdGBToddI8pDm48kMtiXMEMZ8ID8MVhA-T_Qc9Zw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIXpy3a2Cibo6eml5BpILeGX-BY3QvcZT7F317PmmzovI/SKOR+CC+slice.png?format=1000w" };

                Product pancakes = new Product { ProductName = "Pancakes", ProductPrice = 6.00, ProductType = ProductType.Snacks, ProductDescription = "Pancakes are delicious", SalePrice = 6.00, ImageUrl = "https://purepng.com/public/uploads/large/purepng.com-pancakepancakehotcakegriddlecakeflapjack-1411528648897qeapn.png" };

                Product cake2 = new Product { ProductName = "Cake 2", ProductPrice = 8.50, ProductType = ProductType.Snacks, ProductDescription = "Hmmmm cake", SalePrice = 8.50, ImageUrl = "https://images.squarespace-cdn.com/content/v1/538500e4e4b0fa9e95efc7b9/1558977907797-27MUKZZPLWI74TIPOGED/ke17ZwdGBToddI8pDm48kMtiXMEMZ8ID8MVhA-T_Qc9Zw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIXpy3a2Cibo6eml5BpILeGX-BY3QvcZT7F317PmmzovI/SKOR+CC+slice.png?format=1000w" };

                Product cake3 = new Product { ProductName = "Cake 3", ProductPrice = 5.50, ProductType = ProductType.Snacks, ProductDescription = "Hmmmm cake", SalePrice = 5.50, ImageUrl = "https://images.squarespace-cdn.com/content/v1/538500e4e4b0fa9e95efc7b9/1558977907797-27MUKZZPLWI74TIPOGED/ke17ZwdGBToddI8pDm48kMtiXMEMZ8ID8MVhA-T_Qc9Zw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIXpy3a2Cibo6eml5BpILeGX-BY3QvcZT7F317PmmzovI/SKOR+CC+slice.png?format=1000w" };

                Product cake4 = new Product { ProductName = "Cake 4", ProductPrice = 8.50, ProductType = ProductType.Snacks, ProductDescription = "Hmmmm cake", SalePrice = 8.50, ImageUrl = "https://images.squarespace-cdn.com/content/v1/538500e4e4b0fa9e95efc7b9/1558977907797-27MUKZZPLWI74TIPOGED/ke17ZwdGBToddI8pDm48kMtiXMEMZ8ID8MVhA-T_Qc9Zw-zPPgdn4jUwVcJE1ZvWQUxwkmyExglNqGp0IvTJZamWLI2zvYWH8K3-s_4yszcp2ryTI0HqTOaaUohrI8PIXpy3a2Cibo6eml5BpILeGX-BY3QvcZT7F317PmmzovI/SKOR+CC+slice.png?format=1000w" };

                Product fanta = new Product { ProductName = "Fanta", ProductPrice = 2.50, ProductType = ProductType.Drinks, SalePrice = 2.50, ImageUrl = "https://5.imimg.com/data5/BB/BB/GLADMIN-/fanta-250x250.png" };

                Product duvel = new Product { ProductName = "Duvel", ProductPrice = 5.00, ProductType = ProductType.Drinks, SalePrice = 5.00, ImageUrl = "https://www.bierfamilie.nl/wp-content/uploads/2017/09/Duvel.png" };

                Product redbull = new Product { ProductName = "Redbull", ProductPrice = 3.00, ProductType = ProductType.Drinks, SalePrice = 2.50, ImageUrl = "https://www.stickpng.com/assets/images/580b57fcd9996e24bc43c1e9.png" };

                Product icetea = new Product { ProductName = "Duvel", ProductPrice = 5.00, ProductType = ProductType.Drinks, SalePrice = 5.00, ImageUrl = "https://www.lipton.com/content/dam/unilever/lipton_international/belgium/pack_shot/lipton_ice_tea_green_matcha_cucumber_mint_330ml-1206351-1567836-png.png" };

                Product jupiler = new Product { ProductName = "Jupiler", ProductPrice = 3.00, ProductType = ProductType.Drinks, SalePrice = 3.00, ImageUrl = "https://pngimage.net/wp-content/uploads/2018/06/jupiler-png-3.png" };


                IEnumerable<Product> products = new List<Product> { apple, hamburgerWithFries, chocolateBar, pear, spaghetti, cake, pancakes, cake2, cake3, cake4, fanta, duvel, redbull, icetea, jupiler };
                _context.Product.AddRange(products);
                #endregion

                #region PassangerGroups
                PassengerGroup group1 = new PassengerGroup();

                PassengerGroup group2 = new PassengerGroup();
                #endregion

                #region Passangers

                User passenger1 = new Passenger
                {
                    BookingNr = 95120659,
                    Firstname = "Jonah",
                    Name = "De Smet",
                    Group = group1

                };

                User passenger2 = new Passenger
                {
                    BookingNr = 95120659,
                    Firstname = "Johanna",
                    Name = "De Bruycker",
                    Group = group1

                };

                User passenger3 = new Passenger
                {
                    BookingNr = 95120659,
                    Firstname = "Bram",
                    Name = "De Bleecker",
                    Group = group1

                };

                User passenger4 = new Passenger
                {
                    BookingNr = 12456248,
                    Firstname = "Helena",
                    Name = "De Bakker",
                    Group = group2

                };

                User passenger5 = new Passenger
                {
                    BookingNr = 95756659,
                    Firstname = "Kurt",
                    Name = "De Bakker",
                    Group = group2

                };
                #endregion

                User passenger6 = new Passenger
                {
                    BookingNr = 74306529,
                    Firstname = "Astrid",
                    Name = "De Bakker",
                    Group = group2

                };


                #region CrewMember
                User Maria = new CrewMember
                {
                    CrewMemberID = 1234,
                    Firstname = "Maria",
                    Name = "Garcia",
                };

                User Bart = new CrewMember
                {
                    CrewMemberID = 1111,
                    Firstname = "Bart",
                    Name = "De Visser",
                };

                _context.User.AddRange(Maria, Bart);
                #endregion

                #region OrderDetails
                OrderDetail appleorder = new OrderDetail
                {
                    Product = apple,
                    ProductId = apple.ProductId,
                    OrderedAmount = 2
                };

                OrderDetail spaghettiorder = new OrderDetail
                {
                    Product = spaghetti,
                    ProductId = spaghetti.ProductId,
                    OrderedAmount = 5
                };

                OrderDetail cakeorder = new OrderDetail
                {
                    Product = cake,
                    ProductId = cake.ProductId,
                    OrderedAmount = 1
                };

                OrderDetail pancakesorder = new OrderDetail
                {
                    Product = pancakes,
                    ProductId = pancakes.ProductId,
                    OrderedAmount = 2
                };

                OrderDetail hamburgerorder = new OrderDetail
                {
                    Product = hamburgerWithFries,
                    ProductId = hamburgerWithFries.ProductId,
                    OrderedAmount = 1
                };

                OrderDetail cakeOrder = new OrderDetail
                {
                    Product = cake,
                    ProductId = cake.ProductId,
                    OrderedAmount = 5
                };

                OrderDetail cakeOrder2 = new OrderDetail
                {
                    Product = cake2,
                    ProductId = cake2.ProductId,
                    OrderedAmount = 3
                };


                IEnumerable<OrderDetail> orderdetails1 = new List<OrderDetail> { appleorder, cakeorder };
                IEnumerable<OrderDetail> orderdetails2 = new List<OrderDetail> { cakeorder, hamburgerorder, appleorder };
                IEnumerable<OrderDetail> orderdetails3 = new List<OrderDetail> { pancakesorder, cakeOrder2 };
                #endregion

                #region Orders
                Order jonahOrder = new Order
                {
                    Passenger = (Passenger)passenger1,
                    OrderState = OrderState.Complete,
                    OrderDetails = orderdetails1
                };

                Order johannaOrder = new Order
                {
                    Passenger = (Passenger)passenger2,
                    OrderState = OrderState.Complete,
                    OrderDetails = orderdetails2
                };

                Order bramOrder = new Order
                {
                    Passenger = (Passenger)passenger3,
                    OrderState = OrderState.Pending,
                    OrderDetails = orderdetails3
                };

                IEnumerable<Order> orders = new List<Order> { jonahOrder, johannaOrder, bramOrder };
                _context.Order.AddRange(orders);
                #endregion

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

                Seat s4p4 = new Seat
                {
                    SeatNumber = 4,
                    User = passenger4
                };

                Seat s5p5 = new Seat
                {
                    SeatNumber = 5,
                    User = passenger5
                };

                Seat s6p6 = new Seat
                {
                    SeatNumber = 6,
                    User = passenger6
                };

                seats = new List<Seat> { s1p1, s2p2, s3p3, s4p4, s5p5, s6p6 };
                #endregion

                #region Flight
                Flight Flight = new Flight
                {
                    FlightName = "Brussels Airlines 747",
                    Arrival = new DateTime(2019, 09, 13),
                    Departure = DateTime.Today,
                    Destination = "Bonaire",
                    EstimatedArrival = new DateTime(2019, 09, 13, 5, 2, 00),
                    Seats = seats,
                    // 50.905665, 4.493043
                    StartLatitude = 50.905665,
                    StartLongitude = 4.493043,
                    //12.133721, -68.278008
                    EndLatitude = 12.133721,
                    EndLongitude = -68.278008,
                    Origin = "Zaventem"
                };
                #endregion

                // Adding the seats to the flight

                _context.Flight.Add(Flight);

                await _context.SaveChangesAsync();
            }
        }
    }
}
