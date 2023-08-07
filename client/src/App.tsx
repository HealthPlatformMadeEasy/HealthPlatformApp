import {Navbar} from "./components";
import {UserIdProvider} from "./hooks";
import {Router} from "./routes";

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
