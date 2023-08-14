// TODO make Landing Page design
import { useNavigate } from "react-router-dom";

export function LandingPage() {
  const navigate = useNavigate();

  return (
    <main className="p-12">
      <h1 className="text-7xl text-green-700">Landing Page</h1>
      <hr />
      <div>
        <p>
          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam
          suscipit justo et porttitor venenatis. Duis tristique dignissim
          imperdiet. Pellentesque non augue sed ante tempus venenatis in vitae
          nisi. Etiam sit amet orci interdum quam sagittis molestie a dignissim
          lectus. Vivamus efficitur tortor non dui fermentum, vel eleifend
          sapien laoreet. Nulla non neque ultrices, pharetra mauris at, tempus
          turpis. Suspendisse hendrerit risus et orci consequat pharetra.
          Vivamus aliquet facilisis nunc ut convallis. Pellentesque ac hendrerit
          ligula.{" "}
        </p>
      </div>
      <hr />
      <div className="mr-12 mt-8 flex items-center justify-end gap-4">
        <button
          onClick={() => navigate("/login")}
          type="button"
          className="group relative flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out
      hover:scale-110"
        >
          <span className="text-m relative text-white">Login</span>
        </button>
        <button
          onClick={() => navigate("/signup")}
          type="button"
          className="group relative flex h-12 w-32 transform items-center justify-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-amber-400 via-amber-500 to-amber-600 px-6 transition duration-300 ease-in-out
      hover:scale-110"
        >
          <span className="text-m relative">Sign Up</span>
        </button>
      </div>
    </main>
  );
}
