using HackathonRegistration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User?> FindByNameAsync(string username);

        Task<bool> CheckPasswordAsync(User user, string password);
    }
}
