import { useUserId } from "../hooks";

export function LandingPage() {
  const { userId } = useUserId();

  return (
    <>
      <h1 className="text-7xl text-green-700">
        Presentation Page {userId?.userId}
      </h1>
    </>
  );
}
