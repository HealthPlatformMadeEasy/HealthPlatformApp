import { Navbar } from "./NavBar.tsx";
import { Outlet } from "react-router-dom";

export function NavBarLayout() {
  return (
    <>
      <Navbar />
      <Outlet />
    </>
  );
}
