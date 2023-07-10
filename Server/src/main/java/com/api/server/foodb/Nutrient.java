package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "nutrients")
public class Nutrient {
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
    @Column(name = "wikipedia_id")
    private String wikipediaId;

    @Lob
    @Column(name = "comments")
    private String comments;

    @Size(max = 255)
    @Column(name = "dfc_id")
    private String dfcId;

    @Size(max = 255)
    @Column(name = "duke_id")
    private String dukeId;

    @Size(max = 255)
    @Column(name = "eafus_id")
    private String eafusId;

    @Lob
    @Column(name = "dfc_name")
    private String dfcName;

    @Size(max = 255)
    @Column(name = "compound_source")
    private String compoundSource;

    @Lob
    @Column(name = "metabolism")
    private String metabolism;

    @Lob
    @Column(name = "synthesis_citations")
    private String synthesisCitations;

    @Lob
    @Column(name = "general_citations")
    private String generalCitations;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}