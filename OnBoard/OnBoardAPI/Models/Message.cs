using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class Message
    {
        public int PassengerGroupId { get; set; }
        public string UserName { get; set; }
        public string MessageString { get; set; }
    }
}
