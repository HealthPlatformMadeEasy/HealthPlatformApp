using DotNetServer.Modules.NorwegianFoodModule.Entities;
using DotNetServer.Modules.NorwegianFoodModule.Model.DTO;
using DotNetServer.Modules.NorwegianFoodModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Modules.NorwegianFoodModule.Mapping;

[Mapper]
public static partial class NorwegianFoodMapper
{
    public static partial NorwegianFoodResponse NorwegianFoodToNorwegianFoodResponse(NorwegianFood norwegianFood);

    public static partial NorwegianFoodDto NorwegianFoodToNorwegianFoodDto(NorwegianFood norwegianFood);

    public static partial List<NorwegianFoodDto> ListNorwegianFoodToNorwegianFoodDto(List<NorwegianFood> norwegianFood);
}