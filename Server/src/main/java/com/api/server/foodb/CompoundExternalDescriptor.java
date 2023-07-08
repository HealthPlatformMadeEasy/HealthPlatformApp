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
@Table(name = "compound_external_descriptors")
public class CompoundExternalDescriptor {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @Column(name = "external_id")
    private String externalId;

    @Size(max = 255)
    @Column(name = "annotations")
    private String annotations;

    @ManyToOne(fetch = FetchType.LAZY)
    @JoinColumn(name = "compound_id")
    private Compound compound;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}