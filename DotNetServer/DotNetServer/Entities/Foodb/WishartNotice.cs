using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Entities.Foodb;

[Table("wishart_notices")]
public partial class WishartNotice
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("content", TypeName = "text")] public string Content { get; set; } = null!;

    [Column("display")] public bool? Display { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}