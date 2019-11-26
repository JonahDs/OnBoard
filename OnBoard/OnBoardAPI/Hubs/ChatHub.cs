﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace OnBoardAPI.Hubs
{
    public class ChatHub: Hub
    {
        public async Task SendMessage(string userId, string message)
        {
            await Clients.All.SendAsync("RecieveMessage", userId, message);
        }
    }
}
