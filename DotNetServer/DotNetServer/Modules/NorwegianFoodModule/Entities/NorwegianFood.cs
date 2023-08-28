using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Modules.NorwegianFoodModule.Entities;

[Table("foods")]
public class NorwegianFood
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
}