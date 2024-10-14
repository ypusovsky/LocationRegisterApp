﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Province> Provinces { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>().HasData(
            new Country { Id = 1, Name = "Country 1" },
            new Country { Id = 2, Name = "Country 2" }
        );
        modelBuilder.Entity<Province>().HasData(
            new Province { Id = 1, Name = "Province 1.1", CountryId = 1 },
            new Province { Id = 2, Name = "Province 1.2", CountryId = 1 },
            new Province { Id = 3, Name = "Province 2.1", CountryId = 2 }
        );
    }
}