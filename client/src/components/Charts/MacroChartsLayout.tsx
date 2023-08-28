import { useQuery } from "@tanstack/react-query";
import { useEffect, useState } from "react";
import { GetMacrosAndEnergy } from "../../FetchFunctions/Axios";
import { queryClient } from "../../main.tsx";
import { IGenericMacroDataChart, UserIdResponse } from "../../Model";
import { Loading } from "../Loading";
import { SingleMacroChart } from "./SingleMacroChart.tsx";

export function MacroChartsLayout(props: { trigger: boolean }) {
  const [isDataNotUndefined, setIsDataNotUndefined] = useState(false);
  const {
    data: mealData,
    isError,
    isFetching,
    refetch: refreshFoodChartData,
  } = useQuery(["meal-macros-data"], () => GetMacrosAndEnergy(user?.userId));

  const user: UserIdResponse | undefined = queryClient.getQueryData([
    "user-id",
  ]);

  useEffect(() => {
    if (mealData === undefined) setIsDataNotUndefined(true);
  }, [mealData]);

  useEffect(() => {
    refreshFoodChartData();
  }, [props.trigger]);

  const genericEnergyData: IGenericMacroDataChart[] | undefined =
    mealData?.energyDtos.map((item) => ({
      createdAt: item.createdAt,
      value: item.kilokalorierKcal,
    }));

  const genericCarbData: IGenericMacroDataChart[] | undefined =
    mealData?.carbDtos.map((item) => ({
      createdAt: item.createdAt,
      value: item.karbohydrat,
    }));

  const genericFatData: IGenericMacroDataChart[] | undefined =
    mealData?.fatDtos.map((item) => ({
      createdAt: item.createdAt,
      value: item.fett,
    }));

  const genericProteinData: IGenericMacroDataChart[] | undefined =
    mealData?.proteinDtos.map((item) => ({
      createdAt: item.createdAt,
      value: item.protein,
    }));

  if (isFetching) return <Loading />;

  if (isError) {
    alert("Error to get data, try again.");
  }

  return (
    <div>
      <div className="grid grid-cols-2 gap-2">
        {isDataNotUndefined && (
          <SingleMacroChart
            name="Energy in Kcal"
            color="warm"
            data={genericEnergyData}
          />
        )}
        {isDataNotUndefined && (
          <SingleMacroChart
            name="Carbs in grams"
            color="heatmap"
            data={genericCarbData}
          />
        )}
        {isDataNotUndefined && (
          <SingleMacroChart
            name="Fats in grams"
            color="qualitative"
            data={genericFatData}
          />
        )}
        {isDataNotUndefined && (
          <SingleMacroChart
            name="Protein in grams"
            color="red"
            data={genericProteinData}
          />
        )}
      </div>
    </div>
  );
}
