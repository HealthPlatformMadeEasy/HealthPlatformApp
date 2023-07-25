import './App.css'
import {Navbar} from "./components/NavBar/NavBar.tsx";
import Router from "./routes/Router.tsx";
import {UserIdProvider} from "./hooks/userUserId.tsx";

function App() {
    
    return (
        <>
            <UserIdProvider>
                <Navbar/>
                <Router/>
            </UserIdProvider>

        </>
    )
}

export default App;
