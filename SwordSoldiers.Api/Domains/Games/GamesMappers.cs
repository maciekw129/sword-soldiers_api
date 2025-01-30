using SwordSoldiers.Api.Domains.Games.Dtos;
using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Api.Domains.Games;

public static class GamesMappers
{
    public static GameDto GameToGameDto(this Game game)
    {
        return new GameDto()
        {
            Id = game.Id,
            MapData = game.Map.Data,
            EnemyRate = game.Map.EnemyRate
        };
    }
}