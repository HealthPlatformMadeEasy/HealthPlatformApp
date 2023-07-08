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
@Table(name = "ontology_terms")
public class OntologyTerm {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @Column(name = "term")
    private String term;

    @Lob
    @Column(name = "definition")
    private String definition;

    @Size(max = 255)
    @Column(name = "external_id")
    private String externalId;

    @Size(max = 255)
    @Column(name = "external_source")
    private String externalSource;

    @Size(max = 255)
    @Column(name = "comment")
    private String comment;

    @Size(max = 255)
    @Column(name = "curator")
    private String curator;

    @Column(name = "parent_id")
    private Integer parentId;

    @Column(name = "level")
    private Integer level;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

    @Column(name = "legacy_id")
    private Integer legacyId;

}