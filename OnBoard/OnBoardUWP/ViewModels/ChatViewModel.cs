using Microsoft.AspNetCore.SignalR.Client;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnBoardUWP.ViewModels
{
    public class ChatViewModel : BindableBase
    {
        private HubConnection connection;
        private ObservableCollection<string> _messageList;
        public ObservableCollection<string> MessageList
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
        public ChatViewModel()
        {
            connection = new HubConnectionBuilder().WithUrl("http://localhost:50236/api/Chathub").Build();
            MessageList = new ObservableCollection<string>();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        public async void ConnectHandler()
        {
            connection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var newMessage = $"{user}: {message}";
                MessageList.Add(newMessage);

            });


            try
            {
                await connection.StartAsync();
                MessageList.Add("Connection started");
            }
            catch (Exception ex)
            {
                MessageList.Add(ex.Message);
            }
        }

        public async void SendHandler(string user, string message)
        {
            try
            {
                Message messageObject = new Message { UserName = user, MessageString = message };
                await connection.InvokeAsync("SendMessage",
                    messageObject);
            }
            catch (Exception ex)
            {
                MessageList.Add(ex.Message);
            }
        }
    }
}
