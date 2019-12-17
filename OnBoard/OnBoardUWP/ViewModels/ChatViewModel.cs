using Newtonsoft.Json;
using OnBoardUWP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.Web.Http;

namespace OnBoardUWP.ViewModels
{
    public class ChatViewModel : BindableBase
    {
        private HttpClient client = new HttpClient();
        private ObservableCollection<Message> _messageList;
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                Set(ref _message, value);
            }
        }

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

        private ObservableCollection<User> _users;

        public ObservableCollection<User> Users
        {
            get
            {
                return _users;
            }
            set
            {
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
            SendMessageCommand = new RelayCommand(choice => SendMessage(loggedUser, (bool)choice));
        }

        public ChatViewModel(CrewMember crew, IEnumerable<Seat> OnBoardUsers)
        {
            MessageList = new ObservableCollection<Message>();
            Users = new ObservableCollection<User>();
            OnBoardUsers.ToList().ForEach(t => Users.Add(t.User));
            SendMessageCommand = new RelayCommand(choice => SendMessage(crew, (bool)choice));
        }


        private async void FetchMessages(int loggedUserId)
        {
            try
            {
            var list = await GlobalMethods.ApiCall<List<Message>>($"http://localhost:50236/api/message/{loggedUserId}", client);
            MessageList = new ObservableCollection<Message>(list);
            }
            catch {}
        }

        private async void FetchTextableUsers(int loggedUserId)
        {
            try
            {
                var list = await GlobalMethods.ApiCall<List<User>>($"http://localhost:50236/api/user/passenerGroup/{loggedUserId}", client);
                Users = new ObservableCollection<User>(list);
            }
            catch {}
        }

        public async void SendMessage(User loggedUser, bool all)
        {
            if (all)
            {
                Users.ToList().ForEach(async t =>
                {
                    Message messages = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = t.Id, MessageString = _message };
                    await PostMessage(messages);
                });
            }
            else
            {
                try
                {
                    CheckIfDestinator();
                }
                catch (ArgumentNullException ex)
                {
                    ShowMessageDialog("You must select a destinator to send messages!");
                    return;

                }
                Message message = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = Destinator.Id, MessageString = _message };
                await PostMessage(message);
            }

        }



        public async void SendMessage(CrewMember loggedUser, bool all)
        {
            if (all)
            {
                Users.ToList().ForEach(async t =>
                {
                    Message messages = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = t.Id, MessageString = _message };
                    await PostMessage(messages);
                });
            }
            else
            {
                try
                {
                    CheckIfDestinator();
                }
                catch (ArgumentNullException ex)
                {
                    ShowMessageDialog("You must select a destinator to send messages!");
                    return;
                }
                Message message = new Message { SenderId = loggedUser.Id, SenderName = loggedUser.Firstname, DestinatorId = Destinator.Id, MessageString = _message };
                await PostMessage(message);
            }
        }

        public bool CheckIfDestinator()
        {
            if (Destinator == null)
            {
                throw new ArgumentNullException();
            }
            return true;
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

        private async void ShowMessageDialog(string text)
        {
            var messageDialog = new MessageDialog(text);
            messageDialog.Commands.Add(new UICommand("Ok"));
            messageDialog.Commands.Add(new UICommand("Close"));
            await messageDialog.ShowAsync();
        }
    }
}
