using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Entities.Foodb;

[Table("ncbi_taxonomy_maps")]
public partial class NcbiTaxonomyMap
{
    [Key] [Column("id")] public int Id { get; set; }

    [StringLength(255)] public string? TaxonomyName { get; set; }

    [StringLength(255)] public string? Rank { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}