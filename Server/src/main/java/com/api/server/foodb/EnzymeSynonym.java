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
@Table(name = "enzyme_synonyms")
public class EnzymeSynonym {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @Column(name = "enzyme_id", nullable = false)
    private Integer enzymeId;

    @Size(max = 255)
    @NotNull
    @Column(name = "synonym", nullable = false)
    private String synonym;

    @Size(max = 255)
    @NotNull
    @Column(name = "source", nullable = false)
    private String source;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}