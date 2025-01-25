using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwordSoldiers.Api.Domains.GameMaps.Dtos;
using SwordSoldiers.Infrastructure.Repositories;

namespace SwordSoldiers.Api.Domains.GameMaps;

[Route($"{Constants.protectedRoute}/game-maps")]
[ApiController]
public class GameMapsController(IGameMapRepository gameMapRepository): ControllerBase
{
    [HttpGet()]
    [Authorize()]
    public async Task<IActionResult> GetAllGameMaps()
    {
        var gameMaps = await gameMapRepository.GetAllAsync();
        
        return Ok(gameMaps.Select(gameMap => gameMap.GameMapToGameMapListItemDto()).ToList());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetGameMapById([FromRoute] Guid id)
    {
        var gameMap = await gameMapRepository.GetByIdAsync(id);

        if (gameMap == null)
        {
            return NotFound();
        }
        
        return Ok(gameMap.GameMapToGameMapDto());
    }

    [HttpPost()]
    [Authorize(Policy = "CreateGameMaps")]
    public async Task<IActionResult> CreateGameMap([FromBody] CreateGameMapDto createGameMapDto)
    {
        var newGameMap = createGameMapDto.CreateGameMapDtoToGameMap();
        var createdGameMap = await gameMapRepository.CreateAsync(newGameMap);
        
        return CreatedAtAction(nameof(GetGameMapById), new { id = createdGameMap.Id }, createdGameMap);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "CreateGameMaps")]
    public async Task<IActionResult> DeleteGameMap([FromRoute] Guid id)
    {
        var gameMap = await gameMapRepository.DeleteAsync(id);

        if (gameMap == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}