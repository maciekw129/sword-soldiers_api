using System.ComponentModel.DataAnnotations;
using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Api.Domains.GameMaps.Dtos;

public class CreateGameMapDto
{
    [Required]
    [MaxLength(255)]
    public string Title { get; set; }
    
    [Required]
    public object Data { get; set; }
    
    [Required]
    public Difficulty Difficulty { get; set; }
    
    [Required]
    public int EnemyRate { get; set; }
    
    [Required]
    public string ImageUrl { get; set; }
}