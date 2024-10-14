using LocationRegisterApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocationRegisterApp.Infrastructure
{
    public interface IApplicationDbContext
    {
        DbSet<CountryEntity> Countries { get; set; }
        DbSet<ProvinceEntity> Provinces { get; set; }
        DbSet<UserEntity> Users { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
