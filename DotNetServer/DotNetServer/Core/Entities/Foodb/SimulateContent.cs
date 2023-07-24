using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("simulate_contents")]
[Index("SourceId", "SourceType", "FoodId", Name = "index_simulate_contents_on_source_id_and_source_type_and_food_id")]
public partial class SimulateContent
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("source_id")] public int? SourceId { get; set; }

    [Column("source_type")] public string? SourceType { get; set; }

    [Column("food_id")] public int? FoodId { get; set; }

    [Column("orig_food_id")] public int? OrigFoodId { get; set; }

    [Column("orig_food_part")]
    [StringLength(255)]
    public string? OrigFoodPart { get; set; }

    [Column("orig_source_id")]
    [StringLength(255)]
    public string? OrigSourceId { get; set; }

    [Column("orig_source_name")]
    [StringLength(255)]
    public string? OrigSourceName { get; set; }

    [Column("orig_citation")]
    [StringLength(255)]
    public string? OrigCitation { get; set; }

    [Column("citation")]
    [StringLength(255)]
    public string? Citation { get; set; }

    [Column("citation_type")]
    [StringLength(255)]
    public string? CitationType { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("orig_min")]
    [Precision(15, 9)]
    public decimal? OrigMin { get; set; }

    [Column("orig_max")]
    [Precision(15, 9)]
    public decimal? OrigMax { get; set; }

    [Column("orig_unit")]
    [StringLength(255)]
    public string? OrigUnit { get; set; }

    [Column("orig_food_common_name")]
    [StringLength(255)]
    public string? OrigFoodCommonName { get; set; }

    [Column("orig_food_scientific_name")]
    [StringLength(255)]
    public string? OrigFoodScientificName { get; set; }

    [Column("orig_content")]
    [Precision(15, 9)]
    public decimal? OrigContent { get; set; }

    [Column("creater_id")]
    [StringLength(255)]
    public string? CreaterId { get; set; }

    [Column("updater_id")]
    [StringLength(255)]
    public string? UpdaterId { get; set; }

    [Column("orig_method")]
    [StringLength(255)]
    public string? OrigMethod { get; set; }

    [Column("orig_unit_expression")]
    [StringLength(255)]
    public string? OrigUnitExpression { get; set; }

    [Column("standard_content")]
    [Precision(10, 0)]
    public decimal? StandardContent { get; set; }

    [Column("preparation_type")]
    [StringLength(255)]
    public string? PreparationType { get; set; }

    [Column("food_type")]
    [StringLength(255)]
    public string FoodType { get; set; } = null!;
}