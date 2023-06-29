package com.api.server.mappers;

import com.api.server.entities.FoodProduct;
import com.api.server.model.FoodProductResponse;
import org.mapstruct.Mapper;

import java.util.List;

@Mapper
public interface FoodProductMapper {
    FoodProductResponse foodProductToFoodProductDto(FoodProduct foodProduct);

    List<FoodProductResponse> listFoodProductToFoodProductsDto(List<FoodProduct> foodProduct);

}
