package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "sequences")
public class Sequence {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @Column(name = "header")
    private String header;

    @Lob
    @Column(name = "chain")
    private String chain;

    @Column(name = "sequenceable_id")
    private Integer sequenceableId;

    @Size(max = 255)
    @Column(name = "sequenceable_type")
    private String sequenceableType;

    @Size(max = 255)
    @Column(name = "type")
    private String type;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}