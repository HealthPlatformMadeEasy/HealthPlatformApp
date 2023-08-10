import axios from "axios";
import React, {useEffect, useState} from "react";
import {useUserId} from "../../hooks";
import {SingleFoodForm} from "../Forms";
import {Loading} from "../Loading";
import {foodRequest, INorwegianFoodResponse} from "../../types";

interface IError {
    Error: string
}

export function CalorieCalculator() {
    const [data, setData] = useState<IError | INorwegianFoodResponse>();
    const [foodInput, setFoodInput] = useState("");
    const [quantityInput, setQuantityInput] = useState("");
    const [formData, setFormData] = useState(false);
    const [loading, setLoading] = useState(false);
    const [showData, setShowData] = useState(false);
    const {userId} = useUserId();
    const [login, setLogin] = useState(false);

    useEffect(() => {
        if (userId !== null) {
            setLogin(true);
        }
    }, [userId])

    const callData = () => {
        setLoading(true);
        setFormData(true);

        const food: foodRequest = {
            FoodName: foodInput,
            Quantity: parseFloat(quantityInput)
        }

        axios.get<IError, INorwegianFoodResponse>('https://localhost:7247/api/norwegianfoods/gettotalresultofnorwegianfood', {params: food})
            .then(data => {
                setData(data);
                setLoading(false);
                setShowData(true);
            })
    }

    function getOnChangeFood() {
        return (e: React.ChangeEvent<HTMLInputElement>) => setFoodInput(e.target.value);
    }

    function getOnChangeQuantity() {
        return (e: React.ChangeEvent<HTMLInputElement>) => setQuantityInput(e.target.value);
    }

    function setInputAgain() {
        return () => {
            setFormData(false)
            setShowData(false)
        };
    }

    return (
        <>
            {!login && <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                <h1 className="text-9xl font-extrabold text-pink-700">Please Login</h1>
            </div>}
            {login && <div>
                {!formData &&
                    <SingleFoodForm foodProp={foodInput}
                                    setFoodInputCB={getOnChangeFood()}
                                    quantityProp={quantityInput}
                                    setQuantityInputCB={getOnChangeQuantity()} onClick={callData}/>
                }
                {loading &&
                    <div className="space-x-5 w-1/3 border-2 border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                        <Loading/>
                    </div>}
                {showData &&
                    <div className=" w-1/3 border-2 border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                        <button onClick={setInputAgain()}
                                className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                        >Again
                        </button>
                        <h1>{JSON.stringify(data)}</h1>
                    </div>
                }
            </div>
            }
        </>
    )
}
