using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwordSoldiers.Api.Domains.GameMaps.Dtos;
using SwordSoldiers.Infrastructure.Repositories;

namespace SwordSoldiers.Api.Domains.GameMaps;

[Route($"{Constants.protectedRoute}/game-maps")]
[ApiController]
public class GameMapsController(IGameMapRepository gameMapRepository): ControllerBase
{
    private readonly IGameMapRepository _gameMapRepository = gameMapRepository;
    
    [HttpGet()]
    [Authorize()]
    public async Task<IActionResult> GetAllGameMaps()
    {
        return Ok(await _gameMapRepository.GetAllAsync());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetGameMapById([FromRoute] Guid id)
    {
        var gameMap = await _gameMapRepository.GetByIdAsync(id);

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
        var createdGameMap = await _gameMapRepository.CreateAsync(newGameMap);
        
        return CreatedAtAction(nameof(GetGameMapById), new { id = createdGameMap.Id }, createdGameMap);
    }

    [HttpDelete("{id:guid}")]
    [Authorize(Policy = "CreateGameMaps")]
    public async Task<IActionResult> DeleteGameMap([FromRoute] Guid id)
    {
        var gameMap = await _gameMapRepository.DeleteAsync(id);

        if (gameMap == null)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}