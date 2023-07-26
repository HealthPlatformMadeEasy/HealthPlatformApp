using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("compounds_enzymes")]
[Index("CompoundId", "EnzymeId", Name = "index_compounds_enzymes_on_compound_id_and_enzyme_id", IsUnique = true)]
public class CompoundsEnzyme
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int CompoundId { get; set; }

    [Column("enzyme_id")] public int EnzymeId { get; set; }

    [Column("citations", TypeName = "mediumtext")]
    public string Citations { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }
}