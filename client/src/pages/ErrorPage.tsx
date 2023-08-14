import { useNavigate } from "react-router-dom";

export function ErrorPage() {
  const navigate = useNavigate();
  return (
    <main className="flex h-screen w-screen items-center bg-gray-100 bg-[url('./assets/Lionel_Richie.jpg')] bg-cover p-12">
      <div className="container flex flex-col items-center px-5 text-gray-700 md:flex-row">
        <div className="w-1/2 rounded-full bg-white px-[100px] py-[150px]">
          <div className="font-dark text-9xl text-black">404</div>
          <p className="text-7xl font-light leading-normal md:text-3xl">
            HELLO,{" "}
          </p>
          <p className="mb-8 text-5xl font-bold">
            is it me you're looking for?...
          </p>
          <div className="flex">
            <button
              onClick={() => navigate("/")}
              className="focus:shadow-outline-blue inline justify-end rounded-lg border border-transparent bg-blue-600 px-4 py-2 text-sm font-medium leading-5 text-white shadow transition-colors duration-150 hover:bg-blue-700 focus:outline-none active:bg-blue-600"
            >
              back to homepage
            </button>
          </div>
        </div>
      </div>
    </main>
  );
}
