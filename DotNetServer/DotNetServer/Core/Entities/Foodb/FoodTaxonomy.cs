using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Core.Entities.Foodb;

[Table("food_taxonomies")]
public class FoodTaxonomy
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("food_id")] public int? FoodId { get; set; }

    [Column("ncbi_taxonomy_id")] public int? NcbiTaxonomyId { get; set; }

    [Column("classification_name")]
    [StringLength(255)]
    public string? ClassificationName { get; set; }

    [Column("classification_order")] public int? ClassificationOrder { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}