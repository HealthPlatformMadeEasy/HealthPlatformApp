using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using DotNetServer.Core.Context.DataSeed;
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
        using var reader = new StreamReader("Core/Context/DataSeed/food_data_seed.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };
        using var csv = new CsvReader(reader, config);

        var records = csv.GetRecords<SeedFood>();
        var seedData = SeedMapper.SeedClassFoodToNewFood(records);

        modelBuilder.Entity<NorwegianFood>().HasData(seedData);

        modelBuilder.Entity<Nutrient>();

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasAlternateKey(e => e.Email).HasName("email_pk");

            entity.HasAlternateKey(e => e.Name).HasName("name_pk");
        });
    }
}