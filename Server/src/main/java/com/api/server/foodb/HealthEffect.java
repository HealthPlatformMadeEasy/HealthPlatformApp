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
@Table(name = "health_effects")
public class HealthEffect {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @NotNull
    @Column(name = "name", nullable = false)
    private String name;

    @Lob
    @Column(name = "description")
    private String description;

    @Size(max = 255)
    @Column(name = "chebi_name")
    private String chebiName;

    @Size(max = 255)
    @Column(name = "chebi_id")
    private String chebiId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @Lob
    @Column(name = "chebi_definition")
    private String chebiDefinition;

}