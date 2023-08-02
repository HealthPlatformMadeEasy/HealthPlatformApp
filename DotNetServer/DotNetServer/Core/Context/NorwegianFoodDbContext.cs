using DotNetServer.Modules.NorwegianFoodModule.Entities;
using DotNetServer.Modules.NutrientModule.Entities;
using DotNetServer.Modules.UserModule.Entities;
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

    public virtual DbSet<Nutrient> Nutrients { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasAlternateKey(e => e.Email).HasName("email_pk");

            entity.HasAlternateKey(e => e.Name).HasName("name_pk");
        });
    }
}