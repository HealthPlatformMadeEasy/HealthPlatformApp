package com.api.server.model.response;

import jakarta.validation.constraints.PositiveOrZero;

public record CaloricResponse(
        @PositiveOrZero
        long totalCalories) {
}
