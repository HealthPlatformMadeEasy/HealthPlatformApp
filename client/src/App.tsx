import {Route, Routes} from "react-router-dom";
import {Footer, NavBarLayout} from "./components";
import {UserIdProvider} from "./hooks";
import {ErrorPage, FoodPage, LandingPage, LoginPage, NewFeaturePage, SignUpPage, TestPage,} from "./pages";

function App() {
  return (
    <div>
      <UserIdProvider>
        <Routes>
          <Route path="/" element={<NavBarLayout />}>
            <Route index path="food" element={<FoodPage />} />
            <Route path="new-feature" element={<NewFeaturePage/>}/>
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
