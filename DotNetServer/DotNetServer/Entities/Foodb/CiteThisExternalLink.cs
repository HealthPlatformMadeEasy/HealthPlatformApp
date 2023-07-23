using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Entities.Foodb;

[Table("cite_this_external_links")]
public partial class CiteThisExternalLink
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("url")] [StringLength(1000)] public string Url { get; set; } = null!;

    [Column("name")] [StringLength(255)] public string Name { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("ref_id")] [StringLength(255)] public string? RefId { get; set; }

    [InverseProperty("ExternalLink")]
    public virtual ICollection<CiteThisExternalLinkReferencing> CiteThisExternalLinkReferencings { get; set; } =
        new List<CiteThisExternalLinkReferencing>();
}