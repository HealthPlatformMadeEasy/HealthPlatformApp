using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("compounds_health_effects")]
[Index("SourceId", "SourceType", Name = "index_compounds_health_effects_on_source_id_and_source_type")]
public class CompoundsHealthEffect
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int CompoundId { get; set; }

    [Column("health_effect_id")] public int HealthEffectId { get; set; }

    [Column("orig_health_effect_name")]
    [StringLength(255)]
    public string? OrigHealthEffectName { get; set; }

    [Column("orig_compound_name")]
    [StringLength(255)]
    public string? OrigCompoundName { get; set; }

    [Column("orig_citation", TypeName = "mediumtext")]
    public string? OrigCitation { get; set; }

    [Column("citation", TypeName = "mediumtext")]
    public string Citation { get; set; } = null!;

    [Column("citation_type")]
    [StringLength(255)]
    public string CitationType { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("source_id")] public int? SourceId { get; set; }

    [Column("source_type")] public string? SourceType { get; set; }
}