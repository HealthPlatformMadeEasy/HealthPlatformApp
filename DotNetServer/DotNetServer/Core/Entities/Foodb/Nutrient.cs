using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("nutrients")]
[Index("Name", Name = "index_nutrients_on_name", IsUnique = true)]
[Index("Name", "PublicId", Name = "index_nutrients_on_name_and_public_id", IsUnique = true)]
[Index("PublicId", Name = "index_nutrients_on_public_id", IsUnique = true)]
public partial class Nutrient
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("legacy_id")] public int? LegacyId { get; set; }

    [Column("type")] [StringLength(255)] public string Type { get; set; } = null!;

    [Column("public_id")]
    [StringLength(9)]
    public string PublicId { get; set; } = null!;

    [Column("name")] public string Name { get; set; } = null!;

    [Column("export")] public bool? Export { get; set; }

    [Column("state")] [StringLength(255)] public string? State { get; set; }

    [Column("annotation_quality")]
    [StringLength(255)]
    public string? AnnotationQuality { get; set; }

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("wikipedia_id")]
    [StringLength(255)]
    public string? WikipediaId { get; set; }

    [Column("comments", TypeName = "mediumtext")]
    public string? Comments { get; set; }

    [Column("dfc_id")] [StringLength(255)] public string? DfcId { get; set; }

    [Column("duke_id")]
    [StringLength(255)]
    public string? DukeId { get; set; }

    [Column("eafus_id")]
    [StringLength(255)]
    public string? EafusId { get; set; }

    [Column("dfc_name", TypeName = "mediumtext")]
    public string? DfcName { get; set; }

    [Column("compound_source")]
    [StringLength(255)]
    public string? CompoundSource { get; set; }

    [Column("metabolism", TypeName = "mediumtext")]
    public string? Metabolism { get; set; }

    [Column("synthesis_citations", TypeName = "mediumtext")]
    public string? SynthesisCitations { get; set; }

    [Column("general_citations", TypeName = "mediumtext")]
    public string? GeneralCitations { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}