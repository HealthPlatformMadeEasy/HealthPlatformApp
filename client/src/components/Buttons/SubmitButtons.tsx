import { PencilIcon, PlusIcon, TrashIcon } from "@heroicons/react/24/outline";

export function AddButton() {
  return (
    <button
      type="submit"
      className="flex h-12 w-12 transform items-center
                        justify-center rounded-full bg-gradient-to-r from-marian_blue-400 via-marian_blue-500
                        to-marian_blue-800 text-white transition duration-300 ease-in-out hover:scale-110"
    >
      <PlusIcon className="h-6 w-6 text-white" />
    </button>
  );
}

export function EditFoodRequestItemButton(props: { onClick: () => void }) {
  return (
    <button
      onClick={props.onClick}
      className="mx-1 flex h-12 w-12 transform
                                        items-center justify-center rounded-full bg-gradient-to-r from-amber-400
                                        via-amber-500 to-amber-600 text-white transition duration-300 ease-in-out hover:scale-110"
    >
      <PencilIcon className="h-6 w-6 text-black" />
    </button>
  );
}

export function DeleteFoodRequestItemButton(props: { onClick: () => void }) {
  return (
    <button
      onClick={props.onClick}
      className="mx-1 flex  h-12 w-12 transform
                                        items-center justify-center rounded-full bg-gradient-to-r from-madder-500
                                        via-madder-600 to-madder-800 text-white transition duration-300 ease-in-out hover:scale-110"
    >
      <TrashIcon className="h-6 w-6 text-white" />
    </button>
  );
}

export function GenericSubmitButton() {
  return (
    <button
      type="submit"
      className="group  relative flex h-12 transform items-center space-x-2 overflow-hidden rounded-full
            bg-gradient-to-r from-marian_blue-400 via-marian_blue-500
            to-marian_blue-800 px-6 transition duration-300 ease-in-out hover:scale-110"
    >
      <span className="text-m relative text-white">Submit</span>
    </button>
  );
}
