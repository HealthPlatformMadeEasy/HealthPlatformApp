import { Route, Routes } from "react-router-dom";
import { Footer, NavBarLayout } from "./components";
import { UserIdProvider } from "./hooks";
import {
  AboutPage,
  ErrorPage,
  FoodPage,
  LandingPage,
  LoginPage,
  SignUpPage,
} from "./pages";

function App() {
  return (
    <div>
      <UserIdProvider>
        <Routes>
          <Route path="/" element={<NavBarLayout />}>
            <Route index path="food" element={<FoodPage />} />
            <Route path="about" element={<AboutPage />} />
          </Route>

          <Route index element={<LandingPage />} />
          <Route path="/login" element={<LoginPage />} />
          <Route path="/signup" element={<SignUpPage />} />
          <Route path="*" element={<ErrorPage />} />
        </Routes>
        <Footer />
      </UserIdProvider>
    </div>
  );
}

export default App;
