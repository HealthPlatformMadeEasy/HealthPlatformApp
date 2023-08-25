import { useEffect, useState } from "react";
import { GetMacrosAndEnergy } from "../../context/Axios";
import { useUserId } from "../../hooks";
import {
  IEnergyAndMacros,
  IGenericMacroDataChart,
  UserIdResponse,
} from "../../Model";
import { SingleMacroChart } from "./SingleMacroChart.tsx";
import { Loading } from "../Loading";
import { queryClient } from "../../main.tsx";

export function MacroChartsLayout(props: { trigger: boolean }) {
  const [data, setData] = useState<IEnergyAndMacros>({
    energyDtos: [],
    carbDtos: [],
    fatDtos: [],
    proteinDtos: [],
  });
  const [isDataNotUndefined, setIsDataNotUndefined] = useState(false);
  const { userId } = useUserId();
  const [loading, setLoading] = useState(true);

  const user: UserIdResponse | undefined = queryClient.getQueryData([
    "user-id",
  ]);

  console.log(JSON.stringify(user));

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
    if (typeof userId === "undefined") {
      return;
    }
    const getData = () => {
      GetMacrosAndEnergy(user?.userId).then((data) => {
        setData(data);
        setLoading(false);
      });
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

  if (loading) return <Loading />;

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
