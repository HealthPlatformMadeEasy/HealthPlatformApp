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
@Table(name = "foodcomex_vendor_compounds")
public class FoodcomexVendorCompound {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @NotNull
    @Column(name = "foodcomex_vendor_id", nullable = false)
    private String foodcomexVendorId;

    @Size(max = 255)
    @Column(name = "catalogue_number")
    private String catalogueNumber;

    @Lob
    @Column(name = "name")
    private String name;

    @Size(max = 255)
    @Column(name = "cas_number")
    private String casNumber;

    @Size(max = 255)
    @Column(name = "inchikey")
    private String inchikey;

    @Size(max = 255)
    @Column(name = "url")
    private String url;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

}