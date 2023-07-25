import {Route, Routes} from "react-router-dom";
import Home from "../pages/Home.tsx";
import UserHomePage from "../pages/UserHomePage.tsx";

function Router() {

    return (
        <Routes>
            <Route index path='/' element={<Home/>}/>
            <Route path='/user-food' element={<UserHomePage/>}/>
        </Routes>
    )
}

export default Router;