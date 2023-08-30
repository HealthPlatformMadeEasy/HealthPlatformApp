import { useEffect, useState } from "react";
import { queryClient } from "../../main.tsx";
import { IGenericMacroDataChart, UserIdResponse } from "../../Model";
import { Loading } from "../Loading";
import { useGetMacros } from "../../hooks";
import {
  getGenericCarbData,
  getGenericEnergyData,
  getGenericFatData,
  getGenericProteinData,
  groupAndCalculateTotalCalories,
} from "../../utils";
import { SingleMacroChart } from "./SingleMacroChart.tsx";

function MacroDataCharts(props: {
  energy: IGenericMacroDataChart[] | undefined;
  carbs: IGenericMacroDataChart[] | undefined;
  fats: IGenericMacroDataChart[] | undefined;
  protein: IGenericMacroDataChart[] | undefined;
}) {
  return (
    <div className="grid grid-cols-2 gap-2">
      <SingleMacroChart
        name="Energy in Kcal"
        color="warm"
        data={props.energy}
      />
      <SingleMacroChart
        name="Carbs in grams"
        color="heatmap"
        data={props.carbs}
      />
      <SingleMacroChart
        name="Fats in grams"
        color="qualitative"
        data={props.fats}
      />
      <SingleMacroChart
        name="Protein in grams"
        color="red"
        data={props.protein}
      />
    </div>
  );
}

export function MacroChartsLayout(props: { trigger: boolean }) {
  const [activeTab, setActiveTab] = useState(0);
  const user: UserIdResponse | undefined = queryClient.getQueryData([
    "user-id",
  ]);
  const {
    data: mealData,
    isError,
    isFetching,
    refetch: refreshFoodChartData,
  } = useGetMacros(user?.userId);

  useEffect(() => {
    refreshFoodChartData().then();
  }, [props.trigger]);

  const handleTabClick = (index: number) => {
    setActiveTab(index);
  };

  const genericEnergyData = getGenericEnergyData(mealData);

  const genericCarbData = getGenericCarbData(mealData);

  const genericFatData = getGenericFatData(mealData);

  const genericProteinData = getGenericProteinData(mealData);

  const dailyEnergyData = groupAndCalculateTotalCalories(genericEnergyData);

  const dailyCarbsData = groupAndCalculateTotalCalories(genericCarbData);

  const dailyFatsData = groupAndCalculateTotalCalories(genericFatData);

  const dailyProteinData = groupAndCalculateTotalCalories(genericProteinData);

  if (isFetching) return <Loading />;

  if (isError) {
    alert("Error to get data, try again.");
  }

  const tabs = [
    {
      label: "Daily",
      content: (
        <MacroDataCharts
          energy={dailyEnergyData}
          carbs={dailyCarbsData}
          fats={dailyFatsData}
          protein={dailyProteinData}
        />
      ),
    },
    {
      label: "Single",
      content: (
        <MacroDataCharts
          energy={genericEnergyData}
          carbs={genericCarbData}
          fats={genericFatData}
          protein={genericProteinData}
        />
      ),
    },
  ];

  return (
    <div className="tabs grid rounded-xl border-2 border-pine_green-600 bg-pine_green-900 p-2">
      <div className="tab-list flex gap-4 pb-2">
        {tabs.map((tab, index) => (
          <div
            key={index}
            onClick={() => handleTabClick(index)}
            className={`tab ${
              index === activeTab
                ? "active rounded-xl border-2 border-pine_green-600 bg-pine_green-800 px-6 py-2"
                : "px-6 py-2"
            }`}
          >
            {tab.label}
          </div>
        ))}
      </div>
      <div className="tab-content">{tabs[activeTab].content}</div>
    </div>
  );
}
