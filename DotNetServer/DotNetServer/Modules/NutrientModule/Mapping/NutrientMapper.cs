using DotNetServer.Modules.NutrientModule.Entities;
using DotNetServer.Modules.NutrientModule.Model.Requests;
using DotNetServer.Modules.NutrientModule.Model.Responses;
using Riok.Mapperly.Abstractions;

namespace DotNetServer.Modules.NutrientModule.Mapping;

[Mapper]
public static partial class NutrientMapper
{
    public static partial NutrientResponse NutrientToNutrientResponse(Nutrient nutrient);

    public static partial Nutrient NutrientRequestToNutrient(NutrientRequest nutrient);

    public static partial List<Nutrient> ManyNutrientRequestToManyNutrient(List<NutrientRequest> nutrient);
}