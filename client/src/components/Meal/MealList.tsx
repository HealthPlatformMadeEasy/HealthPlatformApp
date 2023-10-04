import { FoodItem } from "../../Model";
import { PencilIcon, TrashIcon } from "@heroicons/react/24/outline";
import React from "react";
import Modal from "react-modal";

export function MealList(props: {
  FoodItems: FoodItem[];
  ShowData: boolean;
  HandleEdit: (item: FoodItem) => void;
  HandleDelete: (id: number) => void;
  open: boolean;
  onRequestClose: () => void;
  onSubmit: (e: React.FormEvent) => void;
  form: { Quantity: number; FoodName: string };
  onChangeFoodName: (e: React.ChangeEvent<HTMLInputElement>) => void;
  onChangeQuantity: (e: React.ChangeEvent<HTMLInputElement>) => void;
}) {
  Modal.setAppElement("#root");

  return (
    <>
      <ul className="mt-8 w-full space-y-4">
        {props.FoodItems.map((item) => (
          <li
            key={item.FoodName}
            className="flex justify-between gap-4 border-b border-pine_green-100 p-1"
          >
            <div className="flex w-full items-center justify-between px-2 text-xl font-light leading-none text-gray-400">
              <div>{item.FoodName}:</div>
              <div>{item.Quantity}g.</div>
            </div>
            <div className="flex items-center justify-between">
              {!props.ShowData && (
                <div className="grid grid-cols-2 gap-4">
                  <button
                    onClick={() => props.HandleEdit(item)}
                    className="group mx-1 flex h-9 w-9 transform items-center justify-center rounded-full bg-hunyadi_yellow transition duration-300 ease-in-out hover:scale-125"
                  >
                    <PencilIcon className="h-5 w-5 text-pine_green-900" />
                  </button>
                  <button
                    onClick={() => props.HandleDelete(item.id)}
                    className="group mx-1 flex h-9  w-9 transform items-center justify-center rounded-full bg-madder transition duration-300 ease-in-out hover:scale-125"
                  >
                    <TrashIcon className="h-5 w-5 text-white" />
                  </button>
                </div>
              )}
            </div>
          </li>
        ))}
      </ul>
      <Modal
        isOpen={props.open}
        onRequestClose={props.onRequestClose}
        style={{
          overlay: {
            backgroundColor: "rgba(0, 0, 0, 0.5)",
          },
          content: {
            color: "white",
            top: "50%",
            left: "50%",
            right: "auto",
            bottom: "auto",
            marginRight: "-50%",
            transform: "translate(-50%, -50%)",
            backgroundColor: "#041613",
            borderRadius: "0.75rem", // 6px
            padding: "2rem", // 32px
          },
        }}
      >
        <h2 className="mb-4 font-playfair text-3xl font-bold">
          Update Food Item
        </h2>
        <form onSubmit={props.onSubmit} className="grid grid-cols-2 gap-2">
          <div>
            <label
              id="UserName"
              className="text-sm font-medium leading-none text-gray-400"
            >
              Food
            </label>
            <input
              disabled={true}
              type="text"
              required
              aria-labelledby="userName"
              value={props.form.FoodName}
              onChange={props.onChangeFoodName}
              className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
            />
          </div>
          <div>
            <label
              id="UserName"
              className="text-sm font-medium leading-none text-gray-400"
            >
              Quantity in grams
            </label>
            <input
              type="number"
              required
              value={props.form.Quantity}
              aria-labelledby="userName"
              onChange={props.onChangeQuantity}
              className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
            />
          </div>
          <div className="col-span-2 mt-6 flex justify-end gap-8">
            <button
              onClick={props.onRequestClose}
              className="group flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-madder px-6 transition duration-300 ease-in-out hover:scale-125"
            >
              <span className="font-semibold text-white">Cancel</span>
            </button>
            <button
              type="submit"
              className="group flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-marian_blue px-6 transition duration-300 ease-in-out hover:scale-125"
            >
              <span className="font-semibold text-white ">Update</span>
            </button>
          </div>
        </form>
      </Modal>
    </>
  );
}
