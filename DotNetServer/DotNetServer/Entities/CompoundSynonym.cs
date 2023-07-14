using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("compound_synonyms")]
[Index("SourceId", "SourceType", Name = "index_compound_synonyms_on_source_id_and_source_type")]
[Index("Synonym", Name = "index_compound_synonyms_on_synonym", IsUnique = true)]
public partial class CompoundSynonym
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("synonym")]
    public string Synonym { get; set; } = null!;

    [Column("synonym_source")]
    [StringLength(255)]
    public string SynonymSource { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("source_id")]
    public int? SourceId { get; set; }

    [Column("source_type")]
    public string? SourceType { get; set; }
}
