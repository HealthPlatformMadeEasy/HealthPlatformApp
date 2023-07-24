using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Core.Entities.Foodb;

[Table("foodcomex_compound_requests")]
public partial class FoodcomexCompoundRequest
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("admin_user_id")] public int AdminUserId { get; set; }

    [Column("structure", TypeName = "text")]
    public string? Structure { get; set; }

    [Column("inchikey")]
    [StringLength(255)]
    public string? Inchikey { get; set; }

    [Column("inchi")] [StringLength(255)] public string? Inchi { get; set; }

    [Column("smiles")] [StringLength(255)] public string? Smiles { get; set; }

    [Column("structure_image_file_name")]
    [StringLength(255)]
    public string? StructureImageFileName { get; set; }

    [Column("structure_image_content_type")]
    [StringLength(255)]
    public string? StructureImageContentType { get; set; }

    [Column("structure_image_file_size")] public int? StructureImageFileSize { get; set; }

    [Column("structure_image_updated_at", TypeName = "datetime")]
    public DateTime? StructureImageUpdatedAt { get; set; }

    [Column("name")] [StringLength(255)] public string? Name { get; set; }

    [Column("message", TypeName = "text")] public string? Message { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }
}