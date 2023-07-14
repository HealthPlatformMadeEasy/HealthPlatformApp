using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("cite_this_articles")]
[Index("PubmedId", Name = "index_cite_this_articles_on_pubmed_id", IsUnique = true)]
public partial class CiteThisArticle
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("pubmed_id")]
    public int PubmedId { get; set; }

    [Column("citation", TypeName = "text")]
    public string? Citation { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("ref_id")]
    [StringLength(255)]
    public string? RefId { get; set; }

    [Column("doi")]
    [StringLength(255)]
    public string? Doi { get; set; }

    [Column("title")]
    [StringLength(1000)]
    public string Title { get; set; } = null!;

    [Column("authors", TypeName = "text")]
    public string Authors { get; set; } = null!;

    [Column("source")]
    [StringLength(255)]
    public string? Source { get; set; }

    [Column("journal")]
    [StringLength(255)]
    public string? Journal { get; set; }

    [Column("volume")]
    [StringLength(255)]
    public string? Volume { get; set; }

    [Column("year")]
    public int Year { get; set; }

    [Column("date")]
    [StringLength(255)]
    public string Date { get; set; } = null!;

    [Column("pages")]
    [StringLength(255)]
    public string? Pages { get; set; }

    [Column("issue")]
    [StringLength(255)]
    public string? Issue { get; set; }

    [Column("abstract", TypeName = "text")]
    public string? Abstract { get; set; }

    [InverseProperty("Article")]
    public virtual ICollection<CiteThisArticleReferencing> CiteThisArticleReferencings { get; set; } = new List<CiteThisArticleReferencing>();
}
