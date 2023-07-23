using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("compounds_pathways")]
[Index("CompoundId", Name = "index_compounds_pathways_on_compound_id")]
[Index("PathwayId", Name = "index_compounds_pathways_on_pathway_id")]
public partial class CompoundsPathway
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int? CompoundId { get; set; }

    [Column("pathway_id")] public int? PathwayId { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("CompoundId")]
    [InverseProperty("CompoundsPathways")]
    public virtual Compound? Compound { get; set; }

    [ForeignKey("PathwayId")]
    [InverseProperty("CompoundsPathways")]
    public virtual Pathway? Pathway { get; set; }
}