import { IGenericMacroDataChart } from "../../types";
import {
  ColorScalePropType,
  VictoryBar,
  VictoryChart,
  VictoryStack,
  VictoryTheme,
} from "victory";

export function MacroChart(props: {
  data: IGenericMacroDataChart[];
  color: ColorScalePropType | undefined;
}) {
  return (
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
  );
}
