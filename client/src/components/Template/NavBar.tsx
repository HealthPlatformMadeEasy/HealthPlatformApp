import {NavLink} from "react-router-dom";
import {LogOutButton} from "../Buttons";

export function Navbar() {
  return (
    <nav className="sticky top-0 z-50 flex w-full items-center justify-between border-b-2 border-pine_green-600 bg-pine_green-900 p-6">
      <div className="flex-no-shrink mr-6 flex items-center">
        <div className="mb-6 md:mb-0">
          <a className="flex items-center gap-6">
            <div
                className="mr-3 h-14 w-14 rounded-full bg-white bg-small-bird-logo p-1 outline outline-4 outline-offset-2 outline-pine_green-600"/>
            <span className="self-center whitespace-nowrap font-playfair text-5xl">
              Meal Diary
            </span>
          </a>
        </div>
      </div>
      <div id="nav-content" className="flex items-center">
        <div className="mr-auto space-x-4 text-sm lg:flex-grow">
          <NavLink
            to="/food"
            className={({ isActive }) =>
              isActive
                ? "text-grey-100 mr-4 transform p-2 text-lg transition duration-300 ease-in-out hover:scale-125" +
                  " hover:text-red-400"
                : "text-grey-400 mr-4 transform p-2 text-lg transition duration-300 ease-in-out hover:scale-125 hover:text-tea_green"
            }
          >
            Food
          </NavLink>
        </div>
        <LogOutButton />
      </div>
    </nav>
  );
}
