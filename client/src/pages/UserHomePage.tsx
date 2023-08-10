import { CalorieCalculator, ListOfFoods } from "../components";
import { useUserId } from "../hooks";

export function UserHomePage() {
  const { userId } = useUserId();

  return (
    <>
      <h1>{userId?.userId}</h1>
      <CalorieCalculator />
      <ListOfFoods />
    </>
  );
}
