using HackathonRegistration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Application.Services.Interfaces
{
    public interface ILoginService
    {
        Task<string> Login(string username, string password);
        Task Register(Competitor competitor);
    }
}

