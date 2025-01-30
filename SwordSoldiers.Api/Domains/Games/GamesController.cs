using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using SwordSoldiers.Domain.Entities;
using SwordSoldiers.Infrastructure.Repositories;

namespace SwordSoldiers.Api.Domains.Games;

[Route($"{Constants.protectedRoute}/games")]
[ApiController]
public class GamesController(IGameRepository gameRepository, IGameMapRepository gameMapRepository): ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetGameById([FromRoute] Guid id)
    {
        var game = await gameRepository.GetByIdAsync(id);

        if (game == null)
        {
            return NotFound();
        }

        return Ok(game.GameToGameDto());
    }
    
    [HttpPost()]
    [Authorize()]
    public async Task<IActionResult> CreateGame([FromQuery] Guid gameMapId)
    {
        var gameMap = await gameMapRepository.GetByIdAsync(gameMapId);

        if (gameMap == null)
        {
            return NotFound();
        }
        
        var newGame = new Game()
        {
            MapId = gameMapId
        };
        
        var createdGame = await gameRepository.CreateAsync(newGame);
        
        return CreatedAtAction(nameof(GetGameById), new {id = createdGame.Id}, createdGame.GameToGameDto());
    }
}