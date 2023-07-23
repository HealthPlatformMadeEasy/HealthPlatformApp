using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Entities.Foodb;

[Table("ontology_terms")]
public partial class OntologyTerm
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("term")] [StringLength(255)] public string? Term { get; set; }

    [Column("definition", TypeName = "text")]
    public string? Definition { get; set; }

    [Column("external_id")]
    [StringLength(255)]
    public string? ExternalId { get; set; }

    [Column("external_source")]
    [StringLength(255)]
    public string? ExternalSource { get; set; }

    [Column("comment")]
    [StringLength(255)]
    public string? Comment { get; set; }

    [Column("curator")]
    [StringLength(255)]
    public string? Curator { get; set; }

    [Column("parent_id")] public int? ParentId { get; set; }

    [Column("level")] public int? Level { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("legacy_id")] public int? LegacyId { get; set; }

    [InverseProperty("OntologyTerm")]
    public virtual ICollection<OntologySynonym> OntologySynonyms { get; set; } = new List<OntologySynonym>();
}