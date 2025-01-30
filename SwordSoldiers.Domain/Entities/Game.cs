namespace SwordSoldiers.Domain.Entities;

public class Game
{
    public Guid Id { get; set; }
    public Guid MapId { get; set; }
    public GameMap Map { get; set; }
    public bool IsFinished { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}