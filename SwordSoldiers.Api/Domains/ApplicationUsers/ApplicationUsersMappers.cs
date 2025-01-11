using SwordSoldiers.Api.ApplicationUsers.Dtos;
using SwordSoldiers.Domain.Entities;

namespace SwordSoldiers.Api.Users
{
    public static class ApplicationUsersMappers
    {
        public static ApplicationUserDto ApplicationUserToApplicationUserDto(this ApplicationUser user)
        {
            return new ApplicationUserDto()
            {
                Id = user.Id,
                Name = user.Name,
                Character = user.Character,
                Gender = user.Gender,
            };
        }

        public static ApplicationUser CreateApplicationUserDtoToApplicationUser(this CreateApplicationUserDto createUserDto)
        {
            return new ApplicationUser()
            {
                Name = createUserDto.Name,
                Gender = createUserDto.Gender,
                Character = createUserDto.Character
            };
        }

        public static ApplicationUser UpdateApplicationUserDtoToApplicationUser(this UpdateApplicationUserDto updateApplicationUserDto)
        {
            return new ApplicationUser()
            {
                Name = updateApplicationUserDto.Name,
                Gender = updateApplicationUserDto.Gender,
                Character = updateApplicationUserDto.Character
            };
        }
    }
}
