import { PencilIcon, PlusIcon, TrashIcon } from "@heroicons/react/24/outline";

export function AddButton() {
  return (
    <button
      type="submit"
      className="group flex h-9 w-9 transform items-center justify-center rounded-full border-2 border-celestial_blue transition duration-300 ease-in-out hover:scale-125 hover:bg-celestial_blue"
    >
      <PlusIcon className="h-6 w-6 text-celestial_blue group-hover:text-pine_green-900" />
    </button>
  );
}

export function EditFoodRequestItemButton(props: { onClick: () => void }) {
  return (
    <button
      onClick={props.onClick}
      className="group mx-1 flex h-9 w-9 transform items-center justify-center rounded-full border-2 border-hunyadi_yellow transition duration-300 ease-in-out hover:scale-125 hover:bg-hunyadi_yellow"
    >
      <PencilIcon className="h-5 w-5 text-hunyadi_yellow group-hover:text-pine_green-900" />
    </button>
  );
}

export function DeleteFoodRequestItemButton(props: { onClick: () => void }) {
  return (
    <button
      onClick={props.onClick}
      className="group mx-1 flex h-9  w-9 transform items-center justify-center rounded-full border-2 border-madder transition duration-300 ease-in-out hover:scale-125 hover:bg-madder"
    >
      <TrashIcon className="h-5 w-5 text-madder group-hover:text-pine_green-900" />
    </button>
  );
}

export function GenericSubmitButton() {
  return (
    <button
      type="submit"
      className="group  relative flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out hover:scale-110"
    >
      <span className="text-m relative text-white">Submit</span>
    </button>
  );
}
