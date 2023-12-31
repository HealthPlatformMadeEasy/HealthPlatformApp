import { useNavigate } from "react-router-dom";

export function ErrorPage() {
  const navigate = useNavigate();
  return (
    <main className="flex h-screen w-screen items-center bg-[url('./assets/Lionel_Richie.jpg')] bg-cover p-12">
      <div className="container flex flex-col items-center px-5 md:flex-row">
        <div className="w-1/2 rounded-full bg-pine_green-900 px-[100px] py-[150px] text-gray-200">
          <div className="font-dark text-9xl">404</div>
          <p className="font-playfair text-6xl leading-normal">HELLO,</p>
          <p className="mb-8 font-playfair text-4xl">
            is it me you're looking for?...
          </p>
          <div className="flex">
            <button
              onClick={() => navigate("/")}
              className="flex h-14 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-marian_blue px-8 font-semibold text-white transition duration-300 ease-in-out hover:scale-125"
            >
              Back
            </button>
          </div>
        </div>
      </div>
    </main>
  );
}
