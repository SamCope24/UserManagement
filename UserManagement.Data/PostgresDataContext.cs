using System;
using Microsoft.EntityFrameworkCore;
using UserManagement.Data.Entities;

namespace UserManagement.Data;

public class PostgresDataContext : DataContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        if (options is null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        options.UseNpgsql("Host=localhost;Database=users;Username=postgres;Password=postgres;Port=5432");
        options.UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder model)
        => model.Entity<User>().HasData(new[]
        {
            new User { Id = 1, Forename = "Luke", Surname = "Skywalker", Email = "luke@jointhealliance.com", IsActive = true, DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 2, Forename = "Leia", Surname = "Organa", Email = "leia@jointhealliance.com", IsActive = true, DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 3, Forename = "Han", Surname = "Solo", Email = "han@jointhealliance.com", IsActive = false, DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 4, Forename = "Darth", Surname = "Vader", Email = "vader@thedeathstar.org", IsActive = true, DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 5, Forename = "Yoda", Surname = "", Email = "yoda@jointhealliance.com", IsActive = true, DateOfBirth = new DateTime(896, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 6, Forename = "Obi-Wan", Surname = "Kenobi", Email = "obiwan@jointhealliance.com", IsActive = true, DateOfBirth = new DateTime(57, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 7, Forename = "Anakin", Surname = "Skywalker", Email = "anakin@thedeathstar.org", IsActive = false, DateOfBirth = new DateTime(41, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 8, Forename = "Padmé", Surname = "Amidala", Email = "padme@jointhealliance.com", IsActive = false, DateOfBirth = new DateTime(46, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 9, Forename = "Chewbacca", Surname = "", Email = "chewie@jointhealliance.com", IsActive = false, DateOfBirth = new DateTime(200, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 10, Forename = "Mace", Surname = "Windu", Email = "mace@jointhealliance.com", IsActive = true, DateOfBirth = new DateTime(72, 5, 25, 0, 0, 0, DateTimeKind.Utc) },
            new User { Id = 11, Forename = "Rey", Surname = "", Email = "rey@jointhealliance.com", IsActive = true, DateOfBirth = new DateTime(15, 5, 25, 0, 0, 0, DateTimeKind.Utc) }
        });
}