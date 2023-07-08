package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;
import org.hibernate.annotations.OnDelete;
import org.hibernate.annotations.OnDeleteAction;

import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "cite_this_external_link_referencings")
public class CiteThisExternalLinkReferencing {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @ManyToOne(fetch = FetchType.LAZY, optional = false)
    @OnDelete(action = OnDeleteAction.CASCADE)
    @JoinColumn(name = "external_link_id", nullable = false)
    private CiteThisExternalLink externalLink;

    @NotNull
    @Column(name = "referencer_id", nullable = false)
    private Integer referencerId;

    @Size(max = 255)
    @NotNull
    @Column(name = "referencer_type", nullable = false)
    private String referencerType;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}