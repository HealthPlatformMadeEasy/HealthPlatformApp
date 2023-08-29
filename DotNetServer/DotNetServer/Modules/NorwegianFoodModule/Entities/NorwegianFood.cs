using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Modules.NorwegianFoodModule.Entities;

[Table("foods")]
public class NorwegianFood
{
    public NorwegianFood()
    {
        
    }
    public NorwegianFood(Guid id, string? foodName, double? spiseligDel, double? vann, double? kilojouleKj, double? kilokalorierKcal, double? fett, double? mettet, double? c120G, double? c140, double? c160, double? c180, double? trans, double? enumettet, double? c161Sum, double? c181Sum, double? flerumettet, double? c182N6, double? c183N3, double? c203N3, double? c203N6, double? c204N3, double? c204N6, double? c205N3Epa, double? c225N3Dpa, double? c226N3Dha, double? omega3, double? omega6, double? kolesterolMg, double? karbohydrat, double? stivelse, double? monoPlusDisakk, double? sukkerTilsatt, double? kostfiber, double? protein, double? salt, double? alkohol, double? vitaminArae, double? retinolMug, double? betaKarotenMug, double? vitaminDMug, double? vitaminEAlfaTe, double? tiaminMg, double? riboflavinMg, double? niacinMg, double? vitaminB6Mg, double? folatMug, double? vitaminB12Mug, double? vitaminCMg, double? kalsiumMg, double? jernMg, double? natriumMg, double? kaliumMg, double? magnesiumMg, double? sinkMg, double? selenMug, double? kopperMg, double? fosforMg, double? jodMug)
    {
        Id = id;
        FoodName = foodName;
        SpiseligDel = spiseligDel;
        Vann = vann;
        KilojouleKJ = kilojouleKj;
        KilokalorierKcal = kilokalorierKcal;
        Fett = fett;
        Mettet = mettet;
        C12_0g = c120G;
        C14_0 = c140;
        C16_0 = c160;
        C18_0 = c180;
        Trans = trans;
        Enumettet = enumettet;
        C16_1Sum = c161Sum;
        C18_1Sum = c181Sum;
        Flerumettet = flerumettet;
        C18_2n_6 = c182N6;
        C18_3n_3 = c183N3;
        C20_3n_3 = c203N3;
        C20_3n_6 = c203N6;
        C20_4n_3 = c204N3;
        C20_4n_6 = c204N6;
        C20_5n_3_EPA = c205N3Epa;
        C22_5n_3_DPA = c225N3Dpa;
        C22_6n_3_DHA = c226N3Dha;
        Omega_3 = omega3;
        Omega_6 = omega6;
        KolesterolMg = kolesterolMg;
        Karbohydrat = karbohydrat;
        Stivelse = stivelse;
        MonoPlusDisakk = monoPlusDisakk;
        SukkerTilsatt = sukkerTilsatt;
        Kostfiber = kostfiber;
        Protein = protein;
        Salt = salt;
        Alkohol = alkohol;
        VitaminARAE = vitaminArae;
        RetinolMug = retinolMug;
        BetaKarotenMug = betaKarotenMug;
        VitaminDMug = vitaminDMug;
        VitaminEAlfaTE = vitaminEAlfaTe;
        TiaminMg = tiaminMg;
        RiboflavinMg = riboflavinMg;
        NiacinMg = niacinMg;
        VitaminB6Mg = vitaminB6Mg;
        FolatMug = folatMug;
        VitaminB12Mug = vitaminB12Mug;
        VitaminCMg = vitaminCMg;
        KalsiumMg = kalsiumMg;
        JernMg = jernMg;
        NatriumMg = natriumMg;
        KaliumMg = kaliumMg;
        MagnesiumMg = magnesiumMg;
        SinkMg = sinkMg;
        SelenMug = selenMug;
        KopperMg = kopperMg;
        FosforMg = fosforMg;
        JodMug = jodMug;
    }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    public string? FoodName { get; init; }
    public double? SpiseligDel { get; init; }
    public double? Vann { get; init; }
    public double? KilojouleKJ { get; init; }
    public double? KilokalorierKcal { get; init; }
    public double? Fett { get; init; }
    public double? Mettet { get; init; }
    public double? C12_0g { get; init; }
    public double? C14_0 { get; init; }
    public double? C16_0 { get; init; }
    public double? C18_0 { get; init; }
    public double? Trans { get; init; }
    public double? Enumettet { get; init; }
    public double? C16_1Sum { get; init; }
    public double? C18_1Sum { get; init; }
    public double? Flerumettet { get; init; }
    public double? C18_2n_6 { get; init; }
    public double? C18_3n_3 { get; init; }
    public double? C20_3n_3 { get; init; }
    public double? C20_3n_6 { get; init; }
    public double? C20_4n_3 { get; init; }
    public double? C20_4n_6 { get; init; }
    public double? C20_5n_3_EPA { get; init; }
    public double? C22_5n_3_DPA { get; init; }
    public double? C22_6n_3_DHA { get; init; }
    public double? Omega_3 { get; init; }
    public double? Omega_6 { get; init; }
    public double? KolesterolMg { get; init; }
    public double? Karbohydrat { get; init; }
    public double? Stivelse { get; init; }
    public double? MonoPlusDisakk { get; init; }
    public double? SukkerTilsatt { get; init; }
    public double? Kostfiber { get; init; }
    public double? Protein { get; init; }
    public double? Salt { get; init; }
    public double? Alkohol { get; init; }
    public double? VitaminARAE { get; init; }
    public double? RetinolMug { get; init; }
    public double? BetaKarotenMug { get; init; }
    public double? VitaminDMug { get; init; }
    public double? VitaminEAlfaTE { get; init; }
    public double? TiaminMg { get; init; }
    public double? RiboflavinMg { get; init; }
    public double? NiacinMg { get; init; }
    public double? VitaminB6Mg { get; init; }
    public double? FolatMug { get; init; }
    public double? VitaminB12Mug { get; init; }
    public double? VitaminCMg { get; init; }
    public double? KalsiumMg { get; init; }
    public double? JernMg { get; init; }
    public double? NatriumMg { get; init; }
    public double? KaliumMg { get; init; }
    public double? MagnesiumMg { get; init; }
    public double? SinkMg { get; init; }
    public double? SelenMug { get; init; }
    public double? KopperMg { get; init; }
    public double? FosforMg { get; init; }
    public double? JodMug { get; init; }
}