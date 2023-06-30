package com.api.server.entities;

import com.api.server.utils.StringToLongDeserializer;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
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
    private String foodItem;
    private String  foodCategory;
    @JsonDeserialize(using = StringToLongDeserializer.class)
    private Long calsPer100grams;

}
