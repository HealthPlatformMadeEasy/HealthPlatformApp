import { Link } from "react-router-dom";

export function CancelBackPreviousRouteButton() {
  return (
    <Link
      to="/"
      className="flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-madder px-6 font-semibold text-white transition duration-300 ease-in-out hover:scale-125"
    >
      Cancel
    </Link>
  );
}
