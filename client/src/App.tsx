import { Route, Routes } from "react-router-dom";
import { Footer, NavBarLayout } from "./components";
import {
  ErrorPage,
  FoodPage,
  LandingPage,
  LoginPage,
  SignUpPage,
} from "./pages";

function App() {
  return (
    <div className="bg-pine_green-900 font-montserrat text-white">
      <Routes>
        <Route path="/" element={<NavBarLayout />}>
          <Route index path="food" element={<FoodPage />} />
        </Route>

        <Route index element={<LandingPage />} />
        <Route path="/login" element={<LoginPage />} />
        <Route path="/signup" element={<SignUpPage />} />
        <Route path="*" element={<ErrorPage />} />
      </Routes>
      <Footer />
    </div>
  );
}

export default App;
