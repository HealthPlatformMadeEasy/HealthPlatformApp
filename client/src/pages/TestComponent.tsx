import { useState } from "react";

export function TestComponent() {
  const [meal, setMeal] = useState("");
  const [mealDate, setMealDate] = useState<Date>(new Date(Date.now()));

  const handleSubmit = () => {
    if (meal === "breakfast") {
      mealDate.setUTCHours(9, 0, 0);
    }
  };

  return (
    <div>
      <form onSubmit={handleSubmit}>
        <label>Meal Date</label>
        <input
          type="date"
          value={mealDate.valueOf()}
          onChange={(e) => setMealDate(new Date(Number(e.target.value)))}
          className="form-input text-black"
        />

        <label>Meal</label>
        <select
          name="Meal"
          value={meal}
          required={true}
          onChange={(e) => setMeal(e.target.value)}
          className="form-select text-black"
        >
          <option value="Breakfast">Breakfast</option>
          <option value="Launch">Launch</option>
        </select>

        <button type="submit">Button</button>
      </form>
    </div>
  );
}
