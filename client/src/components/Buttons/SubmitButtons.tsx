import { PencilIcon, PlusIcon, TrashIcon } from "@heroicons/react/24/outline";

export function AddButton() {
  return (
    <button
      type="submit"
      className="flex h-10 w-10 transform items-center justify-center rounded-full border-2 border-marian_blue transition duration-300 ease-in-out hover:scale-110"
    >
      <PlusIcon className="h-6 w-6 text-marian_blue" />
    </button>
  );
}

export function EditFoodRequestItemButton(props: { onClick: () => void }) {
  return (
    <button
      onClick={props.onClick}
      className="mx-1 flex h-8 w-8 transform items-center justify-center rounded-full border-2 border-pine_green transition duration-300 ease-in-out hover:scale-110"
    >
      <PencilIcon className="h-6 w-6 text-pine_green" />
    </button>
  );
}

export function DeleteFoodRequestItemButton(props: { onClick: () => void }) {
  return (
    <button
      onClick={props.onClick}
      className="mx-1 flex  h-8 w-8 transform items-center justify-center rounded-full border-2 border-madder-600 transition duration-300 ease-in-out hover:scale-110"
    >
      <TrashIcon className="h-6 w-6 text-madder-600" />
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
