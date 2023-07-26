using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("compounds_flavors")]
[Index("CompoundId", "FlavorId", Name = "index_compounds_flavors_on_compound_id_and_flavor_id", IsUnique = true)]
[Index("SourceId", "SourceType", Name = "index_compounds_flavors_on_source_id_and_source_type")]
public class CompoundsFlavor
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int CompoundId { get; set; }

    [Column("flavor_id")] public int FlavorId { get; set; }

    [Column("citations", TypeName = "mediumtext")]
    public string Citations { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("source_id")] public int? SourceId { get; set; }

    [Column("source_type")] public string? SourceType { get; set; }
}