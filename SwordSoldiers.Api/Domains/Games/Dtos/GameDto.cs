namespace SwordSoldiers.Api.Domains.Games.Dtos;

public class GameDto
{
    public Guid Id { get; set; }
    public object MapData { get; set; }
    public int EnemyRate { get; set; }
}