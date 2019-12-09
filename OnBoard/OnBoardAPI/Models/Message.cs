using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public class Message
    {
        public int Id { get; set; }
        public int DestinatorId { get; set; }
        public int SenderId { get; set; }
        public string MessageString { get; set; }
    }
}
