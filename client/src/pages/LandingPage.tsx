// TODO make Landing Page design
import { Link } from "react-router-dom";

export function LandingPage() {
  return (
    <main className="h-[630px] bg-[url('./assets/ruler-apple-size.png')] bg-cover bg-fixed p-12 py-20">
      <h1 className="mb-8 text-7xl text-green-700">
        Welcome to the Health App
      </h1>
      <hr />
      <div className="my-4 ml-16 w-1/3 py-6 text-left">
        <h3>This is a product that care of your health and wellness.</h3>
        <h2 className="py-4 text-3xl font-light italic text-marian_blue-700">
          "We Are What We Eat."
        </h2>
        <p>
          Following this premise we ask ourself. How can we know what we eat?.
        </p>
        <p>
          This App will provided you comprehensive tools to keep track of
          energy, macros, vitamins minerals and nutrients of each meal.
        </p>
        <p className="mt-6 text-right">You are welcome to sign up and try.</p>
      </div>
      <hr />
      <div className="mr-12 mt-8 flex items-center justify-end gap-4">
        <Link
          to="/login"
          type="button"
          className="group relative flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out
      hover:scale-110"
        >
          <span className="text-m relative text-white">Login</span>
        </Link>
        <Link
          to="/signup"
          type="button"
          className="group relative flex h-12 w-32 transform items-center justify-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-amber-400 via-amber-500 to-amber-600 px-6 transition duration-300 ease-in-out
      hover:scale-110"
        >
          <span className="text-m relative">Sign Up</span>
        </Link>
      </div>
    </main>
  );
}
