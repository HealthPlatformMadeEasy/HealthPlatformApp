using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Entities.Foodb;

/// <summary>
/// Chemical Properties
/// </summary>
[Table("metabolites")]
[Index("ExportToHmdb", Name = "index_metabolites_on_export_to_hmdb")]
[Index("ExportToHmdb", "HmdbId", Name = "index_metabolites_on_export_to_hmdb_and_hmdb_id", IsUnique = true)]
[Index("MoldbAverageMass", Name = "index_metabolites_on_moldb_average_mass")]
[Index("MoldbInchikey", Name = "index_metabolites_on_moldb_inchikey")]
[Index("MoldbMonoMass", Name = "index_metabolites_on_moldb_mono_mass")]
[Index("Name", Name = "index_metabolites_on_name", IsUnique = true)]
[Index("Status", Name = "index_metabolites_on_status")]
[Index("UpdatedAt", Name = "index_metabolites_on_updated_at")]
[Index("HmdbId", Name = "index_tbl_chemical_on_hmdb_id", IsUnique = true)]
public partial class Metabolite
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("hmdb_id")] [StringLength(25)] public string HmdbId { get; set; } = null!;

    [Column("created_at", TypeName = "datetime")]
    public DateTime CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime UpdatedAt { get; set; }

    [Column("export_to_hmdb")] public bool ExportToHmdb { get; set; }

    [Column("name")] public string Name { get; set; } = null!;

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("cas")] [StringLength(25)] public string? Cas { get; set; }

    [Column("synthesis_reference", TypeName = "mediumtext")]
    public string? SynthesisReference { get; set; }

    [Column("state")] [StringLength(255)] public string? State { get; set; }

    [Column("status")] public int Status { get; set; }

    [Column("comment", TypeName = "mediumtext")]
    public string? Comment { get; set; }

    [Column("quantified")] public bool Quantified { get; set; }

    [Column("detected")] public bool Detected { get; set; }

    [Column("msds_file_name")]
    [StringLength(255)]
    public string? MsdsFileName { get; set; }

    [Column("msds_content_type")]
    [StringLength(255)]
    public string? MsdsContentType { get; set; }

    [Column("msds_file_size")] public int? MsdsFileSize { get; set; }

    [Column("msds_updated_at", TypeName = "datetime")]
    public DateTime? MsdsUpdatedAt { get; set; }

    [Column("moldb_id")] public int? MoldbId { get; set; }

    [Column("moldb_smiles", TypeName = "text")]
    public string? MoldbSmiles { get; set; }

    [Column("moldb_formula")]
    [StringLength(255)]
    public string? MoldbFormula { get; set; }

    [Column("moldb_inchi", TypeName = "text")]
    public string? MoldbInchi { get; set; }

    [Column("moldb_inchikey")] public string? MoldbInchikey { get; set; }

    [Column("moldb_iupac", TypeName = "text")]
    public string? MoldbIupac { get; set; }

    [Column("moldb_logp")]
    [StringLength(255)]
    public string? MoldbLogp { get; set; }

    [Column("moldb_pka")]
    [StringLength(255)]
    public string? MoldbPka { get; set; }

    [Column("moldb_average_mass")]
    [Precision(9, 4)]
    public decimal? MoldbAverageMass { get; set; }

    [Column("moldb_mono_mass")]
    [Precision(14, 9)]
    public decimal? MoldbMonoMass { get; set; }

    [Column("moldb_alogps_solubility")]
    [StringLength(255)]
    public string? MoldbAlogpsSolubility { get; set; }

    [Column("moldb_alogps_logp")]
    [StringLength(255)]
    public string? MoldbAlogpsLogp { get; set; }

    [Column("moldb_alogps_logs")]
    [StringLength(255)]
    public string? MoldbAlogpsLogs { get; set; }

    [Column("moldb_acceptor_count")]
    [StringLength(255)]
    public string? MoldbAcceptorCount { get; set; }

    [Column("moldb_donor_count")]
    [StringLength(255)]
    public string? MoldbDonorCount { get; set; }

    [Column("moldb_rotatable_bond_count")]
    [StringLength(255)]
    public string? MoldbRotatableBondCount { get; set; }

    [Column("moldb_polar_surface_area")]
    [StringLength(255)]
    public string? MoldbPolarSurfaceArea { get; set; }

    [Column("moldb_refractivity")]
    [StringLength(255)]
    public string? MoldbRefractivity { get; set; }

    [Column("moldb_polarizability")]
    [StringLength(255)]
    public string? MoldbPolarizability { get; set; }

    [Column("moldb_traditional_iupac")]
    [StringLength(255)]
    public string? MoldbTraditionalIupac { get; set; }

    [Column("moldb_formal_charge")] public int? MoldbFormalCharge { get; set; }

    [Column("moldb_physiological_charge")]
    [StringLength(255)]
    public string? MoldbPhysiologicalCharge { get; set; }

    [Column("moldb_pka_strongest_acidic")]
    [StringLength(255)]
    public string? MoldbPkaStrongestAcidic { get; set; }

    [Column("moldb_pka_strongest_basic")]
    [StringLength(255)]
    public string? MoldbPkaStrongestBasic { get; set; }

    [Column("hml_compound")] public bool HmlCompound { get; set; }

    [Column("predicted_in_hmdb")] public bool? PredictedInHmdb { get; set; }

    [Column("thumb_file_name")]
    [StringLength(255)]
    public string? ThumbFileName { get; set; }

    [Column("thumb_content_type")]
    [StringLength(255)]
    public string? ThumbContentType { get; set; }

    [Column("thumb_file_size")] public int? ThumbFileSize { get; set; }

    [Column("thumb_updated_at", TypeName = "datetime")]
    public DateTime? ThumbUpdatedAt { get; set; }
}