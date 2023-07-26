using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("cite_this_textbook_referencings")]
[Index("ReferencerId", "ReferencerType", Name = "cite_this_article_referencings_all_ids")]
[Index("ReferencerId", Name = "index_cite_this_textbook_referencings_on_referencer_id")]
[Index("TextbookId", Name = "index_cite_this_textbook_referencings_on_textbook_id")]
public class CiteThisTextbookReferencing
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("textbook_id")] public int TextbookId { get; set; }

    [Column("referencer_id")] public int ReferencerId { get; set; }

    [Column("referencer_type")] public string ReferencerType { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("pages")] [StringLength(255)] public string? Pages { get; set; }

    [Column("chapter")]
    [StringLength(255)]
    public string? Chapter { get; set; }

    [Column("chapter_author")]
    [StringLength(255)]
    public string? ChapterAuthor { get; set; }

    [ForeignKey("TextbookId")]
    [InverseProperty("CiteThisTextbookReferencings")]
    public virtual CiteThisTextbook Textbook { get; set; } = null!;
}