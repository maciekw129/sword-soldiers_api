using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure.Repositories;

public interface IGameRepository
{
    Task<Game?> GetByIdAsync(Guid id);
    Task<Game> CreateAsync(Game game);
}