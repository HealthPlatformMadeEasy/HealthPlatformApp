using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("sequences")]
[Index("SequenceableId", Name = "index_sequences_on_sequenceable_id")]
[Index("SequenceableId", "SequenceableType", Name = "index_sequences_on_sequenceable_id_and_sequenceable_type")]
[Index("SequenceableType", Name = "index_sequences_on_sequenceable_type")]
public partial class Sequence
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("header")] [StringLength(255)] public string? Header { get; set; }

    [Column("chain", TypeName = "mediumtext")]
    public string? Chain { get; set; }

    [Column("sequenceable_id")] public int? SequenceableId { get; set; }

    [Column("sequenceable_type")] public string? SequenceableType { get; set; }

    [Column("type")] [StringLength(255)] public string? Type { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}