using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("health_effects")]
[Index("ChebiId", Name = "index_health_effects_on_chebi_id")]
[Index("ChebiName", Name = "index_health_effects_on_chebi_name")]
[Index("Name", Name = "index_health_effects_on_name", IsUnique = true)]
public class HealthEffect
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("chebi_name")] public string? ChebiName { get; set; }

    [Column("chebi_id")] public string? ChebiId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("chebi_definition", TypeName = "text")]
    public string? ChebiDefinition { get; set; }
}