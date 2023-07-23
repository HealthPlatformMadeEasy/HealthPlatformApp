using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("references")]
[Index("SourceType", "SourceId", Name = "index_references_on_source_type_and_source_id")]
public partial class Reference
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ref_type")]
    [StringLength(255)]
    public string? RefType { get; set; }

    [Column("text", TypeName = "text")]
    public string? Text { get; set; }

    [Column("pubmed_id")]
    [StringLength(255)]
    public string? PubmedId { get; set; }

    [Column("link")]
    [StringLength(255)]
    public string? Link { get; set; }

    [Column("title")]
    [StringLength(255)]
    public string? Title { get; set; }

    [Column("creator_id")]
    public int? CreatorId { get; set; }

    [Column("updater_id")]
    public int? UpdaterId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("source_id")]
    public int? SourceId { get; set; }

    [Column("source_type")]
    public string? SourceType { get; set; }
}
