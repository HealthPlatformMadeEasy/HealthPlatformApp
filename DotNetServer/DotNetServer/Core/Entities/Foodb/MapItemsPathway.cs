using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("map_items_pathways")]
[Index("MapItemId", "MapItemType", Name = "index_map_items_pathways_on_map_item_id_and_map_item_type")]
public class MapItemsPathway
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("map_item_id")] public int? MapItemId { get; set; }

    [Column("map_item_type")] public string? MapItemType { get; set; }

    [Column("pathway_id")] public int? PathwayId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}