using DotNetServer.Modules.NorwegianFoodModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Context;

public class NorwegianFoodDbContext : DbContext
{
    public NorwegianFoodDbContext()
    {
    }

    public NorwegianFoodDbContext(DbContextOptions<NorwegianFoodDbContext> options) : base(options)
    {
    }

    public virtual DbSet<NorwegianFood> Foods { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
}