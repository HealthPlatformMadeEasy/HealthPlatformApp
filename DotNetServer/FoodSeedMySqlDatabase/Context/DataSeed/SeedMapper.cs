using Riok.Mapperly.Abstractions;

namespace FoodSeedMySqlDatabase.Context.DataSeed;

[Mapper]
public static partial class SeedMapper
{
    public static partial IEnumerable<NewFood> SeedClassFoodToNewFood(IEnumerable<SeedFood> seedFood);
}