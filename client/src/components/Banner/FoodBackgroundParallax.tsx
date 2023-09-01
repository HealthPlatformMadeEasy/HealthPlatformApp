export function FoodBackgroundParallax() {
  return (
    <div className="flex h-96 items-center justify-self-end bg-fancy-food bg-cover bg-fixed">
      <div className="my-4 ml-16 w-1/3 rounded-xl border-2 border-pine_green-600 bg-pine_green-900 p-10 text-left shadow-2xl">
        <h3>
          This is a product that helps you visualize your nutrition journey.
        </h3>
        <h2 className="py-4 font-playfair text-3xl font-light italic text-marian_blue-100">
          "We Are What We Eat."
        </h2>
        <p>
          This App will provide you with comprehensive tools to keep track of
          energy, macros, vitamins, minerals, and nutrients of each meal.
        </p>
        <p className="mt-6 text-right">You are welcome to sign up and try.</p>
      </div>
    </div>
  );
}
