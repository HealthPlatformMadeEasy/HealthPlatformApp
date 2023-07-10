package com.api.server.foodb;

import jakarta.persistence.*;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Size;
import lombok.Getter;
import lombok.Setter;

import java.math.BigDecimal;
import java.time.Instant;

@Getter
@Setter
@Entity
@Table(name = "simulate_contents")
public class SimulateContent {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "source_id")
    private Integer sourceId;

    @Size(max = 255)
    @Column(name = "source_type")
    private String sourceType;

    @Column(name = "food_id")
    private Integer foodId;

    @Column(name = "orig_food_id")
    private Integer origFoodId;

    @Size(max = 255)
    @Column(name = "orig_food_part")
    private String origFoodPart;

    @Size(max = 255)
    @Column(name = "orig_source_id")
    private String origSourceId;

    @Size(max = 255)
    @Column(name = "orig_source_name")
    private String origSourceName;

    @Size(max = 255)
    @Column(name = "orig_citation")
    private String origCitation;

    @Size(max = 255)
    @Column(name = "citation")
    private String citation;

    @Size(max = 255)
    @Column(name = "citation_type")
    private String citationType;

    @NotNull
    @Column(name = "created_at", nullable = false)
    private Instant createdAt;

    @NotNull
    @Column(name = "updated_at", nullable = false)
    private Instant updatedAt;

    @Column(name = "orig_min", precision = 15, scale = 9)
    private BigDecimal origMin;

    @Column(name = "orig_max", precision = 15, scale = 9)
    private BigDecimal origMax;

    @Size(max = 255)
    @Column(name = "orig_unit")
    private String origUnit;

    @Size(max = 255)
    @Column(name = "orig_food_common_name")
    private String origFoodCommonName;

    @Size(max = 255)
    @Column(name = "orig_food_scientific_name")
    private String origFoodScientificName;

    @Column(name = "orig_content", precision = 15, scale = 9)
    private BigDecimal origContent;

    @Size(max = 255)
    @Column(name = "creater_id")
    private String createrId;

    @Size(max = 255)
    @Column(name = "updater_id")
    private String updaterId;

    @Size(max = 255)
    @Column(name = "orig_method")
    private String origMethod;

    @Size(max = 255)
    @Column(name = "orig_unit_expression")
    private String origUnitExpression;

    @Column(name = "standard_content", precision = 10)
    private BigDecimal standardContent;

    @Size(max = 255)
    @Column(name = "preparation_type")
    private String preparationType;

    @Size(max = 255)
    @NotNull
    @Column(name = "food_type", nullable = false)
    private String foodType;

}