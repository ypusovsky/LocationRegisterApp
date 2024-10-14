using LocationRegisterApp.Application.Services.Interfaces;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Application.Services
{
    public class UserService(IUserRepository userRepository) : IUserService
    {
        public async Task<bool> Create(UserDto user)
        {
            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            return await userRepository.CreateAsync(new UserDto(
                user.Email,
                hashedPassword,
                user.CountryId,
                user.ProvinceId
            ));
        }
    }
}
