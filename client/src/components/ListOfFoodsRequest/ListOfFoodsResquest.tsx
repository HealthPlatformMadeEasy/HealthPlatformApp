import {PencilIcon, PlusIcon, TrashIcon} from "@heroicons/react/24/outline";
import axios from "axios";
import React, {useEffect, useState} from 'react';
import Modal from 'react-modal';
import {useMutation} from "react-query";
import {useUserId} from "../../hooks";
import {Loading} from "../Loading";

type FoodItem = {
    id: number;
    FoodName: string,
    Quantity: number
};

type Food = {
    FoodName: string,
    Quantity: number
}

type FoodRequest = {
    userId: string | undefined,
    requests: Food[]
}

export interface IData {
    createdAt: string;
    spiseligDel: number;
    vann: number;
    kilojouleKJ: number;
    kilokalorierKcal: number;
    fett: number;
    mettet: number;
    c12_0g: number;
    c14_0: number;
    c16_0: number;
    c18_0: number;
    trans: number;
    enumettet: number;
    c16_1Sum: number;
    c18_1Sum: number;
    flerumettet: number;
    c18_2n_6: number;
    c18_3n_3: number;
    c20_3n_3: number;
    c20_3n_6: number;
    c20_4n_3: number;
    c20_4n_6: number;
    c20_5n_3_EPA: number;
    c22_5n_3_DPA: number;
    c22_6n_3_DHA: number;
    omega_3: number;
    omega_6: number;
    kolesterolMg: number;
    karbohydrat: number;
    stivelse: number;
    monoPlusDisakk: number;
    sukkerTilsatt: number;
    kostfiber: number;
    protein: number;
    salt: number;
    alkohol: number;
    vitaminARAE: number;
    retinolMug: number;
    betaKarotenMug: number;
    vitaminDMug: number;
    vitaminEAlfaTE: number;
    tiaminMg: number;
    riboflavinMg: number;
    niacinMg: number;
    vitaminB6Mg: number;
    folatMug: number;
    vitaminB12Mug: number;
    vitaminCMg: number;
    kalsiumMg: number;
    jernMg: number;
    natriumMg: number;
    kaliumMg: number;
    magnesiumMg: number;
    sinkMg: number;
    selenMug: number;
    kopperMg: number;
    fosforMg: number;
    jodMug: number;
}


interface IError {
    response?: { data: { message: string } };
}

const pushFoodData = async (request: FoodRequest | undefined) => {
    const response = await axios.post(
        'https://localhost:7247/api/norwegianfoods/getnutrientcalculationforuser',
        request,
        {headers: {'Content-Type': 'application/json'}}
    );
    return response.data;
}

const useSaveFoodData = () => {
    return useMutation(pushFoodData, {
            onError: (error: IError) => {
                console.log('Error: ', error.response?.data.message ?? error);
            },
            onSuccess: (data) => {
                return data;
            },
        }
    );
}


export function ListOfFoods() {
    const [form, setForm] = useState({FoodName: "", Quantity: 0});
    const [list, setList] = useState<FoodItem[]>([]);
    const [isEditing, setIsEditing] = useState(false);
    const [currentItem, setCurrentItem] = useState<FoodItem | null>(null);
    const [modalIsOpen, setModalIsOpen] = useState(false);
    const [data, setData] = useState<IData[] | null>(null);
    const [formData, setFormData] = useState(false);
    const [loading, setLoading] = useState(false);
    const [showData, setShowData] = useState(false);
    const mutation = useSaveFoodData();
    const {userId} = useUserId();
    const [login, setLogin] = useState(false);

    useEffect(() => {
        if (userId !== null) {
            setLogin(true);
        }
    }, [userId])

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (!isEditing) {
            setList([...list, {...form, id: Date.now()}]);
            setForm({FoodName: "", Quantity: 0});
        }
    };

    const handleUpdate = (e: React.FormEvent) => {
        e.preventDefault();
        if (isEditing && currentItem) {
            const updatedItem = {...currentItem, ...form};
            setList(list.map((item) => (item.id === updatedItem.id ? updatedItem : item)));
            setIsEditing(false);
            setCurrentItem(null);
            setModalIsOpen(false);
        }
    };

    const handleDelete = (id: number) => {
        setList(list.filter((item) => item.id !== id));
    };

    const handleEdit = (item: FoodItem) => {
        setForm({FoodName: item.FoodName, Quantity: item.Quantity});
        setIsEditing(true);
        setCurrentItem(item);
        setModalIsOpen(true);
    };

    const callData = () => {
        setLoading(true);
        setFormData(true);

        const request: Food[] = [];
        list.forEach(row => request.fill({FoodName: row.FoodName, Quantity: row.Quantity}));

        mutation.mutateAsync({userId: userId?.userId, requests: list})
            .then(response => {
                setData(response);
                setLoading(false);
                setShowData(true);
            })
            .catch(error => console.error(error));
    }

    return (
        <>
            {login && <div>
                {!formData &&
                    <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                        <h1 className="text-2xl font-bold mb-4">List of Food Items</h1>
                        <form onSubmit={handleSubmit} className="flex space-x-4">
                            <input
                                type="text"
                                required
                                value={form.FoodName}
                                placeholder="Food"
                                onChange={(e) => setForm({...form, FoodName: e.target.value})}
                                className="p-2 w-full border border-gray-200 rounded-md"
                            />
                            <input
                                type="number"
                                required
                                value={form.Quantity}
                                placeholder="Quantity in grams"
                                onChange={(e) =>
                                    setForm({...form, Quantity: parseFloat(e.target.value)})
                                }
                                className="p-2 w-full border border-gray-200 rounded-md"
                            />
                            <button type="submit" className="p-2 bg-gray-800 text-white rounded-md">
                                <PlusIcon className="h-6 w-6 text-white"/>
                            </button>
                        </form>
                        <ul className="mt-8 space-y-4">
                            {list.map((item) => (
                                <li key={item.id}
                                    className="flex items-center justify-between space-x-4 bg-gray-100 p-4 rounded-md">
                                    <div>
                                        <span className="font-bold text-lg">{item.FoodName}</span>
                                        <span className="ml-6">{item.Quantity}</span>
                                    </div>
                                    <div>
                                        <button onClick={() => handleEdit(item)}
                                                className="p-2 bg-yellow-500 text-white rounded-md">
                                            <PencilIcon className="h-6 w-6 text-white"/>
                                        </button>
                                        <button onClick={() => handleDelete(item.id)}
                                                className="ml-4 p-2 bg-red-600 text-white rounded-md">
                                            <TrashIcon className="h-6 w-6 text-white"/>
                                        </button>
                                    </div>
                                </li>
                            ))}
                        </ul>
                        <Modal
                            isOpen={modalIsOpen}
                            onRequestClose={() => setModalIsOpen(false)}
                            style={{
                                overlay: {
                                    backgroundColor: 'rgba(0, 0, 0, 0.5)',
                                },
                                content: {
                                    top: '50%',
                                    left: '50%',
                                    right: 'auto',
                                    bottom: 'auto',
                                    marginRight: '-50%',
                                    transform: 'translate(-50%, -50%)',
                                    backgroundColor: 'white',
                                    borderRadius: '0.375rem', // 6px
                                    padding: '2rem', // 32px
                                },
                            }}
                        >
                            <h2 className="text-2xl font-bold mb-4">Update Food Item</h2>
                            <form onSubmit={handleUpdate} className="grid grid-cols-2 gap-3">
                                <input
                                    type="text"
                                    required
                                    value={form.FoodName}
                                    onChange={(e) => setForm({...form, FoodName: e.target.value})}
                                    className="p-2 border border-gray-200 rounded-md"
                                />
                                <input
                                    type="number"
                                    required
                                    value={form.Quantity}
                                    onChange={(e) =>
                                        setForm({...form, Quantity: parseInt(e.target.value, 10)})
                                    }
                                    className="p-2 border border-gray-200 rounded-md"
                                />
                                <button
                                    type="submit"
                                    className="col-span-2 bg-transparent w-full hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                                >
                                    Submit
                                </button>
                            </form>
                            <button
                                onClick={() => setModalIsOpen(false)}
                                className="bg-transparent w-full hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                            >Cancel
                            </button>
                        </Modal>
                        <button onClick={callData}
                                className="bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                        >Call Data
                        </button>
                    </div>
                }
                {loading &&
                    <div className="space-x-5 w-1/3 border-2 border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                        <Loading/>
                    </div>}
                {showData &&
                    <div className=" w-3/4 border-2 border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                        <button onClick={() => {
                            setFormData(false)
                            setShowData(false)
                        }}
                                className=" w-full mb-5 bg-transparent hover:bg-blue-500 text-blue-700 font-semibold hover:text-white py-2 px-4 border border-blue-500 hover:border-transparent rounded mt-5"
                        >Again
                        </button>
                        <div className="w-full overflow-hidden rounded-lg shadow-xs">
                            {data && (
                                <div className="w-full overflow-x-auto">
                                    <table className="w-full whitespace-no-wrap">
                                        <thead>
                                        <tr className="text-xs font-semibold tracking-wide text-left text-gray-500 uppercase border-b bg-gray-50">
                                            <th className="px-4 py-3">Property</th>
                                            <th className="px-4 py-3">Value</th>
                                        </tr>
                                        </thead>
                                        <tbody className="bg-white divide-y">
                                        {
                                            Object.entries<any>(data).map(([key, value]) => (
                                                <tr key={key} className="text-gray-700">
                                                    <td className="px-4 py-3">{key}</td>
                                                    <td className="px-4 py-3">{value}</td>
                                                </tr>
                                            ))}
                                        </tbody>
                                    </table>
                                </div>
                            )}
                        </div>
                    </div>
                }
            </div>
            }
        </>
    );
}
