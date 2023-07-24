using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("foodcomex_compound_providers")]
[Index("FoodcomexCompoundId", Name = "index_foodcomex_compound_providers_on_foodcomex_compound_id")]
[Index("ProviderId", Name = "index_foodcomex_compound_providers_on_provider_id")]
public partial class FoodcomexCompoundProvider
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("foodcomex_compound_id")] public int FoodcomexCompoundId { get; set; }

    [Column("provider_id")] public int ProviderId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}