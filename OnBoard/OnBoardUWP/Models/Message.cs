using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Message
    {
        public User Destinator { get; set; }
        public string Sender { get; set; }
        public string MessageString { get; set; }
    }
}
