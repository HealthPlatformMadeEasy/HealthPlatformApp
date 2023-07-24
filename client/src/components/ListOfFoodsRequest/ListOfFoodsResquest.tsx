import React, {useEffect, useState} from 'react';
import {PencilIcon, PlusIcon, TrashIcon} from "@heroicons/react/24/outline";
import Modal from 'react-modal';
import Loading from "../Loading/Loading.tsx";
import axios from "axios";
import {useMutation} from "react-query";

type FoodItem = {
    id: number;
    food: string;
    quantity: number;
};

interface IData {
    sourceType: string;
    origSourceName: string;
    origUnit: string;
    origContent: number;
    standardContent: number;
}

interface IError {
    response?: { data: { message: string } };
}

const pushFoodData = async (list: FoodItem[]) => {
    const response = await axios.post(
        'https://localhost:7247/v1/api/foods/multiple',
        list,
        {headers: {'Content-Type': 'application/json'}}
    );
    return response.data;
}

const useSaveFoodData = () => {
    return useMutation(pushFoodData, {
            onError: (error: IError) => {
                console.log('Error: ', error.response?.data.message || error);
            },
            onSuccess: (data) => {
                return data;
            },
        }
    );
}


function ListOfFoods() {
    useEffect(() => {
        Modal.setAppElement('#root');
    }, []);

    const [form, setForm] = useState({food: "", quantity: 0});
    const [list, setList] = useState<FoodItem[]>([]);
    const [isEditing, setIsEditing] = useState(false);
    const [currentItem, setCurrentItem] = useState<FoodItem | null>(null);
    const [modalIsOpen, setModalIsOpen] = useState(false);
    const [data, setData] = useState<IData[] | null>(null);
    const [formData, setFormData] = useState(false);
    const [loading, setLoading] = useState(false);
    const [showData, setShowData] = useState(false);
    const mutation = useSaveFoodData();

    const handleSubmit = (e: React.FormEvent) => {
        e.preventDefault();
        if (!isEditing) {
            setList([...list, {...form, id: Date.now()}]);
            setForm({food: "", quantity: 0});
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
        setForm({food: item.food, quantity: item.quantity});
        setIsEditing(true);
        setCurrentItem(item);
        setModalIsOpen(true);
    };

    const callData = () => {
        setLoading(true)
        setFormData(true)

        mutation.mutateAsync(list)
            .then(response => {
                setData(response);
                setLoading(false);
                setShowData(true);
            })
            .catch(error => console.error(error))

    }


    return (
        <>
            {!formData &&
                <div className="grid w-1/3 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1 className="text-2xl font-bold mb-4">List of Food Items</h1>
                    <form onSubmit={handleSubmit} className="flex space-x-4">
                        <input
                            type="text"
                            required
                            value={form.food}
                            placeholder="Food"
                            onChange={(e) => setForm({...form, food: e.target.value})}
                            className="p-2 w-full border border-gray-200 rounded-md"
                        />
                        <input
                            type="number"
                            required
                            value={form.quantity}
                            placeholder="Quantity in grams"
                            onChange={(e) =>
                                setForm({...form, quantity: parseFloat(e.target.value)})
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
                                    <span className="font-bold text-lg">{item.food}</span>
                                    <span className="ml-6">{item.quantity}</span>
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
                                value={form.food}
                                onChange={(e) => setForm({...form, food: e.target.value})}
                                className="p-2 border border-gray-200 rounded-md"
                            />
                            <input
                                type="number"
                                required
                                value={form.quantity}
                                onChange={(e) =>
                                    setForm({...form, quantity: parseInt(e.target.value, 10)})
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
                    <div className="flex flex-col">
                        <div className="-my-2 overflow-x-auto sm:-mx-6 lg:-mx-8">
                            <div className="py-2 align-middle inline-block min-w-full sm:px-6 lg:px-8">
                                <div className="shadow overflow-hidden border-b border-gray-200 sm:rounded-lg">
                                    <table className="min-w-full divide-y divide-gray-200">
                                        <thead className="bg-gray-50">
                                        <tr>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                                Source Type
                                            </th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                                Original Source Name
                                            </th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                                Original Unit
                                            </th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                                Original Content
                                            </th>
                                            <th className="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">
                                                Standard Content
                                            </th>
                                        </tr>
                                        </thead>
                                        <tbody className="bg-white divide-y divide-gray-200">
                                        {data?.map((row, index) => (
                                            <tr key={index}>
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    <div className="text-sm text-gray-900">{row.sourceType}</div>
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                                                    {row.origSourceName}
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    <div className="text-sm text-gray-900">{row.origUnit}</div>
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap">
                                                    <div className="text-sm text-gray-900">{row.origContent}</div>
                                                </td>
                                                <td className="px-6 py-4 whitespace-nowrap text-sm text-gray-500">
                                                    {row.standardContent}
                                                </td>
                                            </tr>
                                        ))}
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            }
        </>
    );
}

export default ListOfFoods;