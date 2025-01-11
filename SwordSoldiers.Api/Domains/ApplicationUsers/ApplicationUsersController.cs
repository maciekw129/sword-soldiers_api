using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SwordSoldiers.Api.ApplicationUsers.Dtos;
using SwordSoldiers.Infrastructure.Repositories;
using System.Security.Claims;

namespace SwordSoldiers.Api.Users
{
    [Route($"{Constants.protectedRoute}/users")]
    [ApiController]
    public class ApplicationUsersController(IApplicationUsersRepository applicationUsersRepository) : ControllerBase
    {
        private readonly IApplicationUsersRepository _applicationUsersRepository = applicationUsersRepository;

        [HttpGet("current")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser()
        {
            var currentUserAuthId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await applicationUsersRepository.GetByAuthIdAsync(currentUserAuthId);

            return Ok(currentUser);
        }

        [HttpPatch("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, [FromBody] UpdateApplicationUserDto updateApplicationUserDto)
        {
            var currentUserAuthId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await applicationUsersRepository.GetByAuthIdAsync(currentUserAuthId);

            if (currentUser.Id != id)
            {
                return Unauthorized();
            }

            var user = updateApplicationUserDto.UpdateApplicationUserDtoToApplicationUser();
            var updatedUser = await _applicationUsersRepository.UpdateAsync(id, user);

            if (updatedUser == null)
            {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _applicationUsersRepository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ApplicationUserToApplicationUserDto());
        }

        [HttpPost()]
        [Authorize]
        public async Task<IActionResult> CreateUser([FromBody] CreateApplicationUserDto createApplicationUserDto)
        {
            var currentUserAuthId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var currentUser = await _applicationUsersRepository.GetByAuthIdAsync(currentUserAuthId);

            if (currentUser != null)
            {
                return Conflict(currentUser);
            }

            var newUser = createApplicationUserDto.CreateApplicationUserDtoToApplicationUser();
            newUser.AuthId = currentUserAuthId;

            var createdUser = await _applicationUsersRepository.CreateAsync(newUser);

            return CreatedAtAction(nameof(GetCurrentUser), null, createdUser);
        }
    }
}
