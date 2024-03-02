using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly HackathonRegistrationDbContext _context;

        public UserRepository(HackathonRegistrationDbContext context)
        {
            _context = context;
        }

        public async Task<User?> FindByNameAsync(string username)
        {
            return await _context.Users
                                 .Where(u => u.Username == username)
                                 .FirstOrDefaultAsync();
        }
        public Task<bool> CheckPasswordAsync(User user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
