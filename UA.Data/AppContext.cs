using System.Reflection;
using Microsoft.EntityFrameworkCore;
using UA.Data.Models;

namespace UA.Data;

public sealed class AppContext : DbContext
{
    public AppContext(DbContextOptions<AppContext> options) : base(options)
    {
    }

    public DbSet<Role> Roles { get; }
    public DbSet<User> Users { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}