import { UserIdProvider } from "./hooks";
import {
  ChartPage,
  ErrorPage,
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
            <Route path="food" element={<UserHomePage />} />
            <Route path="charts" element={<ChartPage />} />
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
