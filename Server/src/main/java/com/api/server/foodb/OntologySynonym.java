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
@Table(name = "ontology_synonyms")
public class OntologySynonym {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "ontology_term_id")
    private OntologyTerm ontologyTerm;

    @Size(max = 255)
    @Column(name = "synonym")
    private String synonym;

    @Size(max = 255)
    @Column(name = "external_id")
    private String externalId;

    @Size(max = 255)
    @Column(name = "external_srouce")
    private String externalSrouce;

    @Size(max = 255)
    @Column(name = "parent_id")
    private String parentId;

    @Size(max = 255)
    @Column(name = "parent_source")
    private String parentSource;

    @Size(max = 255)
    @Column(name = "comment")
    private String comment;

    @Size(max = 255)
    @Column(name = "curator")
    private String curator;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}