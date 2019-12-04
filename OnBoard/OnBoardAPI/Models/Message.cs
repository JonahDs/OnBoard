using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public User Destinator { get; set; }
        public string Sender { get; set; }
        public string MessageString { get; set; }
    }
}
