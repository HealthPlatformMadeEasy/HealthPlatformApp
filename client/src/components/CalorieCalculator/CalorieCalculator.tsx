import axios from "axios";
import React, { useEffect, useState } from "react";
import { useUserId } from "../../hooks";
import { SingleFoodForm } from "../Forms";
import { Loading } from "../Loading";
import { foodRequest, INorwegianFoodResponse } from "../../types";

interface IError {
  Error: string;
}

export function CalorieCalculator() {
  const [data, setData] = useState<IError | INorwegianFoodResponse>();
  const [foodInput, setFoodInput] = useState("");
  const [quantityInput, setQuantityInput] = useState("");
  const [formData, setFormData] = useState(false);
  const [loading, setLoading] = useState(false);
  const [showData, setShowData] = useState(false);
  const { userId } = useUserId();
  const [login, setLogin] = useState(false);

  useEffect(() => {
    if (userId !== null) {
      setLogin(true);
    }
  }, [userId]);

  const callData = () => {
    setLoading(true);
    setFormData(true);

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

  function getOnChangeFood() {
    return (e: React.ChangeEvent<HTMLInputElement>) =>
      setFoodInput(e.target.value);
  }

  function getOnChangeQuantity() {
    return (e: React.ChangeEvent<HTMLInputElement>) =>
      setQuantityInput(e.target.value);
  }

  function setInputAgain() {
    return () => {
      setFormData(false);
      setShowData(false);
    };
  }

  return (
    <>
      {!login && (
        <div className="m-auto my-16 grid w-1/3 rounded-xl border border-solid border-blue-800 p-10">
          <h1 className="text-9xl font-extrabold text-pink-700">
            Please Login
          </h1>
        </div>
      )}
      {login && (
        <div>
          {!formData && (
            <SingleFoodForm
              foodProp={foodInput}
              setFoodInputCB={getOnChangeFood()}
              quantityProp={quantityInput}
              setQuantityInputCB={getOnChangeQuantity()}
              onClick={callData}
            />
          )}
          {loading && (
            <div className="m-auto my-16 w-1/3 space-x-5 rounded-xl border-2 border-solid border-blue-800 p-10">
              <Loading />
            </div>
          )}
          {showData && (
            <div className=" m-auto my-16 w-1/3 rounded-xl border-2 border-solid border-blue-800 p-10">
              <button
                onClick={setInputAgain()}
                className="mt-5 rounded border border-blue-500 bg-transparent px-4 py-2 font-semibold text-blue-700 hover:border-transparent hover:bg-blue-500 hover:text-white"
              >
                Again
              </button>
              <h1>{JSON.stringify(data)}</h1>
            </div>
          )}
        </div>
      )}
    </>
  );
}
