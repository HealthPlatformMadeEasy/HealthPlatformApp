using DotNetServer.Modules.NorwegianFoodModule.Entities;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Core.Context.DataSeed;

[Mapper]
public static partial class SeedMapper
{
    public static partial IEnumerable<NorwegianFood> SeedClassFoodToNewFood(IEnumerable<SeedFood> seedFood);
}