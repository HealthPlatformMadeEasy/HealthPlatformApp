import {Route, Routes} from "react-router-dom";
import {LandingPage, UserHomePage} from "../pages";

export function Router() {

    return (
        <Routes>
            <Route index path='/' element={<LandingPage/>}/>
            <Route path='/user-food' element={<UserHomePage/>}/>
        </Routes>
    )
}
