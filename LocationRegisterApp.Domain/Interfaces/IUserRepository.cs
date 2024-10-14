using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> CreateAsync(UserDto user);
    }
}
