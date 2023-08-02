using DotNetServer.Core.Wrappers;
using DotNetServer.Modules.NorwegianFoodModule.Entities;
using DotNetServer.Modules.NorwegianFoodModule.Mapping;
using DotNetServer.Modules.NorwegianFoodModule.Model.Requests;
using DotNetServer.Modules.NorwegianFoodModule.Model.Responses;
using DotNetServer.Modules.NorwegianFoodModule.Repositories;

namespace DotNetServer.Modules.NorwegianFoodModule.Services;

public class NorwegianFoodService : INorwegianFoodService
{
    private readonly CancellationTokenSource _cancellationTokenSource = new();
    private readonly INorwegianFoodRepository _norwegianFoodRepository;

    public NorwegianFoodService(INorwegianFoodRepository norwegianFoodRepository)
    {
        _norwegianFoodRepository = norwegianFoodRepository;
        _cancellationTokenSource.CancelAfter(10000);
    }

    public NorwegianFood? GetNorwegianFoodById(Guid id)
    {
        return _norwegianFoodRepository.GetNorwegianFoodById(id);
    }

    public async Task<Response<NorwegianFoodResponse>> GetNorwegianFoodByName(NorwegianFoodRequest request)
    {
        try
        {
            var dbResponse =
                await _norwegianFoodRepository.GetNorwegianFoodByName(request.FoodName, _cancellationTokenSource.Token);

            if (dbResponse is null)
                return new Response<NorwegianFoodResponse>
                {
                    Succeeded = false
                };

            var entityResponse = GetPerQuantityValues(dbResponse, request);

            var response = NorwegianFoodMapper.NorwegianFoodToNorwegianFoodResponse(entityResponse);

            return new Response<NorwegianFoodResponse>(response);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Response<List<NorwegianFoodResponse>>> GetNorwegianFoodsByNameList(
        List<NorwegianFoodRequest> requests)
    {
        throw new NotImplementedException();
    }

    // Check if Vitamin A RAE conversion is right
    private static NorwegianFood GetPerQuantityValues(NorwegianFood food, NorwegianFoodRequest request)
    {
        food.SpiseligDel = food.SpiseligDel * request.Quantity / 100;
        food.Vann = food.Vann * request.Quantity / 100;
        food.KilojouleKJ = food.KilojouleKJ * request.Quantity / 100;
        food.KilokalorierKcal = food.KilokalorierKcal * request.Quantity / 100;
        food.Fett = food.Fett * request.Quantity / 100;
        food.Mettet = food.Mettet * request.Quantity / 100;
        food.C12_0g = food.C12_0g * request.Quantity / 100;
        food.C14_0 = food.C14_0 * request.Quantity / 100;
        food.C16_0 = food.C16_0 * request.Quantity / 100;
        food.C18_0 = food.C18_0 * request.Quantity / 100;
        food.Trans = food.Trans * request.Quantity / 100;
        food.Enumettet = food.Enumettet * request.Quantity / 100;
        food.C16_1Sum = food.C16_1Sum * request.Quantity / 100;
        food.C18_1Sum = food.C18_1Sum * request.Quantity / 100;
        food.Flerumettet = food.Flerumettet * request.Quantity / 100;
        food.C18_2n_6 = food.C18_2n_6 * request.Quantity / 100;
        food.C18_3n_3 = food.C18_3n_3 * request.Quantity / 100;
        food.C20_3n_3 = food.C20_3n_3 * request.Quantity / 100;
        food.C20_3n_6 = food.C20_3n_6 * request.Quantity / 100;
        food.C20_4n_3 = food.C20_4n_3 * request.Quantity / 100;
        food.C20_4n_6 = food.C20_4n_6 * request.Quantity / 100;
        food.C20_5n_3_EPA = food.C20_5n_3_EPA * request.Quantity / 100;
        food.C22_5n_3_DPA = food.C22_5n_3_DPA * request.Quantity / 100;
        food.C22_6n_3_DHA = food.C22_6n_3_DHA * request.Quantity / 100;
        food.Omega_3 = food.Omega_3 * request.Quantity / 100;
        food.Omega_6 = food.Omega_6 * request.Quantity / 100;
        food.KolesterolMg = food.KolesterolMg * request.Quantity * 10;
        food.Karbohydrat = food.Karbohydrat * request.Quantity / 100;
        food.Stivelse = food.Stivelse * request.Quantity / 100;
        food.MonoPlusDisakk = food.MonoPlusDisakk * request.Quantity / 100;
        food.SukkerTilsatt = food.SukkerTilsatt * request.Quantity / 100;
        food.Kostfiber = food.Kostfiber * request.Quantity / 100;
        food.Protein = food.Protein * request.Quantity / 100;
        food.Salt = food.Salt * request.Quantity / 100;
        food.Alkohol = food.Alkohol * request.Quantity / 100;
        food.VitaminARAE = food.VitaminARAE * request.Quantity * 3000;
        food.RetinolMug = food.RetinolMug * request.Quantity * 10000;
        food.BetaKarotenMug = food.BetaKarotenMug * request.Quantity * 10000;
        food.VitaminDMug = food.VitaminDMug * request.Quantity * 10000;
        food.VitaminEAlfaTE = food.VitaminEAlfaTE * request.Quantity;
        food.TiaminMg = food.TiaminMg * request.Quantity * 10;
        food.RiboflavinMg = food.RiboflavinMg * request.Quantity * 10;
        food.NiacinMg = food.NiacinMg * request.Quantity * 10;
        food.VitaminB6Mg = food.VitaminB6Mg * request.Quantity * 10;
        food.FolatMug = food.FolatMug * request.Quantity * 10000;
        food.VitaminB12Mug = food.VitaminB12Mug * request.Quantity * 10000;
        food.VitaminCMg = food.VitaminCMg * request.Quantity * 10;
        food.KalsiumMg = food.KalsiumMg * request.Quantity * 10;
        food.JernMg = food.JernMg * request.Quantity * 10;
        food.NatriumMg = food.NatriumMg * request.Quantity * 10;
        food.KaliumMg = food.KaliumMg * request.Quantity * 10;
        food.MagnesiumMg = food.MagnesiumMg * request.Quantity * 10;
        food.SinkMg = food.SinkMg * request.Quantity * 10;
        food.SelenMug = food.SelenMug * request.Quantity * 10000;
        food.KopperMg = food.KopperMg * request.Quantity * 10;
        food.FosforMg = food.FosforMg * request.Quantity * 10;
        food.JodMug = food.JodMug * request.Quantity * 10000;

        return food;
    }
}