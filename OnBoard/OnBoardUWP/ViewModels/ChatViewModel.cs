﻿using Microsoft.AspNetCore.SignalR.Client;
using Newtonsoft.Json;
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
        private string _message;
        public string Message {
            get {
                return _message;
            }
            set {
                Set(ref _message, value);
            }
        }

        public ObservableCollection<Message> MessageList {
            get {
                return _messageList;
            }
            set {
                Set(ref _messageList, value);
            }
        }

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users {
            get {
                return _users;
            }
            set {
                Set(ref _users, value);
            }
        }

        public User Destinator { get; set; }

        public RelayCommand SendMessageCommand { get; set; }

        public ChatViewModel(User loggedUser)
        {

            MessageList = new ObservableCollection<Message>();
            Message = "";
            FetchMessages(loggedUser.Id);
            FetchTextableUsers(loggedUser.Id);
            SendMessageCommand = new RelayCommand(_ => SendMessage(loggedUser));
        }

        public ChatViewModel(CrewMember crew, IEnumerable<Seat> OnBoardUsers)
        {
            MessageList = new ObservableCollection<Message>();
            Users = new ObservableCollection<User>();
            OnBoardUsers.ToList().ForEach(t => Users.Add(t.User));
        }


        private async void FetchMessages(int loggedUserId)
        {
            var list = await GlobalMethods.ApiCall<List<Message>>($"http://localhost:50236/api/message/{loggedUserId}", client);
            MessageList = new ObservableCollection<Message>(list);
        }

        private async void FetchTextableUsers(int loggedUserId)
        {
            var list = await GlobalMethods.ApiCall<List<User>>($"http://localhost:50236/api/user/passenerGroup/{loggedUserId}", client);
            Users = new ObservableCollection<User>(list);
        }


        public void SetMessageDestinator(User destinator)
        {
            Destinator = destinator;
        }



        public async void SendMessage(User loggedUser)
        {
            Message message = new Message { SenderId = loggedUser.Id, DestinatorId = Destinator.Id, MessageString = _message };
        }

        public async void SendMessage(string messageString, User loggedUser, bool all)
        {
            if (all == true)
            {
                Users.ToList().ForEach(async t =>
                {
                    Message messages = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = t.Id, MessageString = messageString };
                    await PostMessage(messages);
                });
            }
            else
            {
                Message message = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = Destinator.Id, MessageString = messageString };
                await PostMessage(message);
            }

        }

        public async void SendMessage(string messageString, CrewMember loggedUser, bool all)
        {

            if (all == true)
            {
                Users.ToList().ForEach(async t =>
                {
                    Message messages = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = t.Id, MessageString = messageString };
                    await PostMessage(messages);
                });
            }
            else
            {
                Message message = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = Destinator.Id, MessageString = messageString };
                await PostMessage(message);
            }
        }

        public async Task PostMessage(Message message)
        {
            try
            {
                Uri uri = new Uri($"http://localhost:50236/api/message/sendMessage/{message}");
                var jsonString = JsonConvert.SerializeObject(message);

                HttpStringContent content = new HttpStringContent(jsonString, encoding: Windows.Storage.Streams.UnicodeEncoding.Utf8, mediaType: "application/json");
                HttpResponseMessage responseMessage = await client.PostAsync(uri, content);
                responseMessage.EnsureSuccessStatusCode();
                Message = "";
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }

            MessageList.Add(message);
        }

    }
}
