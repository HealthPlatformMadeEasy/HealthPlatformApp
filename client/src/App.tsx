import { UserIdProvider } from "./hooks";
import {
  ErrorPage,
  FoodPage,
  LandingPage,
  LoginPage,
  NewFeaturePage,
  SignUpPage,
  TestPage,
} from "./pages";
import { Footer, NavBarLayout } from "./components";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <div>
      <UserIdProvider>
        <Routes>
          <Route path="/" element={<NavBarLayout />}>
            <Route index path="food" element={<FoodPage />} />
            <Route path="charts" element={<NewFeaturePage />} />
            <Route path="test" element={<TestPage />} />
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
