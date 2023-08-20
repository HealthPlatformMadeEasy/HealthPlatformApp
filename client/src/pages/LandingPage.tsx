// TODO make Landing Page design
import { Link } from "react-router-dom";
import { Parallax } from "../components/Tables/Parallax.tsx";

export function LandingPage() {
  return (
    <div className="p-10">
      <h1 className="mb-8 font-playfair text-7xl text-white">
        Welcome to Meal Diary
      </h1>
      <hr className="my-6 border-gray-400 dark:border-gray-700 sm:mx-auto lg:my-8" />

      <Parallax />
      <hr className="my-6 border-gray-400 dark:border-gray-700 sm:mx-auto lg:my-8" />
      <div className="mr-12 mt-8 flex items-center justify-end gap-10">
        <Link
          to="/login"
          type="button"
          className="text-m group relative flex h-12 w-36 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-marian_blue px-6 transition duration-300 ease-in-out hover:scale-125"
        >
          <span className="text-m relative font-semibold text-white">
            Log in
          </span>
          <div className="flex translate-x-3 items-center -space-x-3">
            <div className="h-[1.6px] w-2.5 origin-left scale-x-0 rounded bg-white transition duration-300 group-hover:scale-x-100 " />
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
        </Link>
        <Link
          to="/signup"
          type="button"
          className="group relative flex h-12 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-tea_green px-6 transition duration-300 ease-in-out hover:scale-125"
        >
          <span className="text-m relative font-semibold text-pine_green-900">
            Sign in
          </span>
          <div className="flex translate-x-3 items-center -space-x-3">
            <div className="h-[1.6px] w-2.5 origin-left scale-x-0 rounded bg-pine_green-900 transition duration-300 group-hover:scale-x-100" />
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="h-5 w-5 -translate-x-2 stroke-pine_green-900 transition duration-300 group-hover:translate-x-0"
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
        </Link>
      </div>
    </div>
  );
}
