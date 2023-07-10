package com.api.server.foodb;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import jakarta.validation.constraints.NotNull;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "compound_ontology_terms")
public class CompoundOntologyTerm {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "compound_id")
    private Integer compoundId;

    @Column(name = "export")
    private Boolean export;

    @Column(name = "ontology_term_id")
    private Integer ontologyTermId;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}