import { MacroChartsLayout, Meal } from "../components";
import { useState } from "react";

export function FoodPage() {
  const [triggerLoad, setTriggerLoad] = useState(false);

  function reLoadChart() {
    setTriggerLoad(!triggerLoad);
  }

  return (
    <main>
      <div className="grid grid-cols-3 gap-2 p-8">
        <div className="flex flex-col gap-2">
          <Meal loadChart={reLoadChart} />
        </div>
        <div className="col-span-2">
          <MacroChartsLayout trigger={triggerLoad} />
        </div>
      </div>
    </main>
  );
}
