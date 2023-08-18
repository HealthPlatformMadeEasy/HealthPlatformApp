// TODO make Landing Page design
import { Link } from "react-router-dom";

export function LandingPage() {
  return (
    <main className="p-10">
      <h1 className="mb-8 font-playfair text-7xl text-white">
        Welcome to Meal Diary
      </h1>
      <hr className="my-6 border-gray-400 dark:border-gray-700 sm:mx-auto lg:my-8" />
      <div className="my-4 ml-16 w-1/3 rounded-xl border-2 border-pine_green-600 p-10 text-left">
        <h3>
          This is a product that helps you visualise your nutrition journey.
        </h3>
        <h2 className="py-4 font-playfair text-3xl font-light italic text-marian_blue-100">
          "We Are What We Eat."
        </h2>
        <p>
          This App will provided you comprehensive tools to keep track of
          energy, macros, vitamins minerals and nutrients of each meal.
        </p>
        <p className="mt-6 text-right">You are welcome to sign up and try.</p>
      </div>
      <hr className="my-6 border-gray-400 dark:border-gray-700 sm:mx-auto lg:my-8" />
      <div className="mr-12 mt-8 flex items-center justify-end gap-10">
        <Link
          to="/login"
          type="button"
          className="text-m group relative flex h-12 transform items-center justify-center space-x-2 overflow-hidden rounded-full border-4 border-marian_blue-300 px-6 transition duration-300 ease-in-out hover:scale-110"
        >
          <span className="text-m relative text-marian_blue-200">Log in</span>
          <div className="flex translate-x-3 items-center -space-x-3">
            <div
              className="h-[1.6px] w-2.5 origin-left scale-x-0 rounded bg-marian_blue-200 transition duration-300
        group-hover:scale-x-100"
            />
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="h-5 w-5 -translate-x-2 stroke-marian_blue-200 transition duration-300 group-hover:translate-x-0"
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
          className="group relative flex h-12 transform items-center justify-center space-x-2 overflow-hidden rounded-full border-4 border-pine_green-300 px-6 transition duration-300 ease-in-out hover:scale-110"
        >
          <span className="text-m relative text-pine_green-200">Sign in</span>
          <div className="flex translate-x-3 items-center -space-x-3">
            <div className="h-[1.6px] w-2.5 origin-left scale-x-0 rounded bg-pine_green-200 transition duration-300 group-hover:scale-x-100" />
            <svg
              xmlns="http://www.w3.org/2000/svg"
              className="h-5 w-5 -translate-x-2 stroke-pine_green-200 transition duration-300 group-hover:translate-x-0"
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
    </main>
  );
}
