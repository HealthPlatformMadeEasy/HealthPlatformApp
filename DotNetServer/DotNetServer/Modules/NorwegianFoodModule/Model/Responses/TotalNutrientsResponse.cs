using DotNetServer.Modules.NorwegianFoodModule.Entities;

namespace DotNetServer.Modules.NorwegianFoodModule.Model.Responses;

public class TotalNutrientsResponse
{
    public DateTime CreatedAt { get; set; }
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

    public void GetTotalNutrientsResponse(List<NorwegianFood> requests)
    {
        CreatedAt = DateTime.Now;
        SpiseligDel = requests.Sum(row => row.SpiseligDel);
        Vann = requests.Sum(row => row.Vann);
        KilojouleKJ = requests.Sum(row => row.KilojouleKJ);
        KilokalorierKcal = requests.Sum(row => row.KilokalorierKcal);
        Fett = requests.Sum(row => row.Fett);
        Mettet = requests.Sum(row => row.Mettet);
        C12_0g = requests.Sum(row => row.C12_0g);
        C14_0 = requests.Sum(row => row.C14_0);
        C16_0 = requests.Sum(row => row.C16_0);
        C18_0 = requests.Sum(row => row.C18_0);
        Trans = requests.Sum(row => row.Trans);
        Enumettet = requests.Sum(row => row.Enumettet);
        C16_1Sum = requests.Sum(row => row.C16_1Sum);
        C18_1Sum = requests.Sum(row => row.C18_1Sum);
        Flerumettet = requests.Sum(row => row.Flerumettet);
        C18_2n_6 = requests.Sum(row => row.C18_2n_6);
        C18_3n_3 = requests.Sum(row => row.C18_3n_3);
        C20_3n_3 = requests.Sum(row => row.C20_3n_3);
        C20_3n_6 = requests.Sum(row => row.C20_3n_6);
        C20_4n_3 = requests.Sum(row => row.C20_4n_3);
        C20_4n_6 = requests.Sum(row => row.C20_4n_6);
        C20_5n_3_EPA = requests.Sum(row => row.C20_5n_3_EPA);
        C22_5n_3_DPA = requests.Sum(row => row.C22_5n_3_DPA);
        C22_6n_3_DHA = requests.Sum(row => row.C22_6n_3_DHA);
        Omega_3 = requests.Sum(row => row.Omega_3);
        Omega_6 = requests.Sum(row => row.Omega_6);
        KolesterolMg = requests.Sum(row => row.KolesterolMg);
        Karbohydrat = requests.Sum(row => row.Karbohydrat);
        Stivelse = requests.Sum(row => row.Stivelse);
        MonoPlusDisakk = requests.Sum(row => row.MonoPlusDisakk);
        SukkerTilsatt = requests.Sum(row => row.SukkerTilsatt);
        Kostfiber = requests.Sum(row => row.Kostfiber);
        Protein = requests.Sum(row => row.Protein);
        Salt = requests.Sum(row => row.Salt);
        Alkohol = requests.Sum(row => row.Alkohol);
        VitaminARAE = requests.Sum(row => row.VitaminARAE);
        RetinolMug = requests.Sum(row => row.RetinolMug);
        BetaKarotenMug = requests.Sum(row => row.BetaKarotenMug);
        VitaminDMug = requests.Sum(row => row.VitaminDMug);
        VitaminEAlfaTE = requests.Sum(row => row.VitaminEAlfaTE);
        TiaminMg = requests.Sum(row => row.TiaminMg);
        RiboflavinMg = requests.Sum(row => row.RiboflavinMg);
        NiacinMg = requests.Sum(row => row.NiacinMg);
        VitaminB6Mg = requests.Sum(row => row.VitaminB6Mg);
        FolatMug = requests.Sum(row => row.FolatMug);
        VitaminB12Mug = requests.Sum(row => row.VitaminB12Mug);
        VitaminCMg = requests.Sum(row => row.VitaminCMg);
        KalsiumMg = requests.Sum(row => row.KalsiumMg);
        JernMg = requests.Sum(row => row.JernMg);
        NatriumMg = requests.Sum(row => row.NatriumMg);
        KaliumMg = requests.Sum(row => row.KaliumMg);
        MagnesiumMg = requests.Sum(row => row.MagnesiumMg);
        SinkMg = requests.Sum(row => row.SinkMg);
        SelenMug = requests.Sum(row => row.SelenMug);
        KopperMg = requests.Sum(row => row.KopperMg);
        FosforMg = requests.Sum(row => row.FosforMg);
        JodMug = requests.Sum(row => row.JodMug);
    }
}