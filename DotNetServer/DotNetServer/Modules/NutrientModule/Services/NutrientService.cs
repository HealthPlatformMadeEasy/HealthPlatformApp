using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.NutrientModule.Mapping;
using DotNetServer.Modules.NutrientModule.Model.Requests;
using DotNetServer.Modules.NutrientModule.Model.Responses;
using DotNetServer.Modules.NutrientModule.Repositories;

namespace DotNetServer.Modules.NutrientModule.Services;

public class NutrientService : INutrientService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly INutrientRepository _nutrientRepository;

    public NutrientService(INutrientRepository nutrientRepository)
    {
        _nutrientRepository = nutrientRepository;
        _cancellationTokenSource.CancelAfter(1000000);
    }

    public async Task<Response<NutrientResponse>> GetNutrientByIdAsync(Guid id)
    {
        try
        {
            var dbResponse = await _nutrientRepository.GetNutrientByIdAsync(id, _cancellationTokenSource.Token);

            if (dbResponse is null) return new Response<NutrientResponse> { Succeeded = false };

            var response = NutrientMapper.NutrientToNutrientResponse(dbResponse);

            return new Response<NutrientResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<NutrientResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task AddNutrientAsync(NutrientRequest nutrient)
    {
        var nutrientDb = NutrientMapper.NutrientRequestToNutrient(nutrient);

        await _nutrientRepository.AddNutrientAsync(nutrientDb, _cancellationTokenSource.Token);
    }

    public async Task AddManyNutrientsAsync(List<NutrientRequest> nutrients)
    {
        var nutrientsDb = NutrientMapper.ManyNutrientRequestToManyNutrient(nutrients);

        await _nutrientRepository.AddManyNutrientsAsync(nutrientsDb, _cancellationTokenSource.Token);
    }

    public async Task DeleteNutrientAsync(Guid id)
    {
        await _nutrientRepository.DeleteNutrientAsync(id, _cancellationTokenSource.Token);
    }

    public async Task<Response<EnergyAndMacroResponse>> GetEnergyAndMacros(Guid userId)
    {
        try
        {
            var dbResponse = await _nutrientRepository.GetEnergyAndMacros(userId, _cancellationTokenSource.Token);

            if (dbResponse is null) return new Response<EnergyAndMacroResponse> { Succeeded = false };

            var response = new EnergyAndMacroResponse();

            response.SetEnergyAndMacrosResponseFromList(dbResponse);

            return new Response<EnergyAndMacroResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<EnergyAndMacroResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task<EnergyAndMacroResponse> GetMacros(Guid userId)
    {
        var dbResponse = await _nutrientRepository.GetEnergyAndMacros(userId, _cancellationTokenSource.Token);

        var response = new EnergyAndMacroResponse();
        response.SetEnergyAndMacrosResponseFromList(dbResponse);

        return response;
    }
}