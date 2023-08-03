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

            if (dbResponse is null) return new Response<NorwegianFoodResponse> { Succeeded = false };

            var entityResponse = GetPerQuantityValues(dbResponse, request);

            var response = NorwegianFoodMapper.NorwegianFoodToNorwegianFoodResponse(entityResponse);

            return new Response<NorwegianFoodResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<NorwegianFoodResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    // TODO make extra function to open endpoint for test
    public async Task<TotalNutrientsResponse?> GetNorwegianFoodsByNameList(
        List<NorwegianFoodRequest> requests)
    {
        var dbResponses = await
            _norwegianFoodRepository.GetNorwegianFoodsByNameList(requests.Select(row => row.FoodName).ToList(),
                _cancellationTokenSource.Token);

        var sortedDbResponse = dbResponses!.OrderBy(row => row.FoodName).ToList();
        var sortedRequests = requests.OrderBy(row => row.FoodName).ToList();

        var entityResponse = sortedDbResponse.Select((item, index) => (item, index))
            .Select(row => GetPerQuantityValues(row.item, sortedRequests[row.index])).ToList();

        var response = GetTotalNutrientsResponse(entityResponse);

        return response;
    }

    public async Task<Response<TotalNutrientsResponse>> GetNorwegianFoodsByNameListOpenEndPoint(
        List<NorwegianFoodRequest> requests)
    {
        try
        {
            var response = await GetNorwegianFoodsByNameList(requests);

            return response is null
                ? new Response<TotalNutrientsResponse> { Succeeded = false }
                : new Response<TotalNutrientsResponse>(response);
        }
        catch (Exception e)
        {
            return new Response<TotalNutrientsResponse>
            {
                Succeeded = false,
                Errors = e.Message
            };
        }
    }

    public async Task<Response<TotalNutrientsResponse>> AddToNutrientsAndGetNorwegianFoods(
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

    private static TotalNutrientsResponse GetTotalNutrientsResponse(List<NorwegianFood> requests)
    {
        var response = new TotalNutrientsResponse
        {
            CreatedAt = DateTime.Now,
            SpiseligDel = requests.Sum(row => row.SpiseligDel),
            Vann = requests.Sum(row => row.Vann),
            KilojouleKJ = requests.Sum(row => row.KilojouleKJ),
            KilokalorierKcal = requests.Sum(row => row.KilokalorierKcal),
            Fett = requests.Sum(row => row.Fett),
            Mettet = requests.Sum(row => row.Mettet),
            C12_0g = requests.Sum(row => row.C12_0g),
            C14_0 = requests.Sum(row => row.C14_0),
            C16_0 = requests.Sum(row => row.C16_0),
            C18_0 = requests.Sum(row => row.C18_0),
            Trans = requests.Sum(row => row.Trans),
            Enumettet = requests.Sum(row => row.Enumettet),
            C16_1Sum = requests.Sum(row => row.C16_1Sum),
            C18_1Sum = requests.Sum(row => row.C18_1Sum),
            Flerumettet = requests.Sum(row => row.Flerumettet),
            C18_2n_6 = requests.Sum(row => row.C18_2n_6),
            C18_3n_3 = requests.Sum(row => row.C18_3n_3),
            C20_3n_3 = requests.Sum(row => row.C20_3n_3),
            C20_3n_6 = requests.Sum(row => row.C20_3n_6),
            C20_4n_3 = requests.Sum(row => row.C20_4n_3),
            C20_4n_6 = requests.Sum(row => row.C20_4n_6),
            C20_5n_3_EPA = requests.Sum(row => row.C20_5n_3_EPA),
            C22_5n_3_DPA = requests.Sum(row => row.C22_5n_3_DPA),
            C22_6n_3_DHA = requests.Sum(row => row.C22_6n_3_DHA),
            Omega_3 = requests.Sum(row => row.Omega_3),
            Omega_6 = requests.Sum(row => row.Omega_6),
            KolesterolMg = requests.Sum(row => row.KolesterolMg),
            Karbohydrat = requests.Sum(row => row.Karbohydrat),
            Stivelse = requests.Sum(row => row.Stivelse),
            MonoPlusDisakk = requests.Sum(row => row.MonoPlusDisakk),
            SukkerTilsatt = requests.Sum(row => row.SukkerTilsatt),
            Kostfiber = requests.Sum(row => row.Kostfiber),
            Protein = requests.Sum(row => row.Protein),
            Salt = requests.Sum(row => row.Salt),
            Alkohol = requests.Sum(row => row.Alkohol),
            VitaminARAE = requests.Sum(row => row.VitaminARAE),
            RetinolMug = requests.Sum(row => row.RetinolMug),
            BetaKarotenMug = requests.Sum(row => row.BetaKarotenMug),
            VitaminDMug = requests.Sum(row => row.VitaminDMug),
            VitaminEAlfaTE = requests.Sum(row => row.VitaminEAlfaTE),
            TiaminMg = requests.Sum(row => row.TiaminMg),
            RiboflavinMg = requests.Sum(row => row.RiboflavinMg),
            NiacinMg = requests.Sum(row => row.NiacinMg),
            VitaminB6Mg = requests.Sum(row => row.VitaminB6Mg),
            FolatMug = requests.Sum(row => row.FolatMug),
            VitaminB12Mug = requests.Sum(row => row.VitaminB12Mug),
            VitaminCMg = requests.Sum(row => row.VitaminCMg),
            KalsiumMg = requests.Sum(row => row.KalsiumMg),
            JernMg = requests.Sum(row => row.JernMg),
            NatriumMg = requests.Sum(row => row.NatriumMg),
            KaliumMg = requests.Sum(row => row.KaliumMg),
            MagnesiumMg = requests.Sum(row => row.MagnesiumMg),
            SinkMg = requests.Sum(row => row.SinkMg),
            SelenMug = requests.Sum(row => row.SelenMug),
            KopperMg = requests.Sum(row => row.KopperMg),
            FosforMg = requests.Sum(row => row.FosforMg),
            JodMug = requests.Sum(row => row.JodMug)
        };

        return response;
    }
}