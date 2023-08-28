import axios from "axios";
import {
  FoodRequest,
  IEnergyAndMacros,
  INorwegianFoodResponse,
} from "../../Model";

export async function GetMacrosAndEnergy(
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

export const pushFoodData = (
  request: FoodRequest | undefined,
): Promise<INorwegianFoodResponse> => {
  return axios
    .post<INorwegianFoodResponse>(
      `${
        import.meta.env.VITE_BASE_URL
      }/api/norwegianfoods/getnutrientcalculationforuser`,
      request,
      { headers: { "Content-Type": "application/json" } },
    )
    .then((r) => r.data);
};
