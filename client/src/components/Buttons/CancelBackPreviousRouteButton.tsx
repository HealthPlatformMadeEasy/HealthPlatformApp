import { Link } from "react-router-dom";

export function CancelBackPreviousRouteButton() {
  return (
    <Link
      to="/"
      className="group relative flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full border-2 border-madder px-6 text-madder-400 transition duration-300 ease-in-out hover:scale-110 "
    >
      Cancel
    </Link>
  );
}
