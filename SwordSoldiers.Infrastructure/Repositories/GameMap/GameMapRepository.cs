using Microsoft.EntityFrameworkCore;
using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure.Repositories;

public class GameMapRepository(ApplicationDbContext applicationDbContext) : IGameMapRepository
{
    public async Task<List<GameMap>> GetAllAsync()
    {
        return await applicationDbContext.GameMaps.ToListAsync();
    }

    public async Task<GameMap?> GetByIdAsync(Guid id)
    {
        return await applicationDbContext.GameMaps.FindAsync(id);
    }

    public async Task<GameMap> CreateAsync(GameMap gameMap)
    {
        await applicationDbContext.GameMaps.AddAsync(gameMap);
        await applicationDbContext.SaveChangesAsync();
        return gameMap;
    }

    public async Task<GameMap?> DeleteAsync(Guid id)
    {
        var gameMap = await applicationDbContext.GameMaps.FindAsync(id);

        if (gameMap == null)
        {
            return null;
        }
        
        applicationDbContext.GameMaps.Remove(gameMap);
        await applicationDbContext.SaveChangesAsync();
        return gameMap;
    }
}