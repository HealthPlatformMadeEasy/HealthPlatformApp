package com.api.server.model.response;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Positive;
import jakarta.validation.constraints.Size;

public record FoodProductResponse(
        @NotNull
        @NotBlank
        @Size( max = 70)
        String foodItem,
        @NotNull
        @NotBlank
        @Size( max = 50)
        String foodCategory,
        @Positive
        long calsPer100grams) {
}
