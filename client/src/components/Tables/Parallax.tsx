import { GenericSubmitButton } from "../Buttons";

export function Parallax() {
  return (
    <div className="flex h-96 items-center justify-center bg-yellow-fruit-left bg-cover bg-fixed">
      <h1 className=" text-5xl uppercase text-marian_blue-900">Parallax</h1>
      <GenericSubmitButton />
    </div>
  );
}
