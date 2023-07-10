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
@Table(name = "contents")
public class Content {
    @Id
    @Column(name = "id", nullable = false)
    private Integer id;

    @Column(name = "source_id")
    private Integer sourceId;

    @Size(max = 255)
    @Column(name = "source_type")
    private String sourceType;

    @NotNull
    @Column(name = "food_id", nullable = false)
    private Integer foodId;

    @Size(max = 255)
    @Column(name = "orig_food_id")
    private String origFoodId;

    @Size(max = 255)
    @Column(name = "orig_food_common_name")
    private String origFoodCommonName;

    @Size(max = 255)
    @Column(name = "orig_food_scientific_name")
    private String origFoodScientificName;

    @Size(max = 255)
    @Column(name = "orig_food_part")
    private String origFoodPart;

    @Size(max = 255)
    @Column(name = "orig_source_id")
    private String origSourceId;

    @Size(max = 255)
    @Column(name = "orig_source_name")
    private String origSourceName;

    @Column(name = "orig_content", precision = 15, scale = 9)
    private BigDecimal origContent;

    @Column(name = "orig_min", precision = 15, scale = 9)
    private BigDecimal origMin;

    @Column(name = "orig_max", precision = 15, scale = 9)
    private BigDecimal origMax;

    @Size(max = 255)
    @Column(name = "orig_unit")
    private String origUnit;

    @Lob
    @Column(name = "orig_citation")
    private String origCitation;

    @NotNull
    @Lob
    @Column(name = "citation", nullable = false)
    private String citation;

    @Size(max = 255)
    @NotNull
    @Column(name = "citation_type", nullable = false)
    private String citationType;

    @Column(name = "creator_id")
    private Integer creatorId;

    @Column(name = "updater_id")
    private Integer updaterId;

    @Column(name = "created_at")
    private Instant createdAt;

    @Column(name = "updated_at")
    private Instant updatedAt;

    @Size(max = 255)
    @Column(name = "orig_method")
    private String origMethod;

    @Size(max = 255)
    @Column(name = "orig_unit_expression")
    private String origUnitExpression;

    @Column(name = "standard_content", precision = 15, scale = 9)
    private BigDecimal standardContent;

    @Size(max = 255)
    @Column(name = "preparation_type")
    private String preparationType;

    @Column(name = "export")
    private Byte export;

}