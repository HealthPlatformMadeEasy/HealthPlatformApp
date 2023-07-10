package com.api.server.foodb;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "pdb_identifiers")
public class PdbIdentifier {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "compound_id")
    private Integer compoundId;

    @Size(max = 255)
    @Column(name = "pdb_id")
    private String pdbId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}