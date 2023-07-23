using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("foodcomex_compounds")]
[Index("AdminUserId", Name = "index_foodcomex_compounds_on_admin_user_id")]
[Index("CompoundId", Name = "index_foodcomex_compounds_on_compound_id")]
public partial class FoodcomexCompound
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("compound_id")] public int CompoundId { get; set; }

    [Column("origin")] [StringLength(255)] public string? Origin { get; set; }

    [Column("storage_form")]
    [StringLength(255)]
    public string? StorageForm { get; set; }

    [Column("maximum_quantity")]
    [StringLength(255)]
    public string? MaximumQuantity { get; set; }

    [Column("storage_condition")]
    [StringLength(255)]
    public string? StorageCondition { get; set; }

    [Column("contact_name")]
    [StringLength(255)]
    public string? ContactName { get; set; }

    [Column("contact_address", TypeName = "text")]
    public string? ContactAddress { get; set; }

    [Column("contact_email")]
    [StringLength(255)]
    public string? ContactEmail { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("export")] public bool? Export { get; set; }

    [Column("purity", TypeName = "text")] public string? Purity { get; set; }

    [Column("description", TypeName = "text")]
    public string? Description { get; set; }

    [Column("spectra_details")]
    [StringLength(255)]
    public string? SpectraDetails { get; set; }

    [Column("delivery_time")]
    [StringLength(255)]
    public string? DeliveryTime { get; set; }

    [Column("stability")]
    [StringLength(255)]
    public string? Stability { get; set; }

    [Column("admin_user_id")] public int? AdminUserId { get; set; }

    [Column("public_id")]
    [StringLength(255)]
    public string PublicId { get; set; } = null!;

    [Column("cas_number")]
    [StringLength(255)]
    public string? CasNumber { get; set; }

    [Column("taxonomy_class")]
    [StringLength(255)]
    public string? TaxonomyClass { get; set; }

    [Column("taxonomy_family")]
    [StringLength(255)]
    public string? TaxonomyFamily { get; set; }

    [Column("experimental_logp")]
    [StringLength(255)]
    public string? ExperimentalLogp { get; set; }

    [Column("experimental_solubility")]
    [StringLength(255)]
    public string? ExperimentalSolubility { get; set; }

    [Column("melting_point")]
    [StringLength(255)]
    public string? MeltingPoint { get; set; }

    [Column("food_of_origin")]
    [StringLength(255)]
    public string? FoodOfOrigin { get; set; }

    [Column("production_method_reference_text", TypeName = "text")]
    public string? ProductionMethodReferenceText { get; set; }

    [Column("production_method_reference_file_name")]
    [StringLength(255)]
    public string? ProductionMethodReferenceFileName { get; set; }

    [Column("production_method_reference_content_type")]
    [StringLength(255)]
    public string? ProductionMethodReferenceContentType { get; set; }

    [Column("production_method_reference_file_size")]
    public int? ProductionMethodReferenceFileSize { get; set; }

    [Column("production_method_reference_updated_at", TypeName = "datetime")]
    public DateTime? ProductionMethodReferenceUpdatedAt { get; set; }

    [Column("elemental_formula")]
    [StringLength(255)]
    public string? ElementalFormula { get; set; }

    [Column("minimum_quantity")]
    [StringLength(255)]
    public string? MinimumQuantity { get; set; }

    [Column("quantity_units")]
    [StringLength(255)]
    public string? QuantityUnits { get; set; }

    [Column("available_spectra", TypeName = "text")]
    public string? AvailableSpectra { get; set; }

    [Column("storage_conditions", TypeName = "text")]
    public string? StorageConditions { get; set; }
}