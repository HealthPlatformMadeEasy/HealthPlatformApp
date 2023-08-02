using DotNetServer.Modules.FoodModule.Entities;
using DotNetServer.Modules.NutrientModule.Entities;
using DotNetServer.Modules.UserContentModule.Entities;
using DotNetServer.Modules.UserModule.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Context;

public partial class FoodbContext : DbContext
{
    public FoodbContext()
    {
    }

    public FoodbContext(DbContextOptions<FoodbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Content> Contents { get; set; } = null!;

    public virtual DbSet<Food> Foods { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<UserContent> UserContents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Export).HasDefaultValueSql("'1'");
            entity.Property(e => e.OrigUnit).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.ExportToFoodb).HasDefaultValueSql("'1'");

            entity.HasMany<Content>(e => e.Contents)
                .WithOne()
                .IsRequired();
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasAlternateKey(e => e.Email).HasName("email_pk");

            entity.HasAlternateKey(e => e.Name).HasName("name_pk");

            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");

            entity.HasMany<UserContent>(e => e.UserContents)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);

            entity.HasMany<Nutrient>(e => e.Nutrients)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId);
        });

        modelBuilder.Entity<UserContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}