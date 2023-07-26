using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Core.Entities.Foodb;

[Table("compound_ontology_terms")]
public class CompoundOntologyTerm
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int? CompoundId { get; set; }

    [Column("export")] public bool? Export { get; set; }

    [Column("ontology_term_id")] public int? OntologyTermId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}