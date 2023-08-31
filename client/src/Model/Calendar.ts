import { IGenericMacroDataChart } from "./ChartData.ts";

export type CalendarProps = {
  priceData: IGenericMacroDataChart[] | undefined;
  goal: number;
  unit: string;
};

export interface IDay {
  date: Date;
  value: number | null;
}
