using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.FoodModule.Entities;

[Table("foods")]
[Index("ExportToAfcdb", Name = "index_foods_on_export_to_afcdb")]
[Index("Name", Name = "index_foods_on_name", IsUnique = true)]
[Index("NameScientific", Name = "index_foods_on_name_scientific")]
public partial class Food
{
    [Key] [Column("id")] public int Id { get; set; }

    public List<Content> Contents { get; set; } = null!;

    [Column("name")] public string Name { get; set; } = null!;

    [Column("name_scientific")] public string? NameScientific { get; set; }

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("itis_id")]
    [StringLength(255)]
    public string? ItisId { get; set; }

    [Column("wikipedia_id")]
    [StringLength(255)]
    public string? WikipediaId { get; set; }

    [Column("picture_file_name")]
    [StringLength(255)]
    public string? PictureFileName { get; set; }

    [Column("picture_content_type")]
    [StringLength(255)]
    public string? PictureContentType { get; set; }

    [Column("picture_file_size")] public int? PictureFileSize { get; set; }

    [Column("picture_updated_at", TypeName = "datetime")]
    public DateTime? PictureUpdatedAt { get; set; }

    [Column("legacy_id")] public int? LegacyId { get; set; }

    [Column("food_group")]
    [StringLength(255)]
    public string? FoodGroup { get; set; }

    [Column("food_subgroup")]
    [StringLength(255)]
    public string? FoodSubgroup { get; set; }

    [Column("food_type")]
    [StringLength(255)]
    public string FoodType { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("export_to_afcdb")] public bool ExportToAfcdb { get; set; }

    [Column("category")]
    [StringLength(255)]
    public string? Category { get; set; }

    [Column("ncbi_taxonomy_id")] public int? NcbiTaxonomyId { get; set; }

    [Column("export_to_foodb")] public bool? ExportToFoodb { get; set; }

    [Column("public_id")]
    [StringLength(255)]
    public string? PublicId { get; set; }
}