using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("cite_this_textbooks")]
[Index("Isbn", Name = "index_cite_this_textbooks_on_isbn")]
public partial class CiteThisTextbook
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("isbn")]
    public string? Isbn { get; set; }

    [Column("title", TypeName = "text")]
    public string Title { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("ref_id")]
    [StringLength(255)]
    public string? RefId { get; set; }

    [Column("authors")]
    [StringLength(255)]
    public string Authors { get; set; } = null!;

    [Column("edition")]
    [StringLength(255)]
    public string? Edition { get; set; }

    [Column("publisher")]
    [StringLength(255)]
    public string Publisher { get; set; } = null!;

    [Column("year")]
    [StringLength(255)]
    public string Year { get; set; } = null!;

    [Column("book_format")]
    [StringLength(255)]
    public string? BookFormat { get; set; }

    [Column("ean")]
    [StringLength(255)]
    public string? Ean { get; set; }

    [InverseProperty("Textbook")]
    public virtual ICollection<CiteThisTextbookReferencing> CiteThisTextbookReferencings { get; set; } = new List<CiteThisTextbookReferencing>();
}
