package com.api.server.mappers;

import com.api.server.entities.FoodProduct;
import com.api.server.model.response.FoodProductResponse;
import org.mapstruct.Mapper;

import java.util.List;

@Mapper
public interface FoodProductMapper {
    List<FoodProductResponse> listFoodProductToFoodProductsDto(List<FoodProduct> foodProduct);
}
