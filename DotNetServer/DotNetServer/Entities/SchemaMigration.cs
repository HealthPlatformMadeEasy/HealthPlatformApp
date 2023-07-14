using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities;

[Keyless]
[Table("schema_migrations")]
[Index("Version", Name = "unique_schema_migrations", IsUnique = true)]
public partial class SchemaMigration
{
    [Column("version")]
    public string Version { get; set; } = null!;
}
