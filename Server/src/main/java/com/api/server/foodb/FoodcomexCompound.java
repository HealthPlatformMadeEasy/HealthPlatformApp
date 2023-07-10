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
@Table(name = "foodcomex_compounds")
public class FoodcomexCompound {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @NotNull
    @Column(name = "compound_id", nullable = false)
    private Integer compoundId;

    @Size(max = 255)
    @Column(name = "origin")
    private String origin;

    @Size(max = 255)
    @Column(name = "storage_form")
    private String storageForm;

    @Size(max = 255)
    @Column(name = "maximum_quantity")
    private String maximumQuantity;

    @Size(max = 255)
    @Column(name = "storage_condition")
    private String storageCondition;

    @Size(max = 255)
    @Column(name = "contact_name")
    private String contactName;

    @Lob
    @Column(name = "contact_address")
    private String contactAddress;

    @Size(max = 255)
    @Column(name = "contact_email")
    private String contactEmail;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

    @Column(name = "export")
    private Boolean export;

    @Lob
    @Column(name = "purity")
    private String purity;

    @Lob
    @Column(name = "description")
    private String description;

    @Size(max = 255)
    @Column(name = "spectra_details")
    private String spectraDetails;

    @Size(max = 255)
    @Column(name = "delivery_time")
    private String deliveryTime;

    @Size(max = 255)
    @Column(name = "stability")
    private String stability;

    @Column(name = "admin_user_id")
    private Integer adminUserId;

    @Size(max = 255)
    @NotNull
    @Column(name = "public_id", nullable = false)
    private String publicId;

    @Size(max = 255)
    @Column(name = "cas_number")
    private String casNumber;

    @Size(max = 255)
    @Column(name = "taxonomy_class")
    private String taxonomyClass;

    @Size(max = 255)
    @Column(name = "taxonomy_family")
    private String taxonomyFamily;

    @Size(max = 255)
    @Column(name = "experimental_logp")
    private String experimentalLogp;

    @Size(max = 255)
    @Column(name = "experimental_solubility")
    private String experimentalSolubility;

    @Size(max = 255)
    @Column(name = "melting_point")
    private String meltingPoint;

    @Size(max = 255)
    @Column(name = "food_of_origin")
    private String foodOfOrigin;

    @Lob
    @Column(name = "production_method_reference_text")
    private String productionMethodReferenceText;

    @Size(max = 255)
    @Column(name = "production_method_reference_file_name")
    private String productionMethodReferenceFileName;

    @Size(max = 255)
    @Column(name = "production_method_reference_content_type")
    private String productionMethodReferenceContentType;

    @Column(name = "production_method_reference_file_size")
    private Integer productionMethodReferenceFileSize;

    @Column(name = "production_method_reference_updated_at")
    private Instant productionMethodReferenceUpdatedAt;

    @Size(max = 255)
    @Column(name = "elemental_formula")
    private String elementalFormula;

    @Size(max = 255)
    @Column(name = "minimum_quantity")
    private String minimumQuantity;

    @Size(max = 255)
    @Column(name = "quantity_units")
    private String quantityUnits;

    @Lob
    @Column(name = "available_spectra")
    private String availableSpectra;

    @Lob
    @Column(name = "storage_conditions")
    private String storageConditions;

}