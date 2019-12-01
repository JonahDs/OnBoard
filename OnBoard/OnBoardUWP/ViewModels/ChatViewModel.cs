using Microsoft.AspNetCore.SignalR.Client;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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

        public ChatViewModel(int loggedUserId)
        {
            FetchMessages(loggedUserId);  
        }


        public async void FetchMessages(int loggedUserId)
        {
            var list = await GlobalMethods.ApiCall<object>($"http://localhost:50236/api/message/{loggedUserId}", client);
        }
        
    }
}
