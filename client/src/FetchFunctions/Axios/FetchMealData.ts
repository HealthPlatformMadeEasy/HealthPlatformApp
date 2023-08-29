import axios from "axios";
import {
  FoodRequest,
  IEnergyAndMacros,
  INorwegianFoodResponse,
} from "../../Model";

export async function GetMacros(
  id: string | undefined,
): Promise<IEnergyAndMacros> {
  const { data } = await axios.get(
    `${import.meta.env.VITE_BASE_URL}/api/nutrients/energy-macros/${id}`,
    {
      headers: {
        Accept: "application/json",
      },
    },
  );
  return data;
}

export const registerMeal = async (
  request: FoodRequest | undefined,
): Promise<INorwegianFoodResponse> => {
  const r = await axios.post<INorwegianFoodResponse>(
    `${
      import.meta.env.VITE_BASE_URL
    }/api/norwegianfoods/getnutrientcalculationforuser`,
    request,
    { headers: { "Content-Type": "application/json" } },
  );
  return r.data;
};
