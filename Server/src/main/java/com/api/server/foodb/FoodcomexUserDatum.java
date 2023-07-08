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
@Table(name = "foodcomex_user_data")
public class FoodcomexUserDatum {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Size(max = 255)
    @NotNull
    @Column(name = "role", nullable = false)
    private String role;

    @Size(max = 255)
    @Column(name = "gender")
    private String gender;

    @Size(max = 255)
    @Column(name = "position")
    private String position;

    @Size(max = 255)
    @Column(name = "institution")
    private String institution;

    @Size(max = 255)
    @Column(name = "department")
    private String department;

    @Size(max = 255)
    @Column(name = "address")
    private String address;

    @Size(max = 255)
    @Column(name = "city")
    private String city;

    @Size(max = 255)
    @Column(name = "country")
    private String country;

    @Size(max = 255)
    @Column(name = "phone_number")
    private String phoneNumber;

    @Size(max = 255)
    @Column(name = "zip_code")
    private String zipCode;

    @Size(max = 255)
    @Column(name = "institution_type")
    private String institutionType;

    @Size(max = 255)
    @Column(name = "area_of_research")
    private String areaOfResearch;

    @Lob
    @Column(name = "area_of_research_detailed")
    private String areaOfResearchDetailed;

    @Lob
    @Column(name = "activities")
    private String activities;

    @Lob
    @Column(name = "interests")
    private String interests;

    @Lob
    @Column(name = "purpose_of_use")
    private String purposeOfUse;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Column(name = "admin_user_id")
    private Integer adminUserId;

}