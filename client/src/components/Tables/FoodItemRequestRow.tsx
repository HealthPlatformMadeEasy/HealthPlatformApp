import { FoodItem } from "../../Model";
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
    <li className="flex justify-between gap-4 border-b border-pine_green-100 p-1">
      <div className="flex w-full items-center justify-between py-1 pl-3 text-xl font-light leading-none text-gray-400">
        <div>{props.item.FoodName}:</div>
        <div>{props.item.Quantity}gr.</div>
      </div>
      <div className="flex items-center justify-between">
        <EditFoodRequestItemButton onClick={props.onClick} />
        <DeleteFoodRequestItemButton onClick={props.onClick1} />
      </div>
    </li>
  );
}
