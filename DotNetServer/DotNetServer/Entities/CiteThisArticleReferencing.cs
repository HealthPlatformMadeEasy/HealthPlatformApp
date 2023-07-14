using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("cite_this_article_referencings")]
[Index("ReferencerId", "ReferencerType", Name = "cite_this_article_referencings_all_ids")]
[Index("ArticleId", Name = "index_cite_this_article_referencings_on_article_id")]
[Index("ReferencerId", Name = "index_cite_this_article_referencings_on_referencer_id")]
[Index("ReferencerId", "ArticleId", Name = "new_index")]
[Index("ArticleId", "ReferencerId", "ReferencerType", Name = "unique_article_referencer", IsUnique = true)]
public partial class CiteThisArticleReferencing
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("article_id")]
    public int ArticleId { get; set; }

    [Column("referencer_id")]
    public int ReferencerId { get; set; }

    [Column("referencer_type")]
    public string ReferencerType { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("ArticleId")]
    [InverseProperty("CiteThisArticleReferencings")]
    public virtual CiteThisArticle Article { get; set; } = null!;
}
