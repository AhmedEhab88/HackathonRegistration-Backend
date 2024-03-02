using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

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
        public bool CheckPasswordAsync(User user, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, user.Password);
        }

        public async Task SaveCompetitorAsync(Competitor competitor) 
        {
            await _context.Set<Competitor>().AddAsync(competitor);

            await _context.SaveChangesAsync();
        }
    }
}
