import {useState} from "react";
import {Loading} from "../Loading";

type foodRequest = {
    food: string,
    quantity: number
}

export function CalorieCalculator() {
    const [data, setData] = useState<undefined>();
    const [food1, setFood] = useState("");
    const [quantity1, setQuantity] = useState("");
    const [formData, setFormData] = useState(false);
    const [loading, setLoading] = useState(false);
    const [showData, setShowData] = useState(false);

    const callData = () => {
        setLoading(true);
        setFormData(true)

        const food: foodRequest = {
            food: food1,
            quantity: parseFloat(quantity1)
        }

        fetch('https://localhost:7247/v1/api/food/single', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(food)
        })
            .then(response => response.json())
            .then(data => {
                setData(data)
                setLoading(false);
                setShowData(true);
            })
    }

    return (
        <>
            {!formData &&
                <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1>Intro Food Name and Quantity</h1>
                    <input type="text" name="food" id="price" value={food1}
                           onChange={e => setFood(e.target.value)}
                           className="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-gray-900 ring-1 ring-inset ring-blue-300 placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6 my-3"
                           placeholder="food"/>

                    <input type="text" name="price" id="price" value={quantity1}
                           onChange={e => setQuantity(e.target.value)}
                           className="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-grey-900 ring-1 ring-inset ring-blue-300 placeholder:text-gray-400 focus:ring-1 focus:ring-inset focus:ring-blue-600 sm:text-sm sm:leading-6"
                           placeholder="quantity"/>

                    <button onClick={callData}
                            className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                    >Submit
                    </button>
                </div>
            }
            {loading &&
                <div className="space-x-5 w-1/3 border-2 border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <Loading/>
                </div>}
            {showData &&
                <div className=" w-1/3 border-2 border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <button onClick={() => {
                        setFormData(false)
                        setShowData(false)
                    }}
                            className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                    >Again
                    </button>
                    <h1>{JSON.stringify(data)}</h1>
                </div>

            }
        </>
    )
}
