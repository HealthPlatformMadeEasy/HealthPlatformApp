using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("accession_numbers")]
[Index("CompoundId", Name = "index_accession_numbers_on_compound_id")]
[Index("SourceId", "SourceType", Name = "index_accession_numbers_on_source_id_and_source_type")]
public partial class AccessionNumber
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("number")] [StringLength(255)] public string? Number { get; set; }

    [Column("compound_id")] public int? CompoundId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("source_id")] public int? SourceId { get; set; }

    [Column("source_type")] public string? SourceType { get; set; }
}