using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.RepositoryInstances
{
    public class UserRepository : IUserRepository
    {

        private readonly DbSet<User> _users;

        private readonly Context _context;

        public UserRepository(Context context)
        {
            _users = context.User;
            _context = context;
        }


        public User GetUserInstanceForAppliction(int userCount)
        {
            return GetUserWithId(userCount);
        }

        public IEnumerable<Message> GetUserMessages(int userId)
        {
            User user = _users.Where(t => t.Id == userId).Include(t => t.Messages).FirstOrDefault();
            return user.Messages;
        }

        public Passenger GetUserWithId(int userId)
        {
            return _users.Where(t => t.Id == userId).OfType<Passenger>().Include(t => t.Group).Include(t => t.Messages).FirstOrDefault();
        }

        public IEnumerable<User> GetUsersWithSameGroup(int userId)
        {
            Passenger searchedPassanger = GetUserWithId(userId);
            return _users.OfType<Passenger>().Include(t => t.Group).ThenInclude(t => t.Passengers).Where(t => t.Group.Id == searchedPassanger.Group.Id).ToList();
        }

        public void StoreMessage(Message message)
        {
            Passenger passenger = GetUserWithId(message.DestinatorId);
            passenger.AddMessage(message);
            _context.Update(passenger);
            _context.SaveChanges();
        }
    }
}
