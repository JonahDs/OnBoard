﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.Models
{
    public class Message
    {
        public int DestinatorId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string MessageString { get; set; }
    }
}
