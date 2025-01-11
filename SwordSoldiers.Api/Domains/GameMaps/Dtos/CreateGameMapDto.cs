using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Api.Domains.GameMaps.Dtos;

public class CreateGameMapDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    [Required]
    public JsonDocument Data { get; set; }
    
    [Required]
    public Difficulty Difficulty { get; set; }
    
    [Required]
    public int EnemyRate { get; set; }
}