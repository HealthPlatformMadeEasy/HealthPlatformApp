using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("foodcomex_vendor_compounds")]
[Index("CasNumber", Name = "index_foodcomex_vendor_compounds_on_cas_number")]
[Index("Inchikey", Name = "index_foodcomex_vendor_compounds_on_inchikey")]
public partial class FoodcomexVendorCompound
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("foodcomex_vendor_id")]
    [StringLength(255)]
    public string FoodcomexVendorId { get; set; } = null!;

    [Column("catalogue_number")]
    [StringLength(255)]
    public string? CatalogueNumber { get; set; }

    [Column("name", TypeName = "text")] public string? Name { get; set; }

    [Column("cas_number")] public string? CasNumber { get; set; }

    [Column("inchikey")] public string? Inchikey { get; set; }

    [Column("url")] [StringLength(255)] public string? Url { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}