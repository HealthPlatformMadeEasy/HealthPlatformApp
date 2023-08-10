import { NavLink } from "react-router-dom";

export function LoginButton() {
  return (
    <button
      className="group relative ml-4 flex h-12 transform items-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-tea_green-800 via-pine_green-600 to-pine_green-700 px-6 transition duration-300
      ease-in-out hover:scale-110"
    >
      <NavLink to="/login" className="flex">
        <span className="text-m relative text-white">Login</span>
        <div className="flex translate-x-3 items-center -space-x-3">
          <div
            className="h-[1.6px] w-2.5 origin-left scale-x-0 rounded bg-white transition duration-300
        group-hover:scale-x-100"
          />
          <svg
            xmlns="http://www.w3.org/2000/svg"
            className="h-5 w-5 -translate-x-2 stroke-white transition duration-300 group-hover:translate-x-0"
            fill="none"
            viewBox="0 0 24 24"
            stroke="currentColor"
            strokeWidth="2"
          >
            <path
              strokeLinecap="round"
              strokeLinejoin="round"
              d="M9 5l7 7-7 7"
            />
          </svg>
        </div>
      </NavLink>
    </button>
  );
}
