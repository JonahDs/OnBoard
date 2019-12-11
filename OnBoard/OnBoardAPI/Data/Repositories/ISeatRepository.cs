using OnBoardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data.Repositories
{
    public interface ISeatRepository
    {
        Seat GetSeatInstanceWithSeatNumber(int seatNumber);
        void SwitchUsersFromSeats(Seat s1, Seat s2);
    }
}
