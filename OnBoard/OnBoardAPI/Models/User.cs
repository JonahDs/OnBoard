using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Models
{
    public abstract class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Firstname { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public IList<Message> Messages { get; set; }

        public void AddMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}
