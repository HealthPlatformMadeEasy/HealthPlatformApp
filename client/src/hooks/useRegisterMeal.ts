import { FoodRequest } from "../Model";
import { useQuery } from "@tanstack/react-query";
import { registerMeal } from "../FetchFunctions/Axios";

export function useRegisterMeal(request: FoodRequest | undefined) {
  return useQuery(["meal"], () => registerMeal(request), {
    enabled: false,
    retry: false,
  });
}
