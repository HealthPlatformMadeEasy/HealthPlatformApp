import {GenericSubmitButton} from "../Buttons";

export function Parallax() {
    return (
        <div className="flex items-center justify-center h-96 bg-fixed bg-yellow-fruit-left bg-cover">
            <h1 className=" text-5xl text-marian_blue-900 uppercase">Parallax</h1>
            <GenericSubmitButton/>
        </div>
    );
}
