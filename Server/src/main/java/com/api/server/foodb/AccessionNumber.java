package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "accession_numbers")
public class AccessionNumber {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @Column(name = "number")
    private String number;

    @Column(name = "compound_id")
    private Integer compoundId;

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