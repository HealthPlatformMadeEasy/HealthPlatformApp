using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("flavors")]
[Index("Name", Name = "index_flavors_on_name", IsUnique = true)]
public partial class Flavor
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; } = null!;

    [Column("flavor_group")]
    [StringLength(255)]
    public string? FlavorGroup { get; set; }

    [Column("category")]
    [StringLength(255)]
    public string? Category { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }
}