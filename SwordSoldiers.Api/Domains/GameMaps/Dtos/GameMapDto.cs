using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Api.Domains.GameMaps.Dtos;

public class GameMapDto
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public object Data { get; set; }
    public Difficulty Difficulty { get; set; }
    public int EnemyRate { get; set; }
}