using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using OnBoardAPI.Models;

namespace OnBoardAPI.Hubs
{
    public class ChatHub: Hub
    {
        /// <summary>
        /// Not quite sure yet if we need to work with a message object
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessageToGroup(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);

            ///Needs a id, the id should be the passengerGroup
            ///Groups.AddToGroupAsync(Context.ConnectionId, 'groupId');
            ///

            /// only send to the passengers inside the same group
            /// await Client.Groups(passengerGroupId).SendAsync
        }

        public Task SendPrivateMessage(string userId, string message)
        {
            return Clients.User(userId).SendAsync("RecieveMessage", message);
        }
    }
}
