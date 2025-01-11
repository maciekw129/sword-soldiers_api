using SwordSoldiers.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SwordSoldiers.Api.ApplicationUsers.Dtos
{
    public class CreateApplicationUserDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public Character Character { get; set; }
    }
}
