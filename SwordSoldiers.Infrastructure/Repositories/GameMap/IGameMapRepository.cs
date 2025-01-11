using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure.Repositories;

public interface IGameMapRepository
{
    Task<List<GameMap>> GetAllAsync();
    Task<GameMap?> GetByIdAsync(Guid id);
    Task<GameMap> CreateAsync(GameMap gameMap);
    Task<GameMap?> DeleteAsync(Guid id);
}