import { INorwegianFoodResponse } from "../../Model";

export function NutrientTable(props: { meals: INorwegianFoodResponse }) {
  return (
    <div>
      <table className="w-full">
        <thead className="sticky top-0 h-10 bg-pine_green-900">
          <tr className="font-semibold uppercase tracking-wide text-marian_blue-100">
            <th>Property</th>
            <th>Value</th>
          </tr>
        </thead>
        <tbody>
          {Object.entries<any>(props.meals).map(([key, value]) => (
            <tr
              key={key}
              className="border-t border-pine_green-600 text-center text-gray-400"
            >
              <td>{key}</td>
              <td>{value}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}
