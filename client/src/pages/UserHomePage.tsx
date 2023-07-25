import CalorieCalculator from "../components/CalorieCalculator/CalorieCalculator.tsx";
import ListOfFoods from "../components/ListOfFoodsRequest/ListOfFoodsResquest.tsx";
import {useUserId} from "../hooks/userUserId.tsx";


function UserHomePage() {
    const {userId} = useUserId();

    return (
        <>
            <h1>{userId}</h1>
            <CalorieCalculator/>
            <ListOfFoods/>
        </>
    )
}

export default UserHomePage;