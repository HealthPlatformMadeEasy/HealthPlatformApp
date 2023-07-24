using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("enzyme_synonyms")]
[Index("EnzymeId", Name = "index_enzyme_synonyms_on_enzyme_id")]
[Index("Synonym", Name = "index_enzyme_synonyms_on_synonym", IsUnique = true)]
public partial class EnzymeSynonym
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("enzyme_id")] public int EnzymeId { get; set; }

    [Column("synonym")] public string Synonym { get; set; } = null!;

    [Column("source")] [StringLength(255)] public string Source { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}