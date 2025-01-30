using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure.Repositories;

public class GameRepository(ApplicationDbContext applicationDbContext): IGameRepository
{
    public async Task<Game?> GetByIdAsync(Guid id)
    {
        return await applicationDbContext.Games.FindAsync(id);
    }

    public async Task<Game> CreateAsync(Game game)
    {
        await applicationDbContext.Games.AddAsync(game);
        await applicationDbContext.SaveChangesAsync();
        return game;
    }
}