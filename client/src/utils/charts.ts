import { IEnergyAndMacros, IGenericMacroDataChart } from "../Model";

export const groupAndCalculateTotalCalories = (
  elements: IGenericMacroDataChart[] | undefined,
): { value: number; createdAt: Date }[] | undefined => {
  const groupedElements: { [key: string]: number } = {};

  if (elements === undefined) return;

  if (elements?.length > 0) {
    elements?.forEach((element) => {
      const dateWithoutTime = element.createdAt.toString().slice(0, 10);

      if (groupedElements[dateWithoutTime]) {
        groupedElements[dateWithoutTime] += element.value;
      } else {
        groupedElements[dateWithoutTime] = element.value;
      }
    });

    return Object.entries(groupedElements).map(([date, totalCalories]) => ({
      value: totalCalories,
      createdAt: new Date(date),
    }));
  }
  return;
};

export function getGenericEnergyData(
  mealData: IEnergyAndMacros | undefined,
): IGenericMacroDataChart[] | undefined {
  return mealData?.energyDtos.map((item) => ({
    createdAt: item.createdAt,
    value: item.kilokalorierKcal,
  }));
}

export function getGenericCarbData(
  mealData: IEnergyAndMacros | undefined,
): IGenericMacroDataChart[] | undefined {
  return mealData?.carbDtos.map((item) => ({
    createdAt: item.createdAt,
    value: item.karbohydrat,
  }));
}

export function getGenericFatData(
  mealData: IEnergyAndMacros | undefined,
): IGenericMacroDataChart[] | undefined {
  return mealData?.fatDtos.map((item) => ({
    createdAt: item.createdAt,
    value: item.fett,
  }));
}

export function getGenericProteinData(
  mealData: IEnergyAndMacros | undefined,
): IGenericMacroDataChart[] | undefined {
  return mealData?.proteinDtos.map((item) => ({
    createdAt: item.createdAt,
    value: item.protein,
  }));
}
