using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;
using HackathonRegistration.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class HackathonRepository : IHackathonRepository
{
    private readonly HackathonRegistrationDbContext _dbContext;

    public HackathonRepository(HackathonRegistrationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task CreateHackathon(Hackathon hackathon)
    {
        await _dbContext.Hackathons.AddAsync(hackathon);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<List<Hackathon>> GetHackathons()
    {
        return await _dbContext.Hackathons.ToListAsync();
    }

    public async Task<Hackathon?> GetHackathonById(int id)
    {
        return await _dbContext.Hackathons
            .Include(h => h.Challenges)
            .FirstOrDefaultAsync(h => h.HackathonID == id);
    }

    public async Task<Challenge> GetChallengeById(int challengeId)
    {
        return await _dbContext.Challenges.Where(c => c.ChallengeID == challengeId).FirstAsync();
    }
}