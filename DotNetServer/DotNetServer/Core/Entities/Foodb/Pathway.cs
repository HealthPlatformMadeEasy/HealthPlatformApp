using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Core.Entities.Foodb;

[Table("pathways")]
public class Pathway
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("smpdb_id")]
    [StringLength(255)]
    public string? SmpdbId { get; set; }

    [Column("kegg_map_id")]
    [StringLength(255)]
    public string? KeggMapId { get; set; }

    [Column("name")] [StringLength(255)] public string? Name { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [InverseProperty("Pathway")]
    public virtual ICollection<CompoundsPathway> CompoundsPathways { get; set; } = new List<CompoundsPathway>();
}