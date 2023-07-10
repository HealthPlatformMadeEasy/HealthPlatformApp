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
@Table(name = "enzymes")
public class Enzyme {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @NotNull
    @Column(name = "name", nullable = false)
    private String name;

    @Size(max = 255)
    @Column(name = "gene_name")
    private String geneName;

    @Lob
    @Column(name = "description")
    private String description;

    @Lob
    @Column(name = "go_classification")
    private String goClassification;

    @Lob
    @Column(name = "general_function")
    private String generalFunction;

    @Lob
    @Column(name = "specific_function")
    private String specificFunction;

    @Lob
    @Column(name = "pathway")
    private String pathway;

    @Lob
    @Column(name = "reaction")
    private String reaction;

    @Size(max = 255)
    @Column(name = "cellular_location")
    private String cellularLocation;

    @Lob
    @Column(name = "signals")
    private String signals;

    @Lob
    @Column(name = "transmembrane_regions")
    private String transmembraneRegions;

    @Column(name = "molecular_weight", precision = 15, scale = 9)
    private BigDecimal molecularWeight;

    @Column(name = "theoretical_pi", precision = 15, scale = 9)
    private BigDecimal theoreticalPi;

    @Size(max = 255)
    @Column(name = "locus")
    private String locus;

    @Size(max = 255)
    @Column(name = "chromosome")
    private String chromosome;

    @Size(max = 255)
    @Column(name = "uniprot_name")
    private String uniprotName;

    @Size(max = 100)
    @Column(name = "uniprot_id", length = 100)
    private String uniprotId;

    @Size(max = 10)
    @Column(name = "pdb_id", length = 10)
    private String pdbId;

    @Size(max = 20)
    @Column(name = "genbank_protein_id", length = 20)
    private String genbankProteinId;

    @Size(max = 20)
    @Column(name = "genbank_gene_id", length = 20)
    private String genbankGeneId;

    @Size(max = 20)
    @Column(name = "genecard_id", length = 20)
    private String genecardId;

    @Size(max = 20)
    @Column(name = "genatlas_id", length = 20)
    private String genatlasId;

    @Size(max = 20)
    @Column(name = "hgnc_id", length = 20)
    private String hgncId;

    @Size(max = 255)
    @Column(name = "hprd_id")
    private String hprdId;

    @Size(max = 255)
    @Column(name = "organism")
    private String organism;

    @Lob
    @Column(name = "general_citations")
    private String generalCitations;

    @Lob
    @Column(name = "comments")
    private String comments;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}