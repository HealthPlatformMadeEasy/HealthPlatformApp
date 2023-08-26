import axios from "axios";
import {FoodRequest, IEnergyAndMacros, INorwegianFoodResponse,} from "../../Model";

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

// export async function GetMacrosAndEnergy1(id: string | undefined) {
//   const { data } = await axios
//     .get(`${import.meta.env.VITE_BASE_URL}/api/nutrients/energy-macros/${id}`, {
//       headers: {
//         Accept: "application/json",
//       },
//     })
//     .then((response: { data: string }) => response.data);
//   return data;
// }

export const pushFoodData = async (
    request: FoodRequest | undefined,
): Promise<INorwegianFoodResponse | undefined | string> => {
  const response = await axios.post<INorwegianFoodResponse>(
      `${
          import.meta.env.VITE_BASE_URL
      }/api/norwegianfoods/getnutrientcalculationforuser`,
      request,
      {headers: {"Content-Type": "application/json"}},
  );
  return response.data;
};
