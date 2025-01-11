using System.ComponentModel.DataAnnotations;
using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Api.ApplicationUsers.Dtos
{
    public class UpdateApplicationUserDto
    {
        [MaxLength(255)]
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Character Character { get; set; }
    }
}
