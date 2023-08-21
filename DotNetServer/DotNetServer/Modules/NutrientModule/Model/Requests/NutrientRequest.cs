using DotNetServer.Modules.NorwegianFoodModule.Model.Responses;

namespace DotNetServer.Modules.NutrientModule.Model.Requests;

public class NutrientRequest
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid UserId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
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

    public void SetNutrientRequest(TotalNutrientsResponse nutrient, Guid userId)
    {
        UserId = userId;
        SpiseligDel = nutrient.SpiseligDel;
        Vann = nutrient.Vann;
        KilojouleKJ = nutrient.KilojouleKJ;
        KilokalorierKcal = nutrient.KilokalorierKcal;
        Fett = nutrient.Fett;
        Mettet = nutrient.Mettet;
        C12_0g = nutrient.C12_0g;
        C14_0 = nutrient.C14_0;
        C16_0 = nutrient.C16_0;
        C18_0 = nutrient.C18_0;
        Trans = nutrient.Trans;
        Enumettet = nutrient.Enumettet;
        C16_1Sum = nutrient.C16_1Sum;
        C18_1Sum = nutrient.C18_1Sum;
        Flerumettet = nutrient.Flerumettet;
        C18_2n_6 = nutrient.C18_2n_6;
        C18_3n_3 = nutrient.C18_3n_3;
        C20_3n_3 = nutrient.C20_3n_3;
        C20_3n_6 = nutrient.C20_3n_6;
        C20_4n_3 = nutrient.C20_4n_3;
        C20_4n_6 = nutrient.C20_4n_6;
        C20_5n_3_EPA = nutrient.C20_5n_3_EPA;
        C22_5n_3_DPA = nutrient.C22_5n_3_DPA;
        C22_6n_3_DHA = nutrient.C22_6n_3_DHA;
        Omega_3 = nutrient.Omega_3;
        Omega_6 = nutrient.Omega_6;
        KolesterolMg = nutrient.KolesterolMg;
        Karbohydrat = nutrient.Karbohydrat;
        Stivelse = nutrient.Stivelse;
        MonoPlusDisakk = nutrient.MonoPlusDisakk;
        SukkerTilsatt = nutrient.SukkerTilsatt;
        Kostfiber = nutrient.Kostfiber;
        Protein = nutrient.Protein;
        Salt = nutrient.Salt;
        Alkohol = nutrient.Alkohol;
        VitaminARAE = nutrient.VitaminARAE;
        RetinolMug = nutrient.RetinolMug;
        BetaKarotenMug = nutrient.BetaKarotenMug;
        VitaminDMug = nutrient.VitaminDMug;
        VitaminEAlfaTE = nutrient.VitaminEAlfaTE;
        TiaminMg = nutrient.TiaminMg;
        RiboflavinMg = nutrient.RiboflavinMg;
        NiacinMg = nutrient.NiacinMg;
        VitaminB6Mg = nutrient.VitaminB6Mg;
        FolatMug = nutrient.FolatMug;
        VitaminB12Mug = nutrient.VitaminB12Mug;
        VitaminCMg = nutrient.VitaminCMg;
        KalsiumMg = nutrient.KalsiumMg;
        JernMg = nutrient.JernMg;
        NatriumMg = nutrient.NatriumMg;
        KaliumMg = nutrient.KaliumMg;
        MagnesiumMg = nutrient.MagnesiumMg;
        SinkMg = nutrient.SinkMg;
        SelenMug = nutrient.SelenMug;
        KopperMg = nutrient.KopperMg;
        FosforMg = nutrient.FosforMg;
        JodMug = nutrient.JodMug;
    }
}