package com.api.server.entities;

import com.api.server.utils.StringToLongDeserializer;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import lombok.*;

@Getter
@Setter
@NoArgsConstructor
@AllArgsConstructor
@Builder
@Entity
public class FoodProduct {
    @Id
    @Column(length = 70, updatable = false, nullable = false)
    private String foodItem;

    @Column(length = 50, nullable = false)
    private String  foodCategory;

    @JsonDeserialize(using = StringToLongDeserializer.class)
    @Column(length = 50, nullable = false)
    private Long calsPer100grams;

}
