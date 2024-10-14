using LocationRegisterApp.Domain.Models;

namespace LocationRegisterApp.Application.Services.Interfaces
{
    public interface IUserService
    {
        Task<bool> Create(UserDto user);
    }
}
