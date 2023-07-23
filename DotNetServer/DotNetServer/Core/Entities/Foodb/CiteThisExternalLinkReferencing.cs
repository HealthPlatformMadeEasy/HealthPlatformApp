using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("cite_this_external_link_referencings")]
[Index("ReferencerId", "ReferencerType", Name = "external_link_referencings_all_ids")]
[Index("ExternalLinkId", Name = "index_cite_this_external_link_referencings_on_external_link_id")]
[Index("ReferencerId", Name = "index_cite_this_external_link_referencings_on_referencer_id")]
public partial class CiteThisExternalLinkReferencing
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("external_link_id")] public int ExternalLinkId { get; set; }

    [Column("referencer_id")] public int ReferencerId { get; set; }

    [Column("referencer_type")] public string ReferencerType { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("ExternalLinkId")]
    [InverseProperty("CiteThisExternalLinkReferencings")]
    public virtual CiteThisExternalLink ExternalLink { get; set; } = null!;
}