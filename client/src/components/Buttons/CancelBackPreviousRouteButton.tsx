import { useNavigate } from "react-router-dom";

export function CancelBackPreviousRouteButton() {
  const navigate = useNavigate();
  return (
    <button
      type="button"
      onClick={() => navigate("/")}
      className="group relative flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-madder-600 via-madder-700 to-madder-800 px-6 transition duration-300 ease-in-out
      hover:scale-110"
    >
      <span className="text-m relative text-white">Cancel</span>
    </button>
  );
}
