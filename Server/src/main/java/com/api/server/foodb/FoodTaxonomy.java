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
@Table(name = "food_taxonomies")
public class FoodTaxonomy {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "food_id")
    private Integer foodId;

    @Column(name = "ncbi_taxonomy_id")
    private Integer ncbiTaxonomyId;

    @Size(max = 255)
    @Column(name = "classification_name")
    private String classificationName;

    @Column(name = "classification_order")
    private Integer classificationOrder;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}