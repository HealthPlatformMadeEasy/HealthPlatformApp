using DotNetServer.Modules.NorwegianFoodModule.Model.Requests;

namespace DotNetServer.Modules.NorwegianFoodModule.Model.DTO;

public class NorwegianFoodDto
{
    public Guid Id { get; set; }

    public string? FoodName { get; set; }
    public double? SpiseligDel { get; set; }
    public double? Vann { get; set; }
    public double? KilojouleKJ { get; set; }
    public double? KilokalorierKcal { get; set; }
    public double? Fett { get; set; }
    public double? Mettet { get; set; }
    public double? C12_0g { get; set; }
    public double? C14_0 { get; set; }
    public double? C16_0 { get; set; }
    public double? C18_0 { get; set; }
    public double? Trans { get; set; }
    public double? Enumettet { get; set; }
    public double? C16_1Sum { get; set; }
    public double? C18_1Sum { get; set; }
    public double? Flerumettet { get; set; }
    public double? C18_2n_6 { get; set; }
    public double? C18_3n_3 { get; set; }
    public double? C20_3n_3 { get; set; }
    public double? C20_3n_6 { get; set; }
    public double? C20_4n_3 { get; set; }
    public double? C20_4n_6 { get; set; }
    public double? C20_5n_3_EPA { get; set; }
    public double? C22_5n_3_DPA { get; set; }
    public double? C22_6n_3_DHA { get; set; }
    public double? Omega_3 { get; set; }
    public double? Omega_6 { get; set; }
    public double? KolesterolMg { get; set; }
    public double? Karbohydrat { get; set; }
    public double? Stivelse { get; set; }
    public double? MonoPlusDisakk { get; set; }
    public double? SukkerTilsatt { get; set; }
    public double? Kostfiber { get; set; }
    public double? Protein { get; set; }
    public double? Salt { get; set; }
    public double? Alkohol { get; set; }
    public double? VitaminARAE { get; set; }
    public double? RetinolMug { get; set; }
    public double? BetaKarotenMug { get; set; }
    public double? VitaminDMug { get; set; }
    public double? VitaminEAlfaTE { get; set; }
    public double? TiaminMg { get; set; }
    public double? RiboflavinMg { get; set; }
    public double? NiacinMg { get; set; }
    public double? VitaminB6Mg { get; set; }
    public double? FolatMug { get; set; }
    public double? VitaminB12Mug { get; set; }
    public double? VitaminCMg { get; set; }
    public double? KalsiumMg { get; set; }
    public double? JernMg { get; set; }
    public double? NatriumMg { get; set; }
    public double? KaliumMg { get; set; }
    public double? MagnesiumMg { get; set; }
    public double? SinkMg { get; set; }
    public double? SelenMug { get; set; }
    public double? KopperMg { get; set; }
    public double? FosforMg { get; set; }
    public double? JodMug { get; set; }

    // TODO Check if Vitamin A RAE conversion is right
    public void SetPerQuantityValues(NorwegianFoodDto food, NorwegianFoodRequest request)
    {
        SpiseligDel = food.SpiseligDel * request.Quantity / 100;
        Vann = food.Vann * request.Quantity / 100;
        KilojouleKJ = food.KilojouleKJ * request.Quantity / 100;
        KilokalorierKcal = food.KilokalorierKcal * request.Quantity / 100;
        Fett = food.Fett * request.Quantity / 100;
        Mettet = food.Mettet * request.Quantity / 100;
        C12_0g = food.C12_0g * request.Quantity / 100;
        C14_0 = food.C14_0 * request.Quantity / 100;
        C16_0 = food.C16_0 * request.Quantity / 100;
        C18_0 = food.C18_0 * request.Quantity / 100;
        Trans = food.Trans * request.Quantity / 100;
        Enumettet = food.Enumettet * request.Quantity / 100;
        C16_1Sum = food.C16_1Sum * request.Quantity / 100;
        C18_1Sum = food.C18_1Sum * request.Quantity / 100;
        Flerumettet = food.Flerumettet * request.Quantity / 100;
        C18_2n_6 = food.C18_2n_6 * request.Quantity / 100;
        C18_3n_3 = food.C18_3n_3 * request.Quantity / 100;
        C20_3n_3 = food.C20_3n_3 * request.Quantity / 100;
        C20_3n_6 = food.C20_3n_6 * request.Quantity / 100;
        C20_4n_3 = food.C20_4n_3 * request.Quantity / 100;
        C20_4n_6 = food.C20_4n_6 * request.Quantity / 100;
        C20_5n_3_EPA = food.C20_5n_3_EPA * request.Quantity / 100;
        C22_5n_3_DPA = food.C22_5n_3_DPA * request.Quantity / 100;
        C22_6n_3_DHA = food.C22_6n_3_DHA * request.Quantity / 100;
        Omega_3 = food.Omega_3 * request.Quantity / 100;
        Omega_6 = food.Omega_6 * request.Quantity / 100;
        KolesterolMg = food.KolesterolMg * request.Quantity * 10;
        Karbohydrat = food.Karbohydrat * request.Quantity / 100;
        Stivelse = food.Stivelse * request.Quantity / 100;
        MonoPlusDisakk = food.MonoPlusDisakk * request.Quantity / 100;
        SukkerTilsatt = food.SukkerTilsatt * request.Quantity / 100;
        Kostfiber = food.Kostfiber * request.Quantity / 100;
        Protein = food.Protein * request.Quantity / 100;
        Salt = food.Salt * request.Quantity / 100;
        Alkohol = food.Alkohol * request.Quantity / 100;
        VitaminARAE = food.VitaminARAE * request.Quantity / 30000000;
        RetinolMug = food.RetinolMug * request.Quantity / 100000000;
        BetaKarotenMug = food.BetaKarotenMug * request.Quantity / 100000000;
        VitaminDMug = food.VitaminDMug * request.Quantity / 100000000;
        VitaminEAlfaTE = food.VitaminEAlfaTE * request.Quantity;
        TiaminMg = food.TiaminMg * request.Quantity / 100000;
        RiboflavinMg = food.RiboflavinMg * request.Quantity / 100000;
        NiacinMg = food.NiacinMg * request.Quantity / 100000;
        VitaminB6Mg = food.VitaminB6Mg * request.Quantity / 100000;
        FolatMug = food.FolatMug * request.Quantity / 100000000;
        VitaminB12Mug = food.VitaminB12Mug * request.Quantity / 100000000;
        VitaminCMg = food.VitaminCMg * request.Quantity / 100000;
        KalsiumMg = food.KalsiumMg * request.Quantity / 100000;
        JernMg = food.JernMg * request.Quantity / 100000;
        NatriumMg = food.NatriumMg * request.Quantity / 100000;
        KaliumMg = food.KaliumMg * request.Quantity / 100000;
        MagnesiumMg = food.MagnesiumMg * request.Quantity / 100000;
        SinkMg = food.SinkMg * request.Quantity / 100000;
        SelenMug = food.SelenMug * request.Quantity / 100000000;
        KopperMg = food.KopperMg * request.Quantity / 100000;
        FosforMg = food.FosforMg * request.Quantity / 100000;
        JodMug = food.JodMug * request.Quantity / 100000000;
    }
}