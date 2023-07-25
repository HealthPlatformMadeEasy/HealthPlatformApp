import './App.css'
import {Navbar} from "./components/NavBar/NavBar.tsx";
import Router from "./routes/Router.tsx";


function App() {

    return (
        <>
            <Navbar/>
            <Router/>
        </>
    )
}

export default App;
