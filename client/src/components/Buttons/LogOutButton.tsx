import { Link } from "react-router-dom";

export function LogOutButton() {
  return (
    <Link
      to="/"
      className="group relative ml-4 mr-4 flex h-12 transform items-center space-x-2 overflow-hidden rounded-full border-4 border-light_coral px-6 text-light_coral-200 transition duration-300 ease-in-out hover:scale-125 hover:bg-light_coral hover:font-semibold hover:text-pine_green-900"
    >
      <span className="text-m relative ">Log Out</span>
      <div className="group flex translate-x-3 items-center -space-x-3">
        <div
          className="h-[1.6px] w-2.5 origin-left scale-x-0 rounded bg-pine_green-900 transition duration-300
        group-hover:scale-x-100"
        />
        <svg
          xmlns="http://www.w3.org/2000/svg"
          className="h-5 w-5 -translate-x-2 stroke-madder-200 transition duration-300 group-hover:translate-x-0 group-hover:stroke-pine_green-900"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
          strokeWidth="2"
        >
          <path strokeLinecap="round" strokeLinejoin="round" d="M9 5l7 7-7 7" />
        </svg>
      </div>
    </Link>
  );
}
