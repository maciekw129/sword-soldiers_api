using SwordSoldiers.Api.Domains.GameMaps.Dtos;
using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Api.Domains.GameMaps;

public static class GameMapsMappers
{
    public static GameMapDto GameMapToGameMapDto(this GameMap gameMap)
    {
        return new GameMapDto()
        {
            Id = gameMap.Id,
            Title = gameMap.Title,
            Data = gameMap.Data,
            Difficulty = gameMap.Difficulty,
            ImageUrl = gameMap.ImageUrl,
        };
    }

    public static GameMap CreateGameMapDtoToGameMap(this CreateGameMapDto createGameMapDto)
    {
        return new GameMap()
        {
            Title = createGameMapDto.Title,
            Data = createGameMapDto.Data,
            Difficulty = createGameMapDto.Difficulty,
            EnemyRate = createGameMapDto.EnemyRate,
            ImageUrl = createGameMapDto.ImageUrl,
        };
    }

    public static GameMapListItemDto GameMapToGameMapListItemDto(this GameMap gameMap)
    {
        return new GameMapListItemDto()
        {
            Id = gameMap.Id,
            Title = gameMap.Title,
            Difficulty = gameMap.Difficulty,
            ImageUrl = gameMap.ImageUrl,
        };
    }
}