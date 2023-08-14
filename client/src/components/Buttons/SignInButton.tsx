export function SignInButton() {
  return (
    <button
      type="submit"
      className="group relative flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full
      bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out
      hover:scale-110"
    >
      <span className="text-m relative text-white">Sign In</span>
    </button>
  );
}
