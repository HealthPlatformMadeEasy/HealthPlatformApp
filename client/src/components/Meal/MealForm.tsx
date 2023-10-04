import React from "react";
import { PlusIcon } from "@heroicons/react/24/outline";
import Fuse from "fuse.js";

export function MealFrom(props: {
  onSubmit: (e: React.FormEvent) => void;
  disabled: boolean;
  form: { Quantity: number; FoodName: string };
  onChangeFoodName: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onChangeQuantity: (e: React.ChangeEvent<HTMLInputElement>) => void;
  SetFormProps: (name: { FoodName: string; Quantity: number }) => void;
  Results: Fuse.FuseResult<{ title: string }>[];
  SetShowSearchItems: () => void;
  showSearchItems: boolean;
}) {
  return (
    <form
      onSubmit={props.onSubmit}
      className="flex w-full items-center justify-center sm:space-x-2"
    >
      <div className="flex flex-col items-center justify-evenly gap-6 lg:flex-row">
        <div className="relative w-full">
          <div>
            <label
              id="UserName"
              className="text-sm font-medium leading-none text-gray-400"
            >
              Search
            </label>
            <input
              type="text"
              required
              disabled={props.disabled}
              aria-labelledby="userName"
              value={props.form.FoodName}
              onChange={props.onChangeFoodName}
              className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
            />
          </div>
          {props.showSearchItems && (
            <ul className="absolute z-50 my-2 max-h-60 w-full overflow-auto rounded border-2 border-pine_green-600 bg-pine_green-800 p-2 text-gray-300">
              {props.Results.map((result) => (
                <button
                  type="button"
                  key={result.item.title}
                  onClick={() => {
                    props.SetFormProps({
                      ...props.form,
                      FoodName: result.item.title,
                    });
                    props.SetShowSearchItems();
                  }}
                  className="m-1 w-full text-left hover:cursor-pointer"
                >
                  {result.item.title}
                </button>
              ))}
            </ul>
          )}
        </div>
        <div className="w-full">
          <label
            id="UserName"
            className="text-sm font-medium leading-none text-gray-400"
          >
            Quantity in grams
          </label>
          <input
            type="number"
            required
            disabled={props.disabled}
            value={props.form.Quantity}
            aria-labelledby="userName"
            onChange={props.onChangeQuantity}
            className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
          />
        </div>
        <div>
          <button
            type="submit"
            className="group mt-3 flex h-9 w-9 transform items-center justify-center rounded-full bg-marian_blue transition duration-300 ease-in-out hover:scale-125"
          >
            <PlusIcon className="h-6 w-6 text-white" />
          </button>
        </div>
      </div>
    </form>
  );
}
