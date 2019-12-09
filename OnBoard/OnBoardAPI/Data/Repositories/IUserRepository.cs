using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.Repositories
{
    public interface IUserRepository
    {
        User GetUserInstanceForAppliction(int userCount);
        IEnumerable<Message> GetUserMessages(int userId);
        void StoreMessage(Message message);
        Passenger GetUserWithId(int userId);
        IEnumerable<User> GetUsersWithSameGroup(int groupId);
    }
}
