import {useUserId} from "../hooks";

export function LandingPage() {
    const {userId} = useUserId();
    return (
        <>
            <h1>Presentation Page {userId?.userId}</h1>

        </>
    )
}
