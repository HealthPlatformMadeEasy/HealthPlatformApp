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
@Table(name = "foods")
public class Food {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @NotNull
    @Column(name = "name", nullable = false)
    private String name;

    @Size(max = 255)
    @Column(name = "name_scientific")
    private String nameScientific;

    @Lob
    @Column(name = "description")
    private String description;

    @Size(max = 255)
    @Column(name = "itis_id")
    private String itisId;

    @Size(max = 255)
    @Column(name = "wikipedia_id")
    private String wikipediaId;

    @Size(max = 255)
    @Column(name = "picture_file_name")
    private String pictureFileName;

    @Size(max = 255)
    @Column(name = "picture_content_type")
    private String pictureContentType;

    @Column(name = "picture_file_size")
    private Integer pictureFileSize;

    @Column(name = "picture_updated_at")
    private Instant pictureUpdatedAt;

    @Column(name = "legacy_id")
    private Integer legacyId;

    @Size(max = 255)
    @Column(name = "food_group")
    private String foodGroup;

    @Size(max = 255)
    @Column(name = "food_subgroup")
    private String foodSubgroup;

    @Size(max = 255)
    @NotNull
    @Column(name = "food_type", nullable = false)
    private String foodType;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @NotNull
    @Column(name = "export_to_afcdb", nullable = false)
    private Boolean exportToAfcdb = false;

    @Size(max = 255)
    @Column(name = "category")
    private String category;

    @Column(name = "ncbi_taxonomy_id")
    private Integer ncbiTaxonomyId;

    @Column(name = "export_to_foodb")
    private Boolean exportToFoodb;

    @Size(max = 255)
    @Column(name = "public_id")
    private String publicId;

}