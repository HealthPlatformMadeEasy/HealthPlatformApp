using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("ontology_synonyms")]
[Index("OntologyTermId", Name = "index_ontology_synonyms_on_ontology_term_id")]
public partial class OntologySynonym
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("ontology_term_id")]
    public int? OntologyTermId { get; set; }

    [Column("synonym")]
    [StringLength(255)]
    public string? Synonym { get; set; }

    [Column("external_id")]
    [StringLength(255)]
    public string? ExternalId { get; set; }

    [Column("external_srouce")]
    [StringLength(255)]
    public string? ExternalSrouce { get; set; }

    [Column("parent_id")]
    [StringLength(255)]
    public string? ParentId { get; set; }

    [Column("parent_source")]
    [StringLength(255)]
    public string? ParentSource { get; set; }

    [Column("comment")]
    [StringLength(255)]
    public string? Comment { get; set; }

    [Column("curator")]
    [StringLength(255)]
    public string? Curator { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("OntologyTermId")]
    [InverseProperty("OntologySynonyms")]
    public virtual OntologyTerm? OntologyTerm { get; set; }
}
