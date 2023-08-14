import { CalorieCalculator, MacroChartsLayout, Meal } from "../components";
import { useUserId } from "../hooks";
import { useState } from "react";

export function FoodPage() {
  const { userId } = useUserId();
  const [triggerLoad, setTriggerLoad] = useState(false);

  function reLoadChart() {
    setTriggerLoad(!triggerLoad);
  }

  return (
    <main>
      <h1>{userId?.userId}</h1>
      <button onClick={() => setTriggerLoad(!triggerLoad)}>reload</button>
      <div className="grid grid-cols-3 gap-2 bg-light-green-fruit-around bg-cover bg-fixed p-8">
        <div className="flex flex-col gap-2">
          <CalorieCalculator />
          <Meal loadChart={reLoadChart} />
        </div>
        <div className="col-span-2">
          <MacroChartsLayout trigger={triggerLoad} />
        </div>
      </div>
    </main>
  );
}
