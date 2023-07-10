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
@Table(name = "map_items_pathways")
public class MapItemsPathway {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "map_item_id")
    private Integer mapItemId;

    @Size(max = 255)
    @Column(name = "map_item_type")
    private String mapItemType;

    @Column(name = "pathway_id")
    private Integer pathwayId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

}