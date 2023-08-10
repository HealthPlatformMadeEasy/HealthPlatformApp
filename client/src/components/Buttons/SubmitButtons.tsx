import {PencilIcon, PlusIcon, TrashIcon} from "@heroicons/react/24/outline";

export function AddButton() {
    return <button
        type="submit"
        className="flex text-white h-12 w-12 rounded-full
                        items-center justify-center bg-gradient-to-r from-marian_blue-400 via-marian_blue-500
                        to-marian_blue-800 transform transition duration-300 ease-in-out hover:scale-110"
    >
        <PlusIcon className="h-6 w-6 text-white"/>
    </button>;
}

export function EditFoodRequestItemButton(props: { onClick: () => void }) {
    return <button
        onClick={props.onClick}
        className="flex text-white h-12 w-12 rounded-full
                                        items-center justify-center bg-gradient-to-r from-amber-400 via-amber-500
                                        to-amber-600 transform transition duration-300 ease-in-out hover:scale-110 mx-1"
    >

        <PencilIcon className="h-6 w-6 text-black"/>
    </button>;
}

export function DeleteFoodRequestItemButton(props: { onClick: () => void }) {
    return <button
        onClick={props.onClick}
        className="flex text-white  h-12 w-12 rounded-full
                                        items-center justify-center bg-gradient-to-r from-madder-500 via-madder-600
                                        to-madder-800 transform transition duration-300 ease-in-out hover:scale-110 mx-1"
    >
        <TrashIcon className="h-6 w-6 text-white"/>
    </button>;
}

export function GenericSubmitButton() {
    return (
        <button
            type="submit"
            className="ml-4  relative group overflow-hidden px-6 h-12 rounded-full flex space-x-2 items-center
            bg-gradient-to-r from-marian_blue-400 via-marian_blue-500
            to-marian_blue-800 transform transition duration-300 ease-in-out hover:scale-110"
        >
            <span className="relative text-m text-white">
                Submit
            </span>
        </button>
    );
}
