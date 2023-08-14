import React from "react";

export function SingleFoodForm(props: {
  foodProp: string;
  setFoodInputCB: (e: React.ChangeEvent<HTMLInputElement>) => void;
  quantityProp: string;
  setQuantityInputCB: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onClick: () => void;
}) {
  return (
    <div className="grid gap-2 bg-white p-10">
      <h1>Intro Food Name and Quantity</h1>
      <input
        id="price"
        type="text"
        name="food"
        value={props.foodProp}
        placeholder="food"
        onChange={props.setFoodInputCB}
        className="w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
      />

      <input
        id="price"
        type="text"
        name="price"
        value={props.quantityProp}
        placeholder="quantity"
        onChange={props.setQuantityInputCB}
        className="mt-2 w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
      />

      <button
        onClick={props.onClick}
        className="group relative m-auto flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out hover:scale-110"
      >
        <span className="text-m relative text-white">Submit</span>
      </button>
    </div>
  );
}
