import {useEffect, useState} from "react";
import {UserContentCharts} from "../components";
import {useUserId} from "../hooks";

export function ChartPage() {
    const {userId} = useUserId();
    const [login, setLogin] = useState(false);

    useEffect(() => {
        if (userId !== null) {
            setLogin(true);
        }
    }, [userId])

    return (
        <>
            {login && <div>
                <h1>Login</h1>
                <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <UserContentCharts/>
                </div>
            </div>}
            {!login && <div>
                <h1>Not Login</h1>
                <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1 className="text-9xl font-extrabold text-pink-700">Please Login</h1>
                </div>
            </div>}

        </>
    );
}