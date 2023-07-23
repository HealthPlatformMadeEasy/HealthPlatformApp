using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Entities.Foodb;

[Table("pfams")]
public partial class Pfam
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("identifier")]
    [StringLength(7)]
    public string? Identifier { get; set; }

    [Column("name")] [StringLength(50)] public string? Name { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}