import {useUserId} from "../hooks/userUserId.tsx";

function Home() {
    const {userId} = useUserId();
    return (
        <>
            <h1>Presentation Page {userId}</h1>
            
        </>
    )
}

export default Home;