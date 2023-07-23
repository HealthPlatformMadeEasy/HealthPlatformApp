using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

[Table("compounds")]
[Index("Name", Name = "index_compounds_on_name", IsUnique = true)]
[Index("Name", "PublicId", Name = "index_compounds_on_name_and_public_id", IsUnique = true)]
[Index("PublicId", Name = "index_compounds_on_public_id", IsUnique = true)]
public partial class Compound
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("legacy_id")] public int? LegacyId { get; set; }

    [Column("type")] [StringLength(255)] public string Type { get; set; } = null!;

    [Column("public_id")]
    [StringLength(9)]
    public string PublicId { get; set; } = null!;

    [Column("name")] public string Name { get; set; } = null!;

    [Column("export")] public bool? Export { get; set; }

    [Column("state")] [StringLength(255)] public string? State { get; set; }

    [Column("annotation_quality")]
    [StringLength(255)]
    public string? AnnotationQuality { get; set; }

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("cas_number")]
    [StringLength(255)]
    public string? CasNumber { get; set; }

    [Column("melting_point", TypeName = "mediumtext")]
    public string? MeltingPoint { get; set; }

    [Column("protein_formula")]
    [StringLength(255)]
    public string? ProteinFormula { get; set; }

    [Column("protein_weight")]
    [StringLength(255)]
    public string? ProteinWeight { get; set; }

    [Column("experimental_solubility")]
    [StringLength(255)]
    public string? ExperimentalSolubility { get; set; }

    [Column("experimental_logp")]
    [StringLength(255)]
    public string? ExperimentalLogp { get; set; }

    [Column("hydrophobicity")]
    [StringLength(255)]
    public string? Hydrophobicity { get; set; }

    [Column("isoelectric_point")]
    [StringLength(255)]
    public string? IsoelectricPoint { get; set; }

    [Column("metabolism", TypeName = "mediumtext")]
    public string? Metabolism { get; set; }

    [Column("kegg_compound_id")]
    [StringLength(255)]
    public string? KeggCompoundId { get; set; }

    [Column("pubchem_compound_id")]
    [StringLength(255)]
    public string? PubchemCompoundId { get; set; }

    [Column("pubchem_substance_id")]
    [StringLength(255)]
    public string? PubchemSubstanceId { get; set; }

    [Column("chebi_id")]
    [StringLength(255)]
    public string? ChebiId { get; set; }

    [Column("het_id")] [StringLength(255)] public string? HetId { get; set; }

    [Column("uniprot_id")]
    [StringLength(255)]
    public string? UniprotId { get; set; }

    [Column("uniprot_name")]
    [StringLength(255)]
    public string? UniprotName { get; set; }

    [Column("genbank_id")]
    [StringLength(255)]
    public string? GenbankId { get; set; }

    [Column("wikipedia_id")]
    [StringLength(255)]
    public string? WikipediaId { get; set; }

    [Column("synthesis_citations", TypeName = "mediumtext")]
    public string? SynthesisCitations { get; set; }

    [Column("general_citations", TypeName = "mediumtext")]
    public string? GeneralCitations { get; set; }

    [Column("comments", TypeName = "mediumtext")]
    public string? Comments { get; set; }

    [Column("protein_structure_file_name")]
    [StringLength(255)]
    public string? ProteinStructureFileName { get; set; }

    [Column("protein_structure_content_type")]
    [StringLength(255)]
    public string? ProteinStructureContentType { get; set; }

    [Column("protein_structure_file_size")]
    public int? ProteinStructureFileSize { get; set; }

    [Column("protein_structure_updated_at", TypeName = "datetime")]
    public DateTime? ProteinStructureUpdatedAt { get; set; }

    [Column("msds_file_name")]
    [StringLength(255)]
    public string? MsdsFileName { get; set; }

    [Column("msds_content_type")]
    [StringLength(255)]
    public string? MsdsContentType { get; set; }

    [Column("msds_file_size")] public int? MsdsFileSize { get; set; }

    [Column("msds_updated_at", TypeName = "datetime")]
    public DateTime? MsdsUpdatedAt { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }

    [Column("phenolexplorer_id")] public int? PhenolexplorerId { get; set; }

    [Column("dfc_id")] [StringLength(255)] public string? DfcId { get; set; }

    [Column("hmdb_id")]
    [StringLength(255)]
    public string? HmdbId { get; set; }

    [Column("duke_id")]
    [StringLength(255)]
    public string? DukeId { get; set; }

    [Column("drugbank_id")]
    [StringLength(255)]
    public string? DrugbankId { get; set; }

    [Column("bigg_id")] public int? BiggId { get; set; }

    [Column("eafus_id")]
    [StringLength(255)]
    public string? EafusId { get; set; }

    [Column("knapsack_id")]
    [StringLength(255)]
    public string? KnapsackId { get; set; }

    [Column("boiling_point")]
    [StringLength(255)]
    public string? BoilingPoint { get; set; }

    [Column("boiling_point_reference")]
    [StringLength(255)]
    public string? BoilingPointReference { get; set; }

    [Column("charge")] [StringLength(255)] public string? Charge { get; set; }

    [Column("charge_reference")]
    [StringLength(255)]
    public string? ChargeReference { get; set; }

    [Column("density")]
    [StringLength(255)]
    public string? Density { get; set; }

    [Column("density_reference")]
    [StringLength(255)]
    public string? DensityReference { get; set; }

    [Column("optical_rotation")]
    [StringLength(255)]
    public string? OpticalRotation { get; set; }

    [Column("optical_rotation_reference")]
    [StringLength(255)]
    public string? OpticalRotationReference { get; set; }

    [Column("percent_composition")]
    [StringLength(255)]
    public string? PercentComposition { get; set; }

    [Column("percent_composition_reference")]
    [StringLength(255)]
    public string? PercentCompositionReference { get; set; }

    [Column("physical_description", TypeName = "mediumtext")]
    public string? PhysicalDescription { get; set; }

    [Column("physical_description_reference", TypeName = "mediumtext")]
    public string? PhysicalDescriptionReference { get; set; }

    [Column("refractive_index")]
    [StringLength(255)]
    public string? RefractiveIndex { get; set; }

    [Column("refractive_index_reference")]
    [StringLength(255)]
    public string? RefractiveIndexReference { get; set; }

    [Column("uv_index")]
    [StringLength(255)]
    public string? UvIndex { get; set; }

    [Column("uv_index_reference")]
    [StringLength(255)]
    public string? UvIndexReference { get; set; }

    [Column("experimental_pka")]
    [StringLength(255)]
    public string? ExperimentalPka { get; set; }

    [Column("experimental_pka_reference")]
    [StringLength(255)]
    public string? ExperimentalPkaReference { get; set; }

    [Column("experimental_solubility_reference")]
    [StringLength(255)]
    public string? ExperimentalSolubilityReference { get; set; }

    [Column("experimental_logp_reference")]
    [StringLength(255)]
    public string? ExperimentalLogpReference { get; set; }

    [Column("hydrophobicity_reference")]
    [StringLength(255)]
    public string? HydrophobicityReference { get; set; }

    [Column("isoelectric_point_reference")]
    [StringLength(255)]
    public string? IsoelectricPointReference { get; set; }

    [Column("melting_point_reference")]
    [StringLength(255)]
    public string? MeltingPointReference { get; set; }

    [Column("moldb_alogps_logp")]
    [StringLength(255)]
    public string? MoldbAlogpsLogp { get; set; }

    [Column("moldb_logp")]
    [StringLength(255)]
    public string? MoldbLogp { get; set; }

    [Column("moldb_alogps_logs")]
    [StringLength(255)]
    public string? MoldbAlogpsLogs { get; set; }

    [Column("moldb_smiles", TypeName = "mediumtext")]
    public string? MoldbSmiles { get; set; }

    [Column("moldb_pka")]
    [StringLength(255)]
    public string? MoldbPka { get; set; }

    [Column("moldb_formula")]
    [StringLength(255)]
    public string? MoldbFormula { get; set; }

    [Column("moldb_average_mass")]
    [Precision(9, 4)]
    public decimal? MoldbAverageMass { get; set; }

    [Column("moldb_inchi", TypeName = "mediumtext")]
    public string? MoldbInchi { get; set; }

    [Column("moldb_mono_mass")]
    [Precision(14, 9)]
    public decimal? MoldbMonoMass { get; set; }

    [Column("moldb_inchikey")]
    [StringLength(255)]
    public string? MoldbInchikey { get; set; }

    [Column("moldb_alogps_solubility")]
    [StringLength(255)]
    public string? MoldbAlogpsSolubility { get; set; }

    [Column("moldb_id")] public int? MoldbId { get; set; }

    [Column("moldb_iupac", TypeName = "mediumtext")]
    public string? MoldbIupac { get; set; }

    [Column("structure_source")]
    [StringLength(255)]
    public string? StructureSource { get; set; }

    [Column("duplicate_id")]
    [StringLength(255)]
    public string? DuplicateId { get; set; }

    [Column("old_dfc_id")]
    [StringLength(255)]
    public string? OldDfcId { get; set; }

    [Column("dfc_name", TypeName = "mediumtext")]
    public string? DfcName { get; set; }

    [Column("compound_source")]
    [StringLength(255)]
    public string? CompoundSource { get; set; }

    [Column("flavornet_id")]
    [StringLength(255)]
    public string? FlavornetId { get; set; }

    [Column("goodscent_id")]
    [StringLength(255)]
    public string? GoodscentId { get; set; }

    [Column("superscent_id")]
    [StringLength(255)]
    public string? SuperscentId { get; set; }

    [Column("phenolexplorer_metabolite_id")]
    public int? PhenolexplorerMetaboliteId { get; set; }

    [Column("kingdom")]
    [StringLength(255)]
    public string? Kingdom { get; set; }

    [Column("superklass")]
    [StringLength(255)]
    public string? Superklass { get; set; }

    [Column("klass")] [StringLength(255)] public string? Klass { get; set; }

    [Column("subklass")]
    [StringLength(255)]
    public string? Subklass { get; set; }

    [Column("direct_parent")]
    [StringLength(255)]
    public string? DirectParent { get; set; }

    [Column("molecular_framework")]
    [StringLength(255)]
    public string? MolecularFramework { get; set; }

    [Column("chembl_id")]
    [StringLength(255)]
    public string? ChemblId { get; set; }

    [Column("chemspider_id")]
    [StringLength(255)]
    public string? ChemspiderId { get; set; }

    [Column("meta_cyc_id")]
    [StringLength(255)]
    public string? MetaCycId { get; set; }

    [Column("foodcomex")] public bool? Foodcomex { get; set; }

    [Column("phytohub_id")]
    [StringLength(255)]
    public string? PhytohubId { get; set; }

    [Column("vmh_id")] [StringLength(255)] public string? VmhId { get; set; }

    [Column("fbonto_id")]
    [StringLength(255)]
    public string? FbontoId { get; set; }

    [Column("status")] public sbyte Status { get; set; }

    [InverseProperty("Compound")]
    public virtual ICollection<CompoundAlternateParent> CompoundAlternateParents { get; set; } =
        new List<CompoundAlternateParent>();

    [InverseProperty("Compound")]
    public virtual ICollection<CompoundExternalDescriptor> CompoundExternalDescriptors { get; set; } =
        new List<CompoundExternalDescriptor>();

    [InverseProperty("Compound")]
    public virtual ICollection<CompoundSubstituent> CompoundSubstituents { get; set; } =
        new List<CompoundSubstituent>();

    [InverseProperty("Compound")]
    public virtual ICollection<CompoundsPathway> CompoundsPathways { get; set; } = new List<CompoundsPathway>();
}