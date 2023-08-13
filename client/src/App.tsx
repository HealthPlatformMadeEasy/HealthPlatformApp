import { UserIdProvider } from "./hooks";
import {
  ChartPage,
  LandingPage,
  LoginPage,
  SignUpPage,
  TestPage,
  UserHomePage,
} from "./pages";
import { Footer, NavBarLayout } from "./components";
import { Route, Routes } from "react-router-dom";

function App() {
  return (
    <div>
      <UserIdProvider>
        <Routes>
          <Route path="/" element={<NavBarLayout />}>
            <Route index element={<LandingPage />} />
            <Route path="food" element={<UserHomePage />} />
            <Route path="charts" element={<ChartPage />} />
            <Route path="test" element={<TestPage />} />
          </Route>

          <Route path="/login" element={<LoginPage />} />
          <Route path="/signup" element={<SignUpPage />} />
        </Routes>
        <Footer />
      </UserIdProvider>
    </div>
  );
}

export default App;
