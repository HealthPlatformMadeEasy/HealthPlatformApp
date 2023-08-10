import { useEffect, useState } from "react";
import { GetMacrosAndEnergy } from "../../context/Fetch";
import { useUserId } from "../../hooks";
import { IEnergyAndMacros, IGenericMacroDataChart } from "../../types";
import { MacroChart } from "./MacrosChart.tsx";

export function UserContentCharts() {
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
  }, [userId]);

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
    <>
      <p>userId: {userId?.userId}</p>

      {!isDataNotUndefined && (
        <div className="m-auto my-16 grid w-1/2 rounded-xl border border-solid border-blue-800 p-10">
          <h1 className="text-5xl font-extrabold text-pink-700">No Content</h1>
        </div>
      )}
      {isDataNotUndefined && (
        <>
          <h1 className="text-2xl font-extrabold text-pink-700">Energy</h1>
          <MacroChart color={"warm"} data={genericEnergyData} />
        </>
      )}
      {isDataNotUndefined && (
        <>
          <h1 className="text-2xl font-extrabold text-pink-700">Carbs</h1>
          <MacroChart color={"heatmap"} data={genericCarbData} />
        </>
      )}
      {isDataNotUndefined && (
        <>
          <h1 className="text-2xl font-extrabold text-pink-700">Fats</h1>
          <MacroChart color={"qualitative"} data={genericFatData} />
        </>
      )}
      {isDataNotUndefined && (
        <>
          <h1 className="text-2xl font-extrabold text-pink-700">Protein</h1>
          <MacroChart color={"red"} data={genericProteinData} />
        </>
      )}
    </>
  );
}
