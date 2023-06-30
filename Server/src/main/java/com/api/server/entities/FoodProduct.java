package com.api.server.entities;

import com.api.server.utils.StringToLongDeserializer;
import com.fasterxml.jackson.databind.annotation.JsonDeserialize;
import jakarta.persistence.Column;
import jakarta.persistence.Entity;
import jakarta.persistence.Id;
import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.PositiveOrZero;
import jakarta.validation.constraints.Size;
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
    @NotNull
    @NotBlank
    @Size( max = 70)
    private String foodItem;

    @Column(length = 50, nullable = false)
    @NotNull
    @NotBlank
    @Size( max = 50)
    private String  foodCategory;

    @JsonDeserialize(using = StringToLongDeserializer.class)
    @Column(nullable = false)
    @NotNull
    @PositiveOrZero
    private Long calsPer100grams;

}
