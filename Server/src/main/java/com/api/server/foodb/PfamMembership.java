package com.api.server.foodb;

import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.persistence.Table;
import lombok.Getter;
import lombok.Setter;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "pfam_memberships")
public class PfamMembership {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "enzyme_id")
    private Integer enzymeId;

    @Column(name = "pfam_id")
    private Integer pfamId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}