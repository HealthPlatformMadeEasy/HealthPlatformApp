using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Table("compound_external_descriptors")]
[Index("CompoundId", Name = "index_compound_external_descriptors_on_compound_id")]
public partial class CompoundExternalDescriptor
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("external_id")]
    [StringLength(255)]
    public string? ExternalId { get; set; }

    [Column("annotations")]
    [StringLength(255)]
    public string? Annotations { get; set; }

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
    [InverseProperty("CompoundExternalDescriptors")]
    public virtual Compound? Compound { get; set; }
}
