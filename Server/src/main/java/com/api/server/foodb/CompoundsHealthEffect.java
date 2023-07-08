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
@Table(name = "compounds_health_effects")
public class CompoundsHealthEffect {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @Column(name = "compound_id", nullable = false)
    private Integer compoundId;

    @NotNull
    @Column(name = "health_effect_id", nullable = false)
    private Integer healthEffectId;

    @Size(max = 255)
    @Column(name = "orig_health_effect_name")
    private String origHealthEffectName;

    @Size(max = 255)
    @Column(name = "orig_compound_name")
    private String origCompoundName;

    @Lob
    @Column(name = "orig_citation")
    private String origCitation;

    @NotNull
    @Lob
    @Column(name = "citation", nullable = false)
    private String citation;

    @Size(max = 255)
    @NotNull
    @Column(name = "citation_type", nullable = false)
    private String citationType;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @Column(name = "source_id")
    private Integer sourceId;

    @Size(max = 255)
    @Column(name = "source_type")
    private String sourceType;

}