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

        public UserRepository(Context context)
        {
            _seats = context.Seat;
        }

        public Seat GetUserInstanceForAppliction(int userCount)
        {
            return GetUserWithId(userCount);
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
    }
}
