using HackathonRegistration.Application.Models;
using HackathonRegistration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonRegistration.Application.Services.Interfaces
{
    public interface IHackathonService
    {
        Task CreateHackathon(Hackathon hackathon);
        Task<List<RetrieveAllHackathonsDto>> GetHackathons();
        Task<RetrieveHackathonByIdDto?> GetHackathonById(int id);
    }
}
