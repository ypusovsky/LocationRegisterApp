using LocationRegisterApp.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace LocationRegisterApp.Infrastructure
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }
        public ApplicationDbContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<CountryEntity> Countries { get; set; }
        public DbSet<ProvinceEntity> Provinces { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RegistrationAppDb;Trusted_Connection=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CountryEntity>().HasData(
                new CountryEntity { Id = 1, Name = "Belarus" },
                new CountryEntity { Id = 2, Name = "Germany" },
                new CountryEntity { Id = 3, Name = "USA" }
            );
            modelBuilder.Entity<ProvinceEntity>().HasData(
                new ProvinceEntity { Id = 1, Name = "Minsk", CountryId = 1 },
                new ProvinceEntity { Id = 2, Name = "Mogilev", CountryId = 1 },
                new ProvinceEntity { Id = 3, Name = "Berlin", CountryId = 2 },
                new ProvinceEntity { Id = 4, Name = "Munich", CountryId = 2 },
                new ProvinceEntity { Id = 5, Name = "Detroit", CountryId = 3 },
                new ProvinceEntity { Id = 6, Name = "Las Vegas", CountryId = 3 }
            );
            modelBuilder.Entity<UserEntity>()
                .HasOne(u => u.Province)
                .WithMany(p => p.Users)
                .HasForeignKey(u => u.ProvinceId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<UserEntity>()
                .HasIndex(u => u.Email)
                .IsUnique();
        }
    }
}
