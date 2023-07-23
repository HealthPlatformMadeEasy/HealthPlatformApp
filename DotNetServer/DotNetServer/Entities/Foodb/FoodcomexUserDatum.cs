using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetServer.Entities.Foodb;

[Table("foodcomex_user_data")]
public partial class FoodcomexUserDatum
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("role")] [StringLength(255)] public string Role { get; set; } = null!;

    [Column("gender")] [StringLength(255)] public string? Gender { get; set; }

    [Column("position")]
    [StringLength(255)]
    public string? Position { get; set; }

    [Column("institution")]
    [StringLength(255)]
    public string? Institution { get; set; }

    [Column("department")]
    [StringLength(255)]
    public string? Department { get; set; }

    [Column("address")]
    [StringLength(255)]
    public string? Address { get; set; }

    [Column("city")] [StringLength(255)] public string? City { get; set; }

    [Column("country")]
    [StringLength(255)]
    public string? Country { get; set; }

    [Column("phone_number")]
    [StringLength(255)]
    public string? PhoneNumber { get; set; }

    [Column("zip_code")]
    [StringLength(255)]
    public string? ZipCode { get; set; }

    [Column("institution_type")]
    [StringLength(255)]
    public string? InstitutionType { get; set; }

    [Column("area_of_research")]
    [StringLength(255)]
    public string? AreaOfResearch { get; set; }

    [Column("area_of_research_detailed", TypeName = "text")]
    public string? AreaOfResearchDetailed { get; set; }

    [Column("activities", TypeName = "text")]
    public string? Activities { get; set; }

    [Column("interests", TypeName = "text")]
    public string? Interests { get; set; }

    [Column("purpose_of_use", TypeName = "text")]
    public string? PurposeOfUse { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("admin_user_id")] public int? AdminUserId { get; set; }
}