using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DotNetServer.Core.Entities.Foodb;

[Table("enzymes")]
[Index("GenatlasId", Name = "index_enzymes_on_genatlas_id", IsUnique = true)]
[Index("GenbankGeneId", Name = "index_enzymes_on_genbank_gene_id", IsUnique = true)]
[Index("GenbankProteinId", Name = "index_enzymes_on_genbank_protein_id", IsUnique = true)]
[Index("GeneName", Name = "index_enzymes_on_gene_name", IsUnique = true)]
[Index("GenecardId", Name = "index_enzymes_on_genecard_id", IsUnique = true)]
[Index("HgncId", Name = "index_enzymes_on_hgnc_id", IsUnique = true)]
[Index("HprdId", Name = "index_enzymes_on_hprd_id", IsUnique = true)]
[Index("Name", Name = "index_enzymes_on_name", IsUnique = true)]
[Index("PdbId", Name = "index_enzymes_on_pdb_id", IsUnique = true)]
[Index("UniprotId", Name = "index_enzymes_on_uniprot_id", IsUnique = true)]
[Index("UniprotName", Name = "index_enzymes_on_uniprot_name", IsUnique = true)]
public partial class Enzyme
{
    [Key] [Column("id")] public int Id { get; set; }

    [Column("name")] public string Name { get; set; } = null!;

    [Column("gene_name")] public string? GeneName { get; set; }

    [Column("description", TypeName = "mediumtext")]
    public string? Description { get; set; }

    [Column("go_classification", TypeName = "mediumtext")]
    public string? GoClassification { get; set; }

    [Column("general_function", TypeName = "mediumtext")]
    public string? GeneralFunction { get; set; }

    [Column("specific_function", TypeName = "mediumtext")]
    public string? SpecificFunction { get; set; }

    [Column("pathway", TypeName = "mediumtext")]
    public string? Pathway { get; set; }

    [Column("reaction", TypeName = "mediumtext")]
    public string? Reaction { get; set; }

    [Column("cellular_location")]
    [StringLength(255)]
    public string? CellularLocation { get; set; }

    [Column("signals", TypeName = "mediumtext")]
    public string? Signals { get; set; }

    [Column("transmembrane_regions", TypeName = "mediumtext")]
    public string? TransmembraneRegions { get; set; }

    [Column("molecular_weight")]
    [Precision(15, 9)]
    public decimal? MolecularWeight { get; set; }

    [Column("theoretical_pi")]
    [Precision(15, 9)]
    public decimal? TheoreticalPi { get; set; }

    [Column("locus")] [StringLength(255)] public string? Locus { get; set; }

    [Column("chromosome")]
    [StringLength(255)]
    public string? Chromosome { get; set; }

    [Column("uniprot_name")] public string? UniprotName { get; set; }

    [Column("uniprot_id")]
    [StringLength(100)]
    public string? UniprotId { get; set; }

    [Column("pdb_id")] [StringLength(10)] public string? PdbId { get; set; }

    [Column("genbank_protein_id")]
    [StringLength(20)]
    public string? GenbankProteinId { get; set; }

    [Column("genbank_gene_id")]
    [StringLength(20)]
    public string? GenbankGeneId { get; set; }

    [Column("genecard_id")]
    [StringLength(20)]
    public string? GenecardId { get; set; }

    [Column("genatlas_id")]
    [StringLength(20)]
    public string? GenatlasId { get; set; }

    [Column("hgnc_id")] [StringLength(20)] public string? HgncId { get; set; }

    [Column("hprd_id")] public string? HprdId { get; set; }

    [Column("organism")]
    [StringLength(255)]
    public string? Organism { get; set; }

    [Column("general_citations", TypeName = "mediumtext")]
    public string? GeneralCitations { get; set; }

    [Column("comments", TypeName = "mediumtext")]
    public string? Comments { get; set; }

    [Column("creator_id")] public int? CreatorId { get; set; }

    [Column("updater_id")] public int? UpdaterId { get; set; }

    [Column("created_at", TypeName = "datetime")]
    public DateTime? CreatedAt { get; set; }

    [Column("updated_at", TypeName = "datetime")]
    public DateTime? UpdatedAt { get; set; }
}