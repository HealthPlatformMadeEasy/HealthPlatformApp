import { MacroChartsLayout, Meal } from "../components";
import { useState } from "react";

export function FoodPage() {
  const [triggerLoad, setTriggerLoad] = useState(false);

  function reLoadChart() {
    setTriggerLoad(!triggerLoad);
  }

  return (
    <div className="grid gap-2 bg-pine_green-800 p-2 lg:grid-cols-3">
      <div className="lg:grid-cols-1">
        <Meal loadChart={reLoadChart} />
      </div>
      <div className="lg:col-span-2">
        <MacroChartsLayout trigger={triggerLoad} />
      </div>
    </div>
  );
}
