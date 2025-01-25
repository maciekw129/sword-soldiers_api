using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Api.Domains.GameMaps.Dtos;

public class GameMapListItemDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Difficulty Difficulty { get; set; }
    public string ImageUrl { get; set; }
}