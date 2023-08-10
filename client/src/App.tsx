import {Navbar} from "./components";
import {UserIdProvider} from "./hooks";
import {Route, Routes} from "react-router-dom";
import {ChartPage, LandingPage, LoginPage, TestPage, UserHomePage} from "./pages";

function App() {

    return (
        <div>
            <UserIdProvider>
                <Navbar/>
                <Routes>
                    <Route index path='/' element={<LandingPage/>}/>
                    <Route path='/user-food' element={<UserHomePage/>}/>
                    <Route path='/charts' element={<ChartPage/>}/>
                    <Route path='/test' element={<TestPage/>}/>
                    <Route path='/login' element={<LoginPage/>}/>
                </Routes>
            </UserIdProvider>
        </div>
    )
}

export default App;
