package com.api.server.model.response;

public record FoodProductResponse(
        long id,
        String productCategory,
        String productName,
        String per100g,
        String productCalories) {
}
