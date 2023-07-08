package com.api.server.foodb;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "compound_synonyms")
public class CompoundSynonym {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @NotNull
    @Column(name = "synonym", nullable = false)
    private String synonym;

    @Size(max = 255)
    @NotNull
    @Column(name = "synonym_source", nullable = false)
    private String synonymSource;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Column(name = "source_id")
    private Integer sourceId;

    @Size(max = 255)
    @Column(name = "source_type")
    private String sourceType;

}