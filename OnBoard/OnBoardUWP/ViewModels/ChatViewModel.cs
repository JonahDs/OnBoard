using Microsoft.AspNetCore.SignalR.Client;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class ChatViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ObservableCollection<Message> _messageList;
        public ObservableCollection<Message> MessageList
        {
            get
            {
                return _messageList;
            }
            set
            {
                Set(ref _messageList, value);
            }
        }

        public ChatViewModel(User loggedUser)
        {
            FetchMessages(loggedUser.Id);
            FetchTextableUsers(loggedUser.Id);
        }


        public async void FetchMessages(int loggedUserId)
        {
            var list = await GlobalMethods.ApiCall<object>($"http://localhost:50236/api/message/{loggedUserId}", client);
        }

        public async void FetchTextableUsers(int loggedUserId)
        {
            var list = await GlobalMethods.ApiCall<object>($"http://localhost:50236/api/user/passengerGroup/{loggedUserId}", client);
        }


        
        public async void SendMessage(int loggedUserId, int destinatorId, string messageString)
        {
            Message message = new Message { SenderId = loggedUserId, DestinatorId = destinatorId, MessageString = messageString };
            try
            {
                Uri uri = new Uri("");
                var jsonString = Utf8Json.JsonSerializer.Serialize(message).ToString();

                HttpStringContent content = new HttpStringContent(jsonString);
                HttpResponseMessage responseMessage = await client.PostAsync(uri , content);
                responseMessage.EnsureSuccessStatusCode();

            } catch(Exception e)
            {
                Debug.WriteLine(e);
            }
        }

    }
}
