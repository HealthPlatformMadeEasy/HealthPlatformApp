import { MacroChartsLayout, Meal } from "../components";
import { useState } from "react";

export function FoodPage() {
  const [triggerLoad, setTriggerLoad] = useState(false);

  function reLoadChart() {
    setTriggerLoad(!triggerLoad);
  }

  return (
    <div className="grid min-h-[420px] grid-cols-3 gap-2 bg-pine_green-800 p-2">
      <div className="flex flex-col gap-2">
        <Meal loadChart={reLoadChart} />
      </div>
      <div className="col-span-2">
        <MacroChartsLayout trigger={triggerLoad} />
      </div>
    </div>
  );
}
