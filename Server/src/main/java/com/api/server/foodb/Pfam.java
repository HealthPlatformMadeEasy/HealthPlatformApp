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
@Table(name = "pfams")
public class Pfam {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 7)
    @Column(name = "identifier", length = 7)
    private String identifier;

    @Size(max = 50)
    @Column(name = "name", length = 50)
    private String name;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}