import { IGenericMacroDataChart } from "../../Model";
import {
  ColorScalePropType,
  VictoryArea,
  VictoryAxis,
  VictoryChart,
  VictoryStack,
  VictoryTheme,
} from "victory";

export function SingleMacroChart(props: {
  name: string;
  data: IGenericMacroDataChart[];
  color: ColorScalePropType | undefined;
}) {
  return (
    <div className="bg-white p-8">
      <h1 className="text-2xl font-extrabold text-pink-700">{props.name}</h1>
      <VictoryChart name="Energy" theme={VictoryTheme.material}>
        <VictoryStack>
          <VictoryArea
            name="carbs"
            colorScale={props.color}
            data={props.data.map((row) => {
              return { x: row.createdAt, y: row.value };
            })}
            interpolation="linear"
          />
          <VictoryAxis
            tickValues={props.data.map((row) => row.createdAt)}
            tickFormat={props.data.map((row) => {
              const date = new Date(row.createdAt);
              const day = date.getDate();
              const month = date.getMonth() + 1;
              return `${day}/${month}`;
            })}
          />
          <VictoryAxis dependentAxis tickFormat={(y) => `${y}`} />
        </VictoryStack>
      </VictoryChart>
    </div>
  );
}
