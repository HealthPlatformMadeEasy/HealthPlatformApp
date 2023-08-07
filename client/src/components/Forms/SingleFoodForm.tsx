import React from "react";

export function SingleFoodForm(props: {
    foodProp: string,
    setFoodInputCB: (e: React.ChangeEvent<HTMLInputElement>) => void,
    quantityProp: string,
    setQuantityInputCB: (e: React.ChangeEvent<HTMLInputElement>) => void,
    onClick: () => void
}) {

    return <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
        <h1>Intro Food Name and Quantity</h1>
        <input
            id="price"
            type="text"
            name="food"
            value={props.foodProp}
            placeholder="food"
            onChange={props.setFoodInputCB}
            className="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-gray-900 ring-1 ring-inset ring-blue-300 placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6 my-3"
        />

        <input
            id="price"
            type="text"
            name="price"
            value={props.quantityProp}
            placeholder="quantity"
            onChange={props.setQuantityInputCB}
            className="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-grey-900 ring-1 ring-inset ring-blue-300 placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
        />

        <button
            onClick={props.onClick}
            className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
        >Submit
        </button>
    </div>;
}
