using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("pdb_identifiers")]
[Index("CompoundId", Name = "index_pdb_identifiers_on_compound_id")]
public partial class PdbIdentifier
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int? CompoundId { get; set; }

    [Column("pdb_id")] [StringLength(255)] public string? PdbId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}