import { Link } from "react-router-dom";

export function CancelBackPreviousRouteButton() {
  return (
    <Link
      to="/"
      className="flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full border-2 border-madder px-6 text-light_coral-200 transition duration-300 ease-in-out hover:scale-125 hover:bg-madder hover:font-semibold hover:text-pine_green-900"
    >
      Cancel
    </Link>
  );
}
