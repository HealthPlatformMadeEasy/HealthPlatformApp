import React from "react";

export function SingleFoodForm(props: {
  foodProp: string;
  setFoodInputCB: (e: React.ChangeEvent<HTMLInputElement>) => void;
  quantityProp: string;
  setQuantityInputCB: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onClick: () => void;
}) {
  return (
    <div className="m-auto my-16 grid w-1/3 rounded-xl border border-solid border-blue-800 p-10">
      <h1>Intro Food Name and Quantity</h1>
      <input
        id="price"
        type="text"
        name="food"
        value={props.foodProp}
        placeholder="food"
        onChange={props.setFoodInputCB}
        className="my-3 block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-gray-900 ring-1 ring-inset ring-blue-300
        placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
      />

      <input
        id="price"
        type="text"
        name="price"
        value={props.quantityProp}
        placeholder="quantity"
        onChange={props.setQuantityInputCB}
        className="text-grey-900 block w-full rounded-md border-0 py-1.5 pl-7 pr-20 ring-1 ring-inset ring-blue-300
        placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
      />

      <button
        onClick={props.onClick}
        className="mt-5 rounded border border-blue-500 bg-transparent px-4 py-2 font-semibold text-blue-700
        hover:border-transparent hover:bg-blue-500 hover:text-white"
      >
        Submit
      </button>
    </div>
  );
}
