import { NavLink } from "react-router-dom";
import { LogOutButton } from "../Buttons";

export function Navbar() {
  return (
    <header>
      <nav className="sticky top-0 z-50 flex w-full items-center justify-between bg-white p-6">
        <div className="flex-no-shrink mr-6 flex items-center text-green-700">
          <span className="text-3xl font-semibold">Health App</span>
        </div>
        <div id="nav-content" className="flex items-center">
          <div className="mr-auto space-x-4 text-sm lg:flex-grow">
            <NavLink
              to="/food"
              className={({ isActive }) =>
                isActive
                  ? "mr-4 transform p-2 font-raleway text-lg font-bold text-marian_blue-700 transition" +
                    " duration-300 ease-in-out hover:scale-125 hover:font-bold hover:text-marian_blue-900"
                  : "mr-4 transform p-2 font-raleway text-lg text-gray-500 hover:font-bold hover:text-green-700" +
                    " font-bold transition duration-300 ease-in-out hover:scale-125"
              }
            >
              Food
            </NavLink>
          </div>
          <LogOutButton />
        </div>
      </nav>
    </header>
  );
}
