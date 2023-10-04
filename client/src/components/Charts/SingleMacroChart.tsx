import {
  ColorScalePropType,
  VictoryAxis,
  VictoryBar,
  VictoryChart,
  VictoryStack,
  VictoryTheme,
} from "victory";
import { IGenericMacroDataChart } from "../../Model";

export function SingleMacroChart(props: {
  name: string;
  data: IGenericMacroDataChart[] | undefined;
  color: ColorScalePropType | undefined;
}) {
  return (
    <div className="rounded-xl border-2 border-pine_green-600 bg-pine_green-900 p-1 lg:p-8">
      <h1 className="text-center font-playfair text-pine_green-200 lg:text-3xl">
        {props.name}
      </h1>
      <VictoryChart name="Energy" theme={VictoryTheme.material}>
        <VictoryStack>
          <VictoryBar
            name="carbs"
            colorScale={props.color}
            barWidth={12}
            data={props.data?.map((row) => {
              return { x: row.createdAt, y: row.value };
            })}
          />
          <VictoryAxis
            tickValues={props.data?.map((row) => row.createdAt)}
            tickFormat={props.data?.map((row) => {
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
