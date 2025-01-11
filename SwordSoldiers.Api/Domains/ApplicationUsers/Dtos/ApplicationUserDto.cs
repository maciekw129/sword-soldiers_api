using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Api.ApplicationUsers.Dtos
{
    public class ApplicationUserDto
    {
        public required Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        public Character Character { get; set; }
    }
}
