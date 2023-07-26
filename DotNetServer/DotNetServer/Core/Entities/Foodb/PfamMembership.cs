using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("pfam_memberships")]
[Index("EnzymeId", "PfamId", Name = "index_pfam_memberships_on_enzyme_id_and_pfam_id", IsUnique = true)]
public class PfamMembership
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("enzyme_id")] public int? EnzymeId { get; set; }

    [Column("pfam_id")] public int? PfamId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}