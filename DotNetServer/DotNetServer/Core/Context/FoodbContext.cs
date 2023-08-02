using DotNetServer.Core.Entities.Foodb;
using DotNetServer.Modules.FoodModule.Entities;
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

    public virtual DbSet<AccessionNumber> AccessionNumbers { get; set; } = null!;

    public virtual DbSet<CiteThisArticle> CiteThisArticles { get; set; } = null!;

    public virtual DbSet<CiteThisArticleReferencing> CiteThisArticleReferencings { get; set; } = null!;

    public virtual DbSet<CiteThisExternalLink> CiteThisExternalLinks { get; set; } = null!;

    public virtual DbSet<CiteThisExternalLinkReferencing> CiteThisExternalLinkReferencings { get; set; } = null!;

    public virtual DbSet<CiteThisTextbook> CiteThisTextbooks { get; set; } = null!;

    public virtual DbSet<CiteThisTextbookReferencing> CiteThisTextbookReferencings { get; set; } = null!;

    public virtual DbSet<Compound> Compounds { get; set; } = null!;

    public virtual DbSet<CompoundAlternateParent> CompoundAlternateParents { get; set; } = null!;

    public virtual DbSet<CompoundExternalDescriptor> CompoundExternalDescriptors { get; set; } = null!;

    public virtual DbSet<CompoundOntologyTerm> CompoundOntologyTerms { get; set; } = null!;

    public virtual DbSet<CompoundSubstituent> CompoundSubstituents { get; set; } = null!;

    public virtual DbSet<CompoundSynonym> CompoundSynonyms { get; set; } = null!;

    public virtual DbSet<CompoundsEnzyme> CompoundsEnzymes { get; set; } = null!;

    public virtual DbSet<CompoundsFlavor> CompoundsFlavors { get; set; } = null!;

    public virtual DbSet<CompoundsHealthEffect> CompoundsHealthEffects { get; set; } = null!;

    public virtual DbSet<CompoundsPathway> CompoundsPathways { get; set; } = null!;

    public virtual DbSet<Content> Contents { get; set; } = null!;

    public virtual DbSet<Enzyme> Enzymes { get; set; } = null!;

    public virtual DbSet<EnzymeSynonym> EnzymeSynonyms { get; set; } = null!;

    public virtual DbSet<Flavor> Flavors { get; set; } = null!;

    public virtual DbSet<Food> Foods { get; set; } = null!;

    public virtual DbSet<FoodTaxonomy> FoodTaxonomies { get; set; } = null!;

    public virtual DbSet<FoodcomexCompound> FoodcomexCompounds { get; set; } = null!;

    public virtual DbSet<FoodcomexCompoundProvider> FoodcomexCompoundProviders { get; set; } = null!;

    public virtual DbSet<FoodcomexCompoundRequest> FoodcomexCompoundRequests { get; set; } = null!;

    public virtual DbSet<FoodcomexUserDatum> FoodcomexUserData { get; set; } = null!;

    public virtual DbSet<FoodcomexVendor> FoodcomexVendors { get; set; } = null!;

    public virtual DbSet<FoodcomexVendorCompound> FoodcomexVendorCompounds { get; set; } = null!;

    public virtual DbSet<HealthEffect> HealthEffects { get; set; } = null!;

    public virtual DbSet<MapItemsPathway> MapItemsPathways { get; set; } = null!;

    public virtual DbSet<Metabolite> Metabolites { get; set; } = null!;

    public virtual DbSet<NcbiTaxonomyMap> NcbiTaxonomyMaps { get; set; } = null!;

    public virtual DbSet<Nutrient> Nutrients { get; set; } = null!;

    public virtual DbSet<OntologySynonym> OntologySynonyms { get; set; } = null!;

    public virtual DbSet<OntologyTerm> OntologyTerms { get; set; } = null!;

    public virtual DbSet<Pathway> Pathways { get; set; } = null!;

    public virtual DbSet<PdbIdentifier> PdbIdentifiers { get; set; } = null!;

    public virtual DbSet<Pfam> Pfams { get; set; } = null!;

    public virtual DbSet<PfamMembership> PfamMemberships { get; set; } = null!;

    public virtual DbSet<Reference> References { get; set; } = null!;

    public virtual DbSet<SchemaMigration> SchemaMigrations { get; set; } = null!;

    public virtual DbSet<Sequence> Sequences { get; set; } = null!;

    public virtual DbSet<SimulateContent> SimulateContents { get; set; } = null!;

    public virtual DbSet<WishartNotice> WishartNotices { get; set; } = null!;

    public virtual DbSet<User> Users { get; set; } = null!;

    public virtual DbSet<UserContent> UserContents { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccessionNumber>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CiteThisArticle>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CiteThisArticleReferencing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Article).WithMany(p => p.CiteThisArticleReferencings)
                .HasConstraintName("fk_rails_e74ef0242f");
        });

        modelBuilder.Entity<CiteThisExternalLink>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CiteThisExternalLinkReferencing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.ExternalLink).WithMany(p => p.CiteThisExternalLinkReferencings)
                .HasConstraintName("fk_rails_a798195c86");
        });

        modelBuilder.Entity<CiteThisTextbook>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CiteThisTextbookReferencing>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Textbook).WithMany(p => p.CiteThisTextbookReferencings)
                .HasConstraintName("fk_rails_c859c1f8e3");
        });

        modelBuilder.Entity<Compound>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Export).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<CompoundAlternateParent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Compound).WithMany(p => p.CompoundAlternateParents)
                .HasConstraintName("fk_rails_0aefaa1014");
        });

        modelBuilder.Entity<CompoundExternalDescriptor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Compound).WithMany(p => p.CompoundExternalDescriptors)
                .HasConstraintName("fk_rails_2395524b9a");
        });

        modelBuilder.Entity<CompoundOntologyTerm>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CompoundSubstituent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Compound).WithMany(p => p.CompoundSubstituents)
                .HasConstraintName("fk_rails_1e68999a98");
        });

        modelBuilder.Entity<CompoundSynonym>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CompoundsEnzyme>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CompoundsFlavor>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CompoundsHealthEffect>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<CompoundsPathway>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.Compound).WithMany(p => p.CompoundsPathways).HasConstraintName("fk_rails_34b0bf14de");

            entity.HasOne(d => d.Pathway).WithMany(p => p.CompoundsPathways).HasConstraintName("fk_rails_14c02acb79");
        });

        modelBuilder.Entity<Content>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Export).HasDefaultValueSql("'1'");
            entity.Property(e => e.OrigUnit).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Enzyme>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<EnzymeSynonym>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Flavor>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.ExportToFoodb).HasDefaultValueSql("'1'");

            entity.HasMany<Content>(e => e.Contents)
                .WithOne()
                .IsRequired();
        });

        modelBuilder.Entity<FoodTaxonomy>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<FoodcomexCompound>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.CasNumber).HasDefaultValueSql("''");
            entity.Property(e => e.ElementalFormula).HasDefaultValueSql("''");
            entity.Property(e => e.ExperimentalLogp).HasDefaultValueSql("''");
            entity.Property(e => e.ExperimentalSolubility).HasDefaultValueSql("''");
            entity.Property(e => e.FoodOfOrigin).HasDefaultValueSql("''");
            entity.Property(e => e.MeltingPoint).HasDefaultValueSql("''");
            entity.Property(e => e.MinimumQuantity).HasDefaultValueSql("''");
            entity.Property(e => e.QuantityUnits).HasDefaultValueSql("''");
            entity.Property(e => e.TaxonomyClass).HasDefaultValueSql("''");
            entity.Property(e => e.TaxonomyFamily).HasDefaultValueSql("''");
        });

        modelBuilder.Entity<FoodcomexCompoundProvider>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<FoodcomexCompoundRequest>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<FoodcomexUserDatum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Role).HasDefaultValueSql("'recipient'");
        });

        modelBuilder.Entity<FoodcomexVendor>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<FoodcomexVendorCompound>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<HealthEffect>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<MapItemsPathway>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Metabolite>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("metabolites", tb => tb.HasComment("Chemical Properties"));

            entity.Property(e => e.HmdbId).HasDefaultValueSql("''");
            entity.Property(e => e.PredictedInHmdb).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<NcbiTaxonomyMap>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Nutrient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Export).HasDefaultValueSql("'0'");
        });

        modelBuilder.Entity<OntologySynonym>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasOne(d => d.OntologyTerm).WithMany(p => p.OntologySynonyms)
                .HasConstraintName("fk_rails_ad89f73357");
        });

        modelBuilder.Entity<OntologyTerm>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Pathway>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<PdbIdentifier>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Pfam>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<PfamMembership>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Reference>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<Sequence>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<SimulateContent>(entity => { entity.HasKey(e => e.Id).HasName("PRIMARY"); });

        modelBuilder.Entity<WishartNotice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Display).HasDefaultValueSql("'0'");
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