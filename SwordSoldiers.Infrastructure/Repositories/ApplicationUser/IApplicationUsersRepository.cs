using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure.Repositories
{
    public interface IApplicationUsersRepository
    {
        Task<ApplicationUser?> GetByIdAsync(Guid id);
        Task<ApplicationUser?> GetByAuthIdAsync(string authId);
        Task<ApplicationUser?> CreateAsync(ApplicationUser user);
        Task<ApplicationUser> UpdateAsync(Guid id, ApplicationUser applicationUserDocument);
        Task<bool> ExistById(Guid id);
    }
}
