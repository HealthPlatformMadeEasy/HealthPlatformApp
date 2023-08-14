import {
  CalorieCalculator,
  ListOfFoods,
  MacroChartsLayout,
} from "../components";
import { useUserId } from "../hooks";
import { useState } from "react";

export function UserHomePage() {
  const { userId } = useUserId();
  const [triggerLoad, setTriggerLoad] = useState(false);

  return (
    <main>
      <h1>{userId?.userId}</h1>
      <button onClick={() => setTriggerLoad(!triggerLoad)}>reload</button>
      <div className="grid grid-cols-3 gap-2 bg-light-green-fruit-around bg-cover bg-fixed p-8">
        <div className="flex flex-col gap-2">
          <CalorieCalculator />
          <ListOfFoods />
        </div>
        <div className="col-span-2">
          <MacroChartsLayout trigger={triggerLoad} />
        </div>
      </div>
    </main>
  );
}
