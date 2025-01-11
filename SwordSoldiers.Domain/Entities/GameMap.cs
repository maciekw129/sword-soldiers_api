using System.Text.Json;
using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Domain.Entities;

public class GameMap
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public required JsonDocument Data { get; set; }
    public Difficulty Difficulty { get; set; }
    public int EnemyRate { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}