import { NavLink } from "react-router-dom";
import { LoginButton } from "../Buttons";

export function Navbar() {
  return (
    <nav className="sticky z-50 flex w-full items-center justify-between bg-opacity-10 p-6">
      <div className="flex-no-shrink mr-6 flex items-center text-green-700">
        <span className="text-3xl font-semibold">Health App</span>
      </div>
      <div id="nav-content" className="flex items-center">
        <div className="mr-auto space-x-4 text-sm lg:flex-grow">
          <button className="mr-4 transform text-lg transition duration-300 ease-in-out hover:scale-125">
            <NavLink
              to="/"
              end
              className={({ isActive }) =>
                isActive
                  ? "p-2 text-green-700 hover:font-bold hover:text-green-700"
                  : "p-2 text-gray-500 hover:font-bold hover:text-green-700"
              }
            >
              Home
            </NavLink>
          </button>
          <button className="mr-4 transform text-lg transition duration-300 ease-in-out hover:scale-125">
            <NavLink
              to="/user-food"
              className={({ isActive }) =>
                isActive
                  ? "p-2 text-green-700 hover:font-bold hover:text-green-700"
                  : "p-2 text-gray-500 hover:font-bold hover:text-green-700"
              }
            >
              User Food
            </NavLink>
          </button>
          <button className="mr-4 transform text-lg transition duration-300 ease-in-out hover:scale-125">
            <NavLink
              to="/charts"
              className={({ isActive }) =>
                isActive
                  ? "p-2 text-green-700 hover:font-bold hover:text-green-700"
                  : "p-2 text-gray-500 hover:font-bold hover:text-green-700"
              }
            >
              Charts
            </NavLink>
          </button>
          <button
            className="mr-4 transform font-raleway text-lg font-semibold transition duration-300 ease-in-out
            hover:scale-125"
          >
            <NavLink
              to="/test"
              className={({ isActive }) =>
                isActive
                  ? "p-2 text-marian_blue-700 hover:font-bold hover:text-marian_blue-900"
                  : "p-2 text-gray-500 hover:font-bold hover:text-green-700"
              }
            >
              Test
            </NavLink>
          </button>
          <button
            className="mr-4 transform font-raleway text-lg font-semibold transition duration-300 ease-in-out
            hover:scale-125"
          ></button>
        </div>
        <LoginButton />
      </div>
    </nav>
  );
}
