using Microsoft.EntityFrameworkCore;
using OnBoardAPI.Data.Repositories;
using OnBoardAPI.Models;
using System.Linq;

namespace OnBoardAPI.Data.RepositoryInstances
{
    public class FlightRepository : IFlightRepository
    {
        private readonly Context _context;
        private readonly DbSet<Flight> _flights;

        public FlightRepository(Context context)
        {
            _context = context;
            _flights = context.Flight;
        }
        public Flight GetCurrentFlight()
        {
            return _flights.Include(t => t.Seats).ThenInclude(t => t.User).First();
        }
    }
}
