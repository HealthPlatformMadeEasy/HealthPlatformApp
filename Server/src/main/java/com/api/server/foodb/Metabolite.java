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
@Table(name = "metabolites")
public class Metabolite {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 25)
    @NotNull
    @Column(name = "hmdb_id", nullable = false, length = 25)
    private String hmdbId;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

    @NotNull
    @Column(name = "export_to_hmdb", nullable = false)
    private Boolean exportToHmdb = false;

    @Size(max = 255)
    @NotNull
    @Column(name = "name", nullable = false)
    private String name;

    @Lob
    @Column(name = "description")
    private String description;

    @Size(max = 25)
    @Column(name = "cas", length = 25)
    private String cas;

    @Lob
    @Column(name = "synthesis_reference")
    private String synthesisReference;

    @Size(max = 255)
    @Column(name = "state")
    private String state;

    @NotNull
    @Column(name = "status", nullable = false)
    private Integer status;

    @Lob
    @Column(name = "comment")
    private String comment;

    @NotNull
    @Column(name = "quantified", nullable = false)
    private Boolean quantified = false;

    @NotNull
    @Column(name = "detected", nullable = false)
    private Boolean detected = false;

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

    @Column(name = "moldb_id")
    private Integer moldbId;

    @Lob
    @Column(name = "moldb_smiles")
    private String moldbSmiles;

    @Size(max = 255)
    @Column(name = "moldb_formula")
    private String moldbFormula;

    @Lob
    @Column(name = "moldb_inchi")
    private String moldbInchi;

    @Size(max = 255)
    @Column(name = "moldb_inchikey")
    private String moldbInchikey;

    @Lob
    @Column(name = "moldb_iupac")
    private String moldbIupac;

    @Size(max = 255)
    @Column(name = "moldb_logp")
    private String moldbLogp;

    @Size(max = 255)
    @Column(name = "moldb_pka")
    private String moldbPka;

    @Column(name = "moldb_average_mass", precision = 9, scale = 4)
    private BigDecimal moldbAverageMass;

    @Column(name = "moldb_mono_mass", precision = 14, scale = 9)
    private BigDecimal moldbMonoMass;

    @Size(max = 255)
    @Column(name = "moldb_alogps_solubility")
    private String moldbAlogpsSolubility;

    @Size(max = 255)
    @Column(name = "moldb_alogps_logp")
    private String moldbAlogpsLogp;

    @Size(max = 255)
    @Column(name = "moldb_alogps_logs")
    private String moldbAlogpsLogs;

    @Size(max = 255)
    @Column(name = "moldb_acceptor_count")
    private String moldbAcceptorCount;

    @Size(max = 255)
    @Column(name = "moldb_donor_count")
    private String moldbDonorCount;

    @Size(max = 255)
    @Column(name = "moldb_rotatable_bond_count")
    private String moldbRotatableBondCount;

    @Size(max = 255)
    @Column(name = "moldb_polar_surface_area")
    private String moldbPolarSurfaceArea;

    @Size(max = 255)
    @Column(name = "moldb_refractivity")
    private String moldbRefractivity;

    @Size(max = 255)
    @Column(name = "moldb_polarizability")
    private String moldbPolarizability;

    @Size(max = 255)
    @Column(name = "moldb_traditional_iupac")
    private String moldbTraditionalIupac;

    @Column(name = "moldb_formal_charge")
    private Integer moldbFormalCharge;

    @Size(max = 255)
    @Column(name = "moldb_physiological_charge")
    private String moldbPhysiologicalCharge;

    @Size(max = 255)
    @Column(name = "moldb_pka_strongest_acidic")
    private String moldbPkaStrongestAcidic;

    @Size(max = 255)
    @Column(name = "moldb_pka_strongest_basic")
    private String moldbPkaStrongestBasic;

    @NotNull
    @Column(name = "hml_compound", nullable = false)
    private Boolean hmlCompound = false;

    @Column(name = "predicted_in_hmdb")
    private Boolean predictedInHmdb;

    @Size(max = 255)
    @Column(name = "thumb_file_name")
    private String thumbFileName;

    @Size(max = 255)
    @Column(name = "thumb_content_type")
    private String thumbContentType;

    @Column(name = "thumb_file_size")
    private Integer thumbFileSize;

    @Column(name = "thumb_updated_at")
    private Instant thumbUpdatedAt;

}