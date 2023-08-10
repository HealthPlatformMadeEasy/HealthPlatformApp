using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DotNetServer.Modules.NutrientModule.Entities;
using DotNetServer.Modules.UserContentModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Modules.UserModule.Entities;

[Index("Password", Name = "users_password_index")]
public class User
{
    [Key] [Column("id")] public Guid Id { get; set; }

    [Column("name")] public required string Name { get; set; }

    [Column("password")] public required string Password { get; set; }

    [Column("email")] public required string Email { get; set; }

    [Column("created_at")] public DateTime CreatedAt { get; set; }

    public ICollection<UserContent> UserContents { get; set; } = null!;

    public ICollection<Nutrient> Nutrients { get; set; } = null!;
}