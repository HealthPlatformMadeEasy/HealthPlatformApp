using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Keyless]
[Table("schema_migrations")]
[Index("Version", Name = "unique_schema_migrations", IsUnique = true)]
public class SchemaMigration
{
    [Column("version")] public string Version { get; set; } = null!;
}