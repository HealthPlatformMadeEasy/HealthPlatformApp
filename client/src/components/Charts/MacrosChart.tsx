import { IGenericMacroDataChart } from "../../types";
import {
  ColorScalePropType,
  VictoryBar,
  VictoryChart,
  VictoryStack,
  VictoryTheme,
} from "victory";

export function MacroChart(props: {
  name: string;
  data: IGenericMacroDataChart[];
  color: ColorScalePropType | undefined;
}) {
  return (
    <div className="bg-white p-8">
      <h1 className="text-2xl font-extrabold text-pink-700">{props.name}</h1>
      <VictoryChart name="Energy" theme={VictoryTheme.material}>
        <VictoryStack>
          <VictoryBar
            name="carbs"
            colorScale={props.color}
            data={props.data.map((row) => {
              return { x: row.createdAt, y: row.value };
            })}
          />
        </VictoryStack>
      </VictoryChart>
    </div>
  );
}
