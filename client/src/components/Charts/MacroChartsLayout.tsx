import { useEffect, useState } from "react";
import { GetMacrosAndEnergy } from "../../context/Axios";
import { useUserId } from "../../hooks";
import { IEnergyAndMacros, IGenericMacroDataChart } from "../../Model";
import { SingleMacroChart } from "./SingleMacroChart.tsx";

export function MacroChartsLayout(props: { trigger: boolean }) {
  const [data, setData] = useState<IEnergyAndMacros>({
    energyDtos: [],
    carbDtos: [],
    fatDtos: [],
    proteinDtos: [],
  });
  const [isDataNotUndefined, setIsDataNotUndefined] = useState(false);
  const { userId } = useUserId();

  useEffect(() => {
    if (
      data.carbDtos.length !== 0 &&
      data.energyDtos.length !== 0 &&
      data.fatDtos.length !== 0 &&
      data.proteinDtos.length !== 0
    )
      setIsDataNotUndefined(true);
  }, [data]);

  useEffect(() => {
    if (typeof userId === undefined) {
      return;
    }
    const getData = () => {
      GetMacrosAndEnergy(userId?.userId).then((data) => setData(data));
    };

    getData();
  }, [props.trigger, userId]);

  const genericEnergyData: IGenericMacroDataChart[] = data?.energyDtos.map(
    (item) => ({
      createdAt: item.createdAt,
      value: item.kilokalorierKcal,
    }),
  );

  const genericCarbData: IGenericMacroDataChart[] = data?.carbDtos.map(
    (item) => ({
      createdAt: item.createdAt,
      value: item.karbohydrat,
    }),
  );

  const genericFatData: IGenericMacroDataChart[] = data?.fatDtos.map(
    (item) => ({
      createdAt: item.createdAt,
      value: item.fett,
    }),
  );

  const genericProteinData: IGenericMacroDataChart[] = data?.proteinDtos.map(
    (item) => ({
      createdAt: item.createdAt,
      value: item.protein,
    }),
  );

  return (
    <div>
      {!isDataNotUndefined && (
        <div className="grid w-1/2 bg-white p-10">
          <h1 className="text-5xl font-extrabold text-pink-700">No Content</h1>
        </div>
      )}
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
            name="Carbs in gr"
            color="heatmap"
            data={genericCarbData}
          />
        )}
        {isDataNotUndefined && (
          <SingleMacroChart
            name="Fats in gr"
            color="qualitative"
            data={genericFatData}
          />
        )}
        {isDataNotUndefined && (
          <SingleMacroChart
            name="Protein in gr"
            color="red"
            data={genericProteinData}
          />
        )}
      </div>
    </div>
  );
}
