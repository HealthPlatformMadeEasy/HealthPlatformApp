using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetServer.Modules.UserModule.Entities;

namespace DotNetServer.Modules.UserContentModule.Entities;

public class UserContent
{
    [Key] [Column("id")] public Guid Id { get; set; }

    [Column("source_type")] public string? SourceType { get; set; }

    [Column("orig_unit")] public string? OrigUnit { get; set; }

    [Column("orig_source_name")] public string? OrigSourceName { get; set; }

    [Column("orig_content")] public decimal? OrigContent { get; set; }

    [Column("standard_content")] public decimal? StandardContent { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    [Column("user_id")] public Guid UserId { get; set; }

    public User User { get; set; } = null!;
}