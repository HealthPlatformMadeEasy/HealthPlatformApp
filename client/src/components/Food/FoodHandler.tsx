import axios from "axios";
import { useEffect, useState } from "react";
import { useUserId } from "../../hooks";
import { Loading } from "../Loading";
import { foodRequest, INorwegianFoodResponse } from "../../types";
import Fuse from "fuse.js";
import { listOfDbFoods } from "../../utils/ListOfDbFoods.ts";

interface IError {
  Error: string;
}

const fuseOptions: Fuse.IFuseOptions<{ title: string }> = {
  keys: ["title"],
  includeMatches: true,
  threshold: 0.3,
};

const fuse = new Fuse(
  listOfDbFoods.map((food) => ({ title: food })),
  fuseOptions,
);

export function FoodHandler() {
  const [data, setData] = useState<IError | INorwegianFoodResponse>();
  const [foodInput, setFoodInput] = useState("");
  const [quantityInput, setQuantityInput] = useState("");
  const [formData, setFormData] = useState(false);
  const [loading, setLoading] = useState(false);
  const [showData, setShowData] = useState(false);
  const { userId } = useUserId();
  const [login, setLogin] = useState(false);
  const [showSearchItem, setShowSearchItem] = useState(true);
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

  useEffect(() => {
    if (userId !== null) {
      setLogin(true);
    }
  }, [userId]);

  const callData = () => {
    setLoading(true);
    setFormData(true);
    setFoodInput("");

    const food: foodRequest = {
      FoodName: foodInput,
      Quantity: parseFloat(quantityInput),
    };

    axios
      .get<IError, INorwegianFoodResponse>(
        "https://localhost:7247/api/norwegianfoods/gettotalresultofnorwegianfood",
        { params: food },
      )
      .then((data) => {
        setData(data);
        setLoading(false);
        setShowData(true);
      });
  };

  function setInputAgain() {
    return () => {
      setFormData(false);
      setShowData(false);
    };
  }

  return (
    <div className="">
      {!login && (
        <div className="grid bg-white p-10">
          <h1 className="text-9xl font-extrabold text-pink-700">
            Please Login
          </h1>
        </div>
      )}
      {login && (
        <div>
          {!formData && (
            <div>
              <div className="grid gap-2 bg-white p-10">
                <h1>Intro Food Name and Quantity test</h1>
                <div className="relative">
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
                  {showSearchItem && (
                    <ul className="absolute z-50 my-2 max-h-60 w-full overflow-auto bg-white py-1 pl-2">
                      {results.map((result) => (
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
                  )}
                </div>
                <input
                  id="price"
                  type="text"
                  name="price"
                  value={quantityInput}
                  placeholder="quantity"
                  onChange={(e) => setQuantityInput(e.target.value)}
                  className="mt-2 w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
                />
                <button
                  onClick={callData}
                  className="group relative m-auto flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out hover:scale-110"
                >
                  <span className="text-m relative text-white">Submit</span>
                </button>
              </div>
            </div>
          )}
          {loading && (
            <div className="bg-white p-10">
              <Loading />
            </div>
          )}
          {showData && (
            <div className="bg-white p-10">
              <button
                onClick={setInputAgain()}
                className="mt-5 rounded border border-blue-500 bg-transparent px-4 py-2 font-semibold text-blue-700 hover:border-transparent hover:bg-blue-500 hover:text-white"
              >
                Again
              </button>
              <h1 className="h-96 overflow-auto">{JSON.stringify(data)}</h1>
            </div>
          )}
        </div>
      )}
    </div>
  );
}
