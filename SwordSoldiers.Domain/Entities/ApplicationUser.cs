using SwordSoldiers.Domain.Enums;

namespace SwordSoldiers.Domain.Entities
{
    public class ApplicationUser
    {
        public Guid Id { get; set; }
        public string AuthId { get; set; }
        public string? Name { get; set; }
        public Gender Gender { get; set; }
        public Character Character { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
