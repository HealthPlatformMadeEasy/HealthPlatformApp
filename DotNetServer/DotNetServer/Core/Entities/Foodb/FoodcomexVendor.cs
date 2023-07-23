using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Core.Entities.Foodb;

[Table("foodcomex_vendors")]
public partial class FoodcomexVendor
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] [StringLength(255)] public string? Name { get; set; }

    [Column("url")] [StringLength(255)] public string? Url { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}