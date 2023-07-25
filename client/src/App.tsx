import './App.css'
import CalorieCalculator from "./components/CalorieCalculator/CalorieCalculator.tsx";
import ListOfFoods from "./components/ListOfFoodsRequest/ListOfFoodsResquest.tsx";
import {Navbar} from "./components/NavBar/NavBar.tsx";

function App() {

    return (
        <>
            <Navbar/>
            <CalorieCalculator/>
            <ListOfFoods/>
        </>
    )
}

export default App;
