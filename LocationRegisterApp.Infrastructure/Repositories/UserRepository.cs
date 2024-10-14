using AutoMapper;
using LocationRegisterApp.Domain.Interfaces;
using LocationRegisterApp.Domain.Models;
using LocationRegisterApp.Infrastructure.Entities;

namespace LocationRegisterApp.Infrastructure.Repositories
{
    public class UserRepository(
        IApplicationDbContext context,
        IMapper mapper,
        IDateTimeProvider dateTimeProvider) : IUserRepository
    {
        public async Task<bool> CreateAsync(UserDto user)
        {
            var userEntity = mapper.Map<UserEntity>(user);
            userEntity.CreatedAt = dateTimeProvider.UtcNow;
            await context.Users
                .AddAsync(userEntity);
            await context.SaveChangesAsync();

            return true;
        }
    }
}
