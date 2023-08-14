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
    <li className="flex items-center justify-between rounded-full border bg-pine_green-100 py-1 pl-3 text-xs font-medium leading-none text-gray-800">
      <div className="flex items-center justify-center gap-4 p-1 text-xl font-light">
        <span>{props.item.FoodName}:</span>
        <span>{props.item.Quantity}gr.</span>
      </div>
      <div className="flex items-center justify-between">
        <EditFoodRequestItemButton onClick={props.onClick} />
        <DeleteFoodRequestItemButton onClick={props.onClick1} />
      </div>
    </li>
  );
}
