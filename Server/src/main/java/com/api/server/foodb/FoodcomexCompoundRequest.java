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
@Table(name = "foodcomex_compound_requests")
public class FoodcomexCompoundRequest {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @Column(name = "admin_user_id", nullable = false)
    private Integer adminUserId;

    @Lob
    @Column(name = "structure")
    private String structure;

    @Size(max = 255)
    @Column(name = "inchikey")
    private String inchikey;

    @Size(max = 255)
    @Column(name = "inchi")
    private String inchi;

    @Size(max = 255)
    @Column(name = "smiles")
    private String smiles;

    @Size(max = 255)
    @Column(name = "structure_image_file_name")
    private String structureImageFileName;

    @Size(max = 255)
    @Column(name = "structure_image_content_type")
    private String structureImageContentType;

    @Column(name = "structure_image_file_size")
    private Integer structureImageFileSize;

    @Column(name = "structure_image_updated_at")
    private Instant structureImageUpdatedAt;

    @Size(max = 255)
    @Column(name = "name")
    private String name;

    @Lob
    @Column(name = "message")
    private String message;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}