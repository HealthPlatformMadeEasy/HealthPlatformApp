import {useEffect, useState} from "react";
import {Route, Routes, useLocation} from "react-router-dom";
import {ChartPage, LandingPage, UserHomePage} from "../pages";

export function Router() {
    const location = useLocation();

    const [displayLocation, setDisplayLocation] = useState(location);
    const [transitionStage, setTransitionStage] = useState("fadeIn");

    useEffect(() => {
        if (location !== displayLocation) setTransitionStage("fadeOut");
    }, [location, displayLocation]);

    return (
        <div
            className={`${transitionStage}`}
            onAnimationEnd={() => {
                if (transitionStage === "fadeOut") {
                    setTransitionStage("fadeIn");
                    setDisplayLocation(location);
                }
            }}
        >
            <Routes>
                <Route index path='/' element={<LandingPage/>}/>
                <Route path='/user-food' element={<UserHomePage/>}/>
                <Route path='/charts' element={<ChartPage/>}/>
            </Routes>
        </div>
    )
}
