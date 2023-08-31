import { Calendar } from "../components/Charts/Calendar.tsx";
import { Tabs } from "../components/Calendar/TabTest.tsx";
import { IGenericMacroDataChart } from "../Model";

const priceData: IGenericMacroDataChart[] = [
  { createdAt: new Date("2023-08-13"), value: 90 },
  { createdAt: new Date("2023-08-14"), value: 150 },
  { createdAt: new Date("2023-08-15"), value: 105 },
];

export function TestPage() {
  return (
    <div>
      <Calendar priceData={priceData} goal={100} />
      <Tabs />
    </div>
  );
}
