using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.RepositoryInstances
{
    public class SeatRepository : ISeatRepository
    {
        private readonly DbSet<Seat> _seats;
        private readonly Context _context;

        public SeatRepository(Context context)
        {
            _context = context;
            _seats = context.Seat;
        }

        public Seat GetSeatInstanceWithSeatNumber(int seatNumber)
        {
            return _seats.Where(t => t.SeatNumber == seatNumber).Include(t => t.User).FirstOrDefault();
        }
    }
}
