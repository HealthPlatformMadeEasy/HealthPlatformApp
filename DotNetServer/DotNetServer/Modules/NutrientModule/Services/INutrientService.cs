using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.NutrientModule.Model.Requests;
using DotNetServer.Modules.NutrientModule.Model.Responses;

namespace DotNetServer.Modules.NutrientModule.Services;

public interface INutrientService
{
    Task<Response<NutrientResponse>> GetNutrientByIdAsync(Guid id);

    Task AddNutrientAsync(NutrientRequest nutrient);

    Task AddManyNutrientsAsync(List<NutrientRequest> nutrients);

    Task DeleteNutrientAsync(Guid id);

    Task<Response<EnergyAndMacroResponse>> GetEnergyAndMacros(Guid userId);

    Task<EnergyAndMacroResponse> GetMacros(Guid userId);
}