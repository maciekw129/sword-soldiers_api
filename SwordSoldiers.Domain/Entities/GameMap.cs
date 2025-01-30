using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Domain.Entities;

public class GameMap
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public required object Data { get; set; }
    public Difficulty Difficulty { get; set; }
    public int EnemyRate { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<Game> Games { get; } = new List<Game>();
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}