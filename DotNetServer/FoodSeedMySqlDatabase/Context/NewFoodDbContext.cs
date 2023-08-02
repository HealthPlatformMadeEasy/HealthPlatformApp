using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using FoodSeedMySqlDatabase.Context.DataSeed;
using Microsoft.EntityFrameworkCore;

namespace FoodSeedMySqlDatabase.Context;

public class NewFoodDbContext : DbContext
{
    public NewFoodDbContext()
    {
    }

    public NewFoodDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<NewFood> Foods { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // parse CSV file
        using var reader = new StreamReader("Context/DataSeed/food_data_seed.csv");
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            HasHeaderRecord = true
        };
        using var csv = new CsvReader(reader, config);

        var records = csv.GetRecords<SeedFood>();
        var seedData = SeedMapper.SeedClassFoodToNewFood(records);

        modelBuilder.Entity<NewFood>().HasData(seedData);
    }
}