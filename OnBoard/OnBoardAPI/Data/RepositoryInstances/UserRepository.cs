using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.RepositoryInstances
{
    public class UserRepository : IUserRepository
    {

        private readonly DbSet<Seat> _seats;
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _seats = context.Seat;
            _context = context;
        }


        public Seat GetUserInstanceForAppliction(int userCount)
        {
            return GetUserWithId(userCount);
        }

        public IEnumerable<Message> GetUserMessages(int userId)
        {
            Seat seat = (Seat)_seats.Include(t => t.User).ThenInclude(t => t.Messages).Where(t => t.User.Id == userId);
            return seat.User.Messages;
        }

        public Seat GetUserWithId(int userId)
        {
            Seat local = _seats.Include(t => t.User).Where(t => t.User.Id == userId).FirstOrDefault();
            if(local == null)
            {
                return null;
            }
            return local;
        }

        public void StoreMessage(Message message)
        {
            GetUserById(message.Destinator.Id).Messages.ToList().Add(message);
            _context.SaveChanges();
        }
    }
}
