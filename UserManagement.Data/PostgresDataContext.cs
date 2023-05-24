using System;
using Microsoft.EntityFrameworkCore;

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
}