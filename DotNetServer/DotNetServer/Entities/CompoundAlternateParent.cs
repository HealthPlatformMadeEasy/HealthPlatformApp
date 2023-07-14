using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("compound_alternate_parents")]
[Index("CompoundId", Name = "index_compound_alternate_parents_on_compound_id")]
public partial class CompoundAlternateParent
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    public string? Name { get; set; }

    [Column("compound_id")]
    public int? CompoundId { get; set; }

    [Column("creator_id")]
    public int? CreatorId { get; set; }

    [Column("updater_id")]
    public int? UpdaterId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [ForeignKey("CompoundId")]
    [InverseProperty("CompoundAlternateParents")]
    public virtual Compound? Compound { get; set; }
}
