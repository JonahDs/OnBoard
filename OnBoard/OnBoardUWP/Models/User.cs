using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class User
    {
        public int Id { get; set; }
        public int BookingNr { get; set; }
        public string Name { get; set; }
        public string Firstname { get; set; }
        public PassengerGroup Group { get; set; }
        public List<Order> Orders { get; set; }
    }
}
