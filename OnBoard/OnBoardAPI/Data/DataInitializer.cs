using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnBoardAPI.Data
{
    public class DataInitializer
    {
        private readonly Context _context;
        private readonly UserManager<IdentityUser> _manager;

        public DataInitializer(Context context, UserManager<IdentityUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        public async Task InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {

            }
        }
    }
}
