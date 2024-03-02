using HackathonRegistration.Domain.Models;
using HackathonRegistration.Domain.Repositories;
using HackathonRegistration.Infrastructure;
using Microsoft.EntityFrameworkCore;

public class CompetitorRepository : ICompetitorRepository
{
    private readonly HackathonRegistrationDbContext _dbContext;

    public CompetitorRepository(HackathonRegistrationDbContext dbContext)
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

    public async Task Register(Team team)
    {

        foreach (var competitor in team.Competitors)
        {
            await _dbContext.Competitors.AddAsync(competitor);
        }

        await _dbContext.Teams.AddAsync(team);

        await _dbContext.SaveChangesAsync();
    }
}