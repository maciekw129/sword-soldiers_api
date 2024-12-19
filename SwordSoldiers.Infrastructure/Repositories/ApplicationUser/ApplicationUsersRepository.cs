using Microsoft.EntityFrameworkCore;
using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Infrastructure.Repositories
{
    public class ApplicationUsersRepository(ApplicationDbContext _applicationDbContext) : IApplicationUsersRepository
    {
        public async Task<bool> ExistById(Guid id)
        {
            return await _applicationDbContext.ApplicationUsers.AnyAsync(user => user.Id == id);
        }

        public async Task<ApplicationUser?> GetByIdAsync(Guid id)
        {
            return await _applicationDbContext.ApplicationUsers.FindAsync(id);
        }

        public async Task<ApplicationUser?> GetByAuthIdAsync(string authId)
        {
            return await _applicationDbContext.ApplicationUsers.FirstOrDefaultAsync(user => user.AuthId == authId);
        }

        public async Task<ApplicationUser?> CreateAsync(ApplicationUser applicationUser)
        {
            await _applicationDbContext.ApplicationUsers.AddAsync(applicationUser);
            await _applicationDbContext.SaveChangesAsync();
            return applicationUser;
        }

        public async Task<ApplicationUser> UpdateAsync(Guid id, ApplicationUser updatedApplicationUser)
        {
            var applicationUser = await GetByIdAsync(id);

            if (applicationUser == null)
            {
                return applicationUser;
            }

            applicationUser.Name = updatedApplicationUser.Name;
            applicationUser.Character = updatedApplicationUser.Character;
            applicationUser.Gender = updatedApplicationUser.Gender;
            
            await _applicationDbContext.SaveChangesAsync();

            return applicationUser;
        }
    }
}
