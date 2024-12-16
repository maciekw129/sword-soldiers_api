using System.ComponentModel.DataAnnotations;

namespace SwordSoldiers.Api.ApplicationUsers.Dtos
{
    public class UpdateApplicationUserDto
    {
        [MaxLength(255)]
        public string Name { get; set; }
    }
}
