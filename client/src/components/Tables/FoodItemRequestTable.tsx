import { FoodItem } from "../../types";
import {
  DeleteFoodRequestItemButton,
  EditFoodRequestItemButton,
} from "../Buttons";

export function FoodItemRequestRow(props: {
  item: FoodItem;
  onClick: () => void;
  onClick1: () => void;
}) {
  return (
    <li className="flex items-center justify-between space-x-4 rounded-md bg-gray-100 p-4">
      <div>
        <span className="text-lg font-bold">{props.item.FoodName}</span>
        <span className="ml-6">{props.item.Quantity}</span>
      </div>
      <div className="flex items-center justify-between">
        <EditFoodRequestItemButton onClick={props.onClick} />
        <DeleteFoodRequestItemButton onClick={props.onClick1} />
      </div>
    </li>
  );
}
