package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.math.BigDecimal;
import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "compounds")
public class Compound {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "legacy_id")
    private Integer legacyId;

    @Size(max = 255)
    @NotNull
    @Column(name = "type", nullable = false)
    private String type;

    @Size(max = 9)
    @NotNull
    @Column(name = "public_id", nullable = false, length = 9)
    private String publicId;

    @Size(max = 255)
    @NotNull
    @Column(name = "name", nullable = false)
    private String name;

    @Column(name = "export")
    private Boolean export;

    @Size(max = 255)
    @Column(name = "state")
    private String state;

    @Size(max = 255)
    @Column(name = "annotation_quality")
    private String annotationQuality;

    @Lob
    @Column(name = "description")
    private String description;

    @Size(max = 255)
    @Column(name = "cas_number")
    private String casNumber;

    @Lob
    @Column(name = "melting_point")
    private String meltingPoint;

    @Size(max = 255)
    @Column(name = "protein_formula")
    private String proteinFormula;

    @Size(max = 255)
    @Column(name = "protein_weight")
    private String proteinWeight;

    @Size(max = 255)
    @Column(name = "experimental_solubility")
    private String experimentalSolubility;

    @Size(max = 255)
    @Column(name = "experimental_logp")
    private String experimentalLogp;

    @Size(max = 255)
    @Column(name = "hydrophobicity")
    private String hydrophobicity;

    @Size(max = 255)
    @Column(name = "isoelectric_point")
    private String isoelectricPoint;

    @Lob
    @Column(name = "metabolism")
    private String metabolism;

    @Size(max = 255)
    @Column(name = "kegg_compound_id")
    private String keggCompoundId;

    @Size(max = 255)
    @Column(name = "pubchem_compound_id")
    private String pubchemCompoundId;

    @Size(max = 255)
    @Column(name = "pubchem_substance_id")
    private String pubchemSubstanceId;

    @Size(max = 255)
    @Column(name = "chebi_id")
    private String chebiId;

    @Size(max = 255)
    @Column(name = "het_id")
    private String hetId;

    @Size(max = 255)
    @Column(name = "uniprot_id")
    private String uniprotId;

    @Size(max = 255)
    @Column(name = "uniprot_name")
    private String uniprotName;

    @Size(max = 255)
    @Column(name = "genbank_id")
    private String genbankId;

    @Size(max = 255)
    @Column(name = "wikipedia_id")
    private String wikipediaId;

    @Lob
    @Column(name = "synthesis_citations")
    private String synthesisCitations;

    @Lob
    @Column(name = "general_citations")
    private String generalCitations;

    @Lob
    @Column(name = "comments")
    private String comments;

    @Size(max = 255)
    @Column(name = "protein_structure_file_name")
    private String proteinStructureFileName;

    @Size(max = 255)
    @Column(name = "protein_structure_content_type")
    private String proteinStructureContentType;

    @Column(name = "protein_structure_file_size")
    private Integer proteinStructureFileSize;

    @Column(name = "protein_structure_updated_at")
    private Instant proteinStructureUpdatedAt;

    @Size(max = 255)
    @Column(name = "msds_file_name")
    private String msdsFileName;

    @Size(max = 255)
    @Column(name = "msds_content_type")
    private String msdsContentType;

    @Column(name = "msds_file_size")
    private Integer msdsFileSize;

    @Column(name = "msds_updated_at")
    private Instant msdsUpdatedAt;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Column(name = "phenolexplorer_id")
    private Integer phenolexplorerId;

    @Size(max = 255)
    @Column(name = "dfc_id")
    private String dfcId;

    @Size(max = 255)
    @Column(name = "hmdb_id")
    private String hmdbId;

    @Size(max = 255)
    @Column(name = "duke_id")
    private String dukeId;

    @Size(max = 255)
    @Column(name = "drugbank_id")
    private String drugbankId;

    @Column(name = "bigg_id")
    private Integer biggId;

    @Size(max = 255)
    @Column(name = "eafus_id")
    private String eafusId;

    @Size(max = 255)
    @Column(name = "knapsack_id")
    private String knapsackId;

    @Size(max = 255)
    @Column(name = "boiling_point")
    private String boilingPoint;

    @Size(max = 255)
    @Column(name = "boiling_point_reference")
    private String boilingPointReference;

    @Size(max = 255)
    @Column(name = "charge")
    private String charge;

    @Size(max = 255)
    @Column(name = "charge_reference")
    private String chargeReference;

    @Size(max = 255)
    @Column(name = "density")
    private String density;

    @Size(max = 255)
    @Column(name = "density_reference")
    private String densityReference;

    @Size(max = 255)
    @Column(name = "optical_rotation")
    private String opticalRotation;

    @Size(max = 255)
    @Column(name = "optical_rotation_reference")
    private String opticalRotationReference;

    @Size(max = 255)
    @Column(name = "percent_composition")
    private String percentComposition;

    @Size(max = 255)
    @Column(name = "percent_composition_reference")
    private String percentCompositionReference;

    @Lob
    @Column(name = "physical_description")
    private String physicalDescription;

    @Lob
    @Column(name = "physical_description_reference")
    private String physicalDescriptionReference;

    @Size(max = 255)
    @Column(name = "refractive_index")
    private String refractiveIndex;

    @Size(max = 255)
    @Column(name = "refractive_index_reference")
    private String refractiveIndexReference;

    @Size(max = 255)
    @Column(name = "uv_index")
    private String uvIndex;

    @Size(max = 255)
    @Column(name = "uv_index_reference")
    private String uvIndexReference;

    @Size(max = 255)
    @Column(name = "experimental_pka")
    private String experimentalPka;

    @Size(max = 255)
    @Column(name = "experimental_pka_reference")
    private String experimentalPkaReference;

    @Size(max = 255)
    @Column(name = "experimental_solubility_reference")
    private String experimentalSolubilityReference;

    @Size(max = 255)
    @Column(name = "experimental_logp_reference")
    private String experimentalLogpReference;

    @Size(max = 255)
    @Column(name = "hydrophobicity_reference")
    private String hydrophobicityReference;

    @Size(max = 255)
    @Column(name = "isoelectric_point_reference")
    private String isoelectricPointReference;

    @Size(max = 255)
    @Column(name = "melting_point_reference")
    private String meltingPointReference;

    @Size(max = 255)
    @Column(name = "moldb_alogps_logp")
    private String moldbAlogpsLogp;

    @Size(max = 255)
    @Column(name = "moldb_logp")
    private String moldbLogp;

    @Size(max = 255)
    @Column(name = "moldb_alogps_logs")
    private String moldbAlogpsLogs;

    @Lob
    @Column(name = "moldb_smiles")
    private String moldbSmiles;

    @Size(max = 255)
    @Column(name = "moldb_pka")
    private String moldbPka;

    @Size(max = 255)
    @Column(name = "moldb_formula")
    private String moldbFormula;

    @Column(name = "moldb_average_mass", precision = 9, scale = 4)
    private BigDecimal moldbAverageMass;

    @Lob
    @Column(name = "moldb_inchi")
    private String moldbInchi;

    @Column(name = "moldb_mono_mass", precision = 14, scale = 9)
    private BigDecimal moldbMonoMass;

    @Size(max = 255)
    @Column(name = "moldb_inchikey")
    private String moldbInchikey;

    @Size(max = 255)
    @Column(name = "moldb_alogps_solubility")
    private String moldbAlogpsSolubility;

    @Column(name = "moldb_id")
    private Integer moldbId;

    @Lob
    @Column(name = "moldb_iupac")
    private String moldbIupac;

    @Size(max = 255)
    @Column(name = "structure_source")
    private String structureSource;

    @Size(max = 255)
    @Column(name = "duplicate_id")
    private String duplicateId;

    @Size(max = 255)
    @Column(name = "old_dfc_id")
    private String oldDfcId;

    @Lob
    @Column(name = "dfc_name")
    private String dfcName;

    @Size(max = 255)
    @Column(name = "compound_source")
    private String compoundSource;

    @Size(max = 255)
    @Column(name = "flavornet_id")
    private String flavornetId;

    @Size(max = 255)
    @Column(name = "goodscent_id")
    private String goodscentId;

    @Size(max = 255)
    @Column(name = "superscent_id")
    private String superscentId;

    @Column(name = "phenolexplorer_metabolite_id")
    private Integer phenolexplorerMetaboliteId;

    @Size(max = 255)
    @Column(name = "kingdom")
    private String kingdom;

    @Size(max = 255)
    @Column(name = "superklass")
    private String superklass;

    @Size(max = 255)
    @Column(name = "klass")
    private String klass;

    @Size(max = 255)
    @Column(name = "subklass")
    private String subklass;

    @Size(max = 255)
    @Column(name = "direct_parent")
    private String directParent;

    @Size(max = 255)
    @Column(name = "molecular_framework")
    private String molecularFramework;

    @Size(max = 255)
    @Column(name = "chembl_id")
    private String chemblId;

    @Size(max = 255)
    @Column(name = "chemspider_id")
    private String chemspiderId;

    @Size(max = 255)
    @Column(name = "meta_cyc_id")
    private String metaCycId;

    @Column(name = "foodcomex")
    private Boolean foodcomex;

    @Size(max = 255)
    @Column(name = "phytohub_id")
    private String phytohubId;

    @Size(max = 255)
    @Column(name = "vmh_id")
    private String vmhId;

    @Size(max = 255)
    @Column(name = "fbonto_id")
    private String fbontoId;

    @NotNull
    @Column(name = "status", nullable = false)
    private Byte status;

}