import {useState} from "react";

function CalorieCalculator() {
    const [data, setData] = useState<undefined>();
    const [food, setFood] = useState("");
    const [quantity, setQuantity] = useState<number>();

    const callData = () => {
        fetch('https://localhost:7247/v1/api/food/', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({
                'food': food,
                'quantityInGrams': quantity
            })
        })
            .then(response => response.json())
            .then(data => setData(data))
    }

    return (
        <>
            <input type="text" name="food" id="price" value={food} onChange={e => setFood(e.target.value)}
                   className="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                   placeholder="food"/>

            <input type="text" name="price" id="price" value={quantity}
                   onChange={e => setQuantity(parseFloat(e.target.value))}
                   className="block w-full rounded-md border-0 py-1.5 pl-7 pr-20 text-gray-900 ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
                   placeholder="quantity"/>

            <button onClick={callData}
                    className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded"
            >Submit
            </button>

            <h1>{JSON.stringify(data)}</h1>
        </>
    )
}

export default CalorieCalculator;