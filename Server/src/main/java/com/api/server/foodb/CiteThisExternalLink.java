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
@Table(name = "cite_this_external_links")
public class CiteThisExternalLink {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 1000)
    @NotNull
    @Column(name = "url", nullable = false, length = 1000)
    private String url;

    @Size(max = 255)
    @NotNull
    @Column(name = "name", nullable = false)
    private String name;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

    @Size(max = 255)
    @Column(name = "ref_id")
    private String refId;

}