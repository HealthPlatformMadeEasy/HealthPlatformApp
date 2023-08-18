using CsvHelper.Configuration.Attributes;

namespace DotNetServer.Core.Context.DataSeed;

public class SeedFood
{
    [Ignore] public Guid Id { get; set; } = Guid.NewGuid();
    [Index(0)] public string? FoodName { get; set; } = null!;
    [Index(1)] public double? SpiseligDel { get; set; }
    [Index(2)] public double? Vann { get; set; }
    [Index(3)] public double? KilojouleKJ { get; set; }
    [Index(4)] public double? KilokalorierKcal { get; set; }
    [Index(5)] public double? Fett { get; set; }
    [Index(6)] public double? Mettet { get; set; }
    [Index(7)] public double? C12_0g { get; set; }
    [Index(8)] public double? C14_0 { get; set; }
    [Index(9)] public double? C16_0 { get; set; }
    [Index(10)] public double? C18_0 { get; set; }
    [Index(11)] public double? Trans { get; set; }
    [Index(12)] public double? Enumettet { get; set; }
    [Index(13)] public double? C16_1Sum { get; set; }
    [Index(14)] public double? C18_1Sum { get; set; }
    [Index(15)] public double? Flerumettet { get; set; }
    [Index(16)] public double? C18_2n_6 { get; set; }
    [Index(17)] public double? C18_3n_3 { get; set; }
    [Index(18)] public double? C20_3n_3 { get; set; }
    [Index(19)] public double? C20_3n_6 { get; set; }
    [Index(20)] public double? C20_4n_3 { get; set; }
    [Index(21)] public double? C20_4n_6 { get; set; }
    [Index(22)] public double? C20_5n_3_EPA { get; set; }
    [Index(23)] public double? C22_5n_3_DPA { get; set; }
    [Index(24)] public double? C22_6n_3_DHA { get; set; }
    [Index(25)] public double? Omega_3 { get; set; }
    [Index(26)] public double? Omega_6 { get; set; }
    [Index(27)] public double? KolesterolMg { get; set; }
    [Index(28)] public double? Karbohydrat { get; set; }
    [Index(29)] public double? Stivelse { get; set; }
    [Index(30)] public double? MonoPlusDisakk { get; set; }
    [Index(31)] public double? SukkerTilsatt { get; set; }
    [Index(32)] public double? Kostfiber { get; set; }
    [Index(33)] public double? Protein { get; set; }
    [Index(34)] public double? Salt { get; set; }
    [Index(35)] public double? Alkohol { get; set; }
    [Index(36)] public double? VitaminARAE { get; set; }
    [Index(37)] public double? RetinolMug { get; set; }
    [Index(38)] public double? BetaKarotenMug { get; set; }
    [Index(39)] public double? VitaminDMug { get; set; }
    [Index(40)] public double? VitaminEAlfaTE { get; set; }
    [Index(41)] public double? TiaminMg { get; set; }
    [Index(42)] public double? RiboflavinMg { get; set; }
    [Index(43)] public double? NiacinMg { get; set; }
    [Index(44)] public double? VitaminB6Mg { get; set; }
    [Index(45)] public double? FolatMug { get; set; }
    [Index(46)] public double? VitaminB12Mug { get; set; }
    [Index(47)] public double? VitaminCMg { get; set; }
    [Index(48)] public double? KalsiumMg { get; set; }
    [Index(49)] public double? JernMg { get; set; }
    [Index(50)] public double? NatriumMg { get; set; }
    [Index(51)] public double? KaliumMg { get; set; }
    [Index(52)] public double? MagnesiumMg { get; set; }
    [Index(53)] public double? SinkMg { get; set; }
    [Index(54)] public double? SelenMug { get; set; }
    [Index(55)] public double? KopperMg { get; set; }
    [Index(56)] public double? FosforMg { get; set; }
    [Index(57)] public double? JodMug { get; set; }
}