package com.api.server.model.request;

import jakarta.validation.constraints.NotBlank;
import jakarta.validation.constraints.NotNull;
import jakarta.validation.constraints.Positive;
import jakarta.validation.constraints.Size;

public record CaloricCalculationRequest(
        @NotNull
        @NotBlank
        @Size( max = 70)
        String food,
        @Positive
        long quantityInGrams){}
