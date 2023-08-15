import Fuse from "fuse.js";
import { useEffect, useState } from "react";
import { listOfDbFoods } from "../../utils/ListOfDbFoods.ts";

const fuseOptions: Fuse.IFuseOptions<{ title: string }> = {
  keys: ["title"],
  includeMatches: true,
  threshold: 0.3,
};

const fuse = new Fuse(
  listOfDbFoods.map((food) => ({ title: food })),
  fuseOptions,
);

export function SearchBar() {
  const [showSearchItem, setShowSearchItem] = useState(true);
  const [foodInput, setFoodInput] = useState("");
  const [results, setResults] = useState<Fuse.FuseResult<{ title: string }>[]>(
    [],
  );

  useEffect(() => {
    if (foodInput) {
      const searchResults = fuse.search(foodInput);
      setResults(searchResults);
    } else {
      setResults([]);
    }
  }, [foodInput]);

  return (
    <>
      <input
        type="text"
        placeholder="Search for a food..."
        value={foodInput}
        onChange={(e) => {
          setFoodInput(e.target.value);
          setShowSearchItem(true);
        }}
        className="w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
      />
      <ul>
        {showSearchItem &&
          results.map((result) => (
            <li
              key={result.item.title}
              onClick={() => {
                setFoodInput(result.item.title);
                setShowSearchItem(false);
              }}
              className="hover:cursor-pointer"
            >
              {result.item.title}
            </li>
          ))}
      </ul>
    </>
  );
}
