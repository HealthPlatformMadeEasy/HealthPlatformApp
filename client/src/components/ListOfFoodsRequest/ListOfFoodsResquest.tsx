import axios from "axios";
import React, { useEffect, useState } from "react";
import Modal from "react-modal";
import { useMutation } from "react-query";
import { useUserId } from "../../hooks";
import { Loading } from "../Loading";
import {
  Food,
  FoodItem,
  FoodRequest,
  INorwegianFoodResponse,
} from "../../types";
import { AddButton } from "../Buttons";
import { FoodItemRequestRow } from "../Tables";

interface IError {
  response?: { data: { message: string } };
}

const pushFoodData = async (request: FoodRequest | undefined) => {
  const response = await axios.post(
    "https://localhost:7247/api/norwegianfoods/getnutrientcalculationforuser",
    request,
    { headers: { "Content-Type": "application/json" } },
  );
  return response.data;
};

const useSaveFoodData = () => {
  return useMutation(pushFoodData, {
    onError: (error: IError) => {
      console.log("Error: ", error.response?.data.message ?? error);
    },
    onSuccess: (data) => {
      return data;
    },
  });
};

export function ListOfFoods() {
  const [form, setForm] = useState({ FoodName: "", Quantity: 0 });
  const [list, setList] = useState<FoodItem[]>([]);
  const [isEditing, setIsEditing] = useState(false);
  const [currentItem, setCurrentItem] = useState<FoodItem | null>(null);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [data, setData] = useState<INorwegianFoodResponse[] | null>(null);
  const [formData, setFormData] = useState(false);
  const [loading, setLoading] = useState(false);
  const [showData, setShowData] = useState(false);
  const mutation = useSaveFoodData();
  const { userId } = useUserId();
  const [login, setLogin] = useState(false);

  useEffect(() => {
    if (userId !== null) {
      setLogin(true);
    }
  }, [userId]);

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    if (!isEditing) {
      setList([...list, { ...form, id: Date.now() }]);
      setForm({ FoodName: "", Quantity: 0 });
    }
  };

  const handleUpdate = (e: React.FormEvent) => {
    e.preventDefault();
    if (isEditing && currentItem) {
      const updatedItem = { ...currentItem, ...form };
      setList(
        list.map((item) => (item.id === updatedItem.id ? updatedItem : item)),
      );
      setIsEditing(false);
      setCurrentItem(null);
      setModalIsOpen(false);
    }
  };

  const handleDelete = (id: number) => {
    setList(list.filter((item) => item.id !== id));
  };

  const handleEdit = (item: FoodItem) => {
    setForm({ FoodName: item.FoodName, Quantity: item.Quantity });
    setIsEditing(true);
    setCurrentItem(item);
    setModalIsOpen(true);
  };

  const callData = () => {
    setLoading(true);
    setFormData(true);

    const request: Food[] = [];
    list.forEach((row) =>
      request.fill({ FoodName: row.FoodName, Quantity: row.Quantity }),
    );

    mutation
      .mutateAsync({ userId: userId?.userId, requests: list })
      .then((response) => {
        setData(response);
        setLoading(false);
        setShowData(true);
      })
      .catch((error) => console.error(error));
  };

  return (
    <div>
      {login && (
        <div>
          {!formData && (
            <div className="grid bg-white p-10">
              <h1 className="mb-4 text-2xl font-bold">List of Food Items</h1>
              <form
                onSubmit={handleSubmit}
                className="flex items-center justify-center space-x-2"
              >
                <input
                  type="text"
                  required
                  value={form.FoodName}
                  placeholder="Food"
                  onChange={(e) =>
                    setForm({ ...form, FoodName: e.target.value })
                  }
                  className="w-5/12 rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
                />
                <input
                  type="number"
                  required
                  value={form.Quantity}
                  placeholder="Quantity in grams"
                  onChange={(e) =>
                    setForm({ ...form, Quantity: parseFloat(e.target.value) })
                  }
                  className="w-5/12 rounded-full border bg-tea_green-100 px-3 py-3 text-xs font-medium leading-none text-gray-800"
                />
                <AddButton />
              </form>
              <ul className="mt-8 space-y-4">
                {list.map((item) => (
                  <FoodItemRequestRow
                    key={item.id}
                    item={item}
                    onClick={() => handleEdit(item)}
                    onClick1={() => handleDelete(item.id)}
                  />
                ))}
              </ul>
              <Modal
                isOpen={modalIsOpen}
                onRequestClose={() => setModalIsOpen(false)}
                style={{
                  overlay: {
                    backgroundColor: "rgba(0, 0, 0, 0.5)",
                  },
                  content: {
                    top: "50%",
                    left: "50%",
                    right: "auto",
                    bottom: "auto",
                    marginRight: "-50%",
                    transform: "translate(-50%, -50%)",
                    backgroundColor: "white",
                    borderRadius: "0.375rem", // 6px
                    padding: "2rem", // 32px
                  },
                }}
              >
                <h2 className="mb-4 text-2xl font-bold">Update Food Item</h2>
                <form
                  onSubmit={handleUpdate}
                  className="grid grid-cols-2 gap-2"
                >
                  <input
                    type="text"
                    required
                    value={form.FoodName}
                    onChange={(e) =>
                      setForm({ ...form, FoodName: e.target.value })
                    }
                    className="w-full rounded-full border bg-tea_green-100 px-3 py-2 text-xs font-medium leading-none text-gray-800"
                  />
                  <input
                    type="number"
                    required
                    value={form.Quantity}
                    onChange={(e) =>
                      setForm({
                        ...form,
                        Quantity: parseInt(e.target.value, 10),
                      })
                    }
                    className="w-full rounded-full border bg-tea_green-100 px-3 py-2 text-xs font-medium leading-none text-gray-800"
                  />
                  <div className="col-span-2 flex justify-end gap-2">
                    <button
                      onClick={() => setModalIsOpen(false)}
                      className="group relative flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-gradient-to-r from-madder-500 via-madder-600 to-madder-800 px-6 transition duration-300 ease-in-out hover:scale-110"
                    >
                      <span className="text-m relative text-white">Cancel</span>
                    </button>
                    <button
                      type="submit"
                      className="group relative flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out hover:scale-110"
                    >
                      <span className="text-m relative text-white">Submit</span>
                    </button>
                  </div>
                </form>
              </Modal>
              <button
                onClick={callData}
                className="group relative mx-auto mt-3 flex h-12 transform items-center overflow-hidden rounded-full bg-gradient-to-r from-marian_blue-400 via-marian_blue-500 to-marian_blue-800 px-6 transition duration-300 ease-in-out hover:scale-110"
              >
                <span className="text-m relative text-white">Call Data</span>
              </button>
            </div>
          )}
          {loading && (
            <div className="m-auto my-16 w-full space-x-5 bg-white p-10">
              <Loading />
            </div>
          )}
          {showData && (
            <div className="bg-white p-10">
              <button
                onClick={() => {
                  setFormData(false);
                  setShowData(false);
                }}
                className="mb-5 mt-5 w-full rounded border border-blue-500 bg-transparent px-4 py-2 font-semibold text-blue-700 hover:border-transparent hover:bg-blue-500 hover:text-white"
              >
                Again
              </button>
              <div className="shadow-xs h-96 w-full overflow-auto">
                {data && (
                  <div className="w-full overflow-x-auto">
                    <table className="whitespace-no-wrap w-full">
                      <thead>
                        <tr
                          className="border-b bg-gray-50 text-left text-xs font-semibold uppercase tracking-wide
                          text-gray-500"
                        >
                          <th className="px-4 py-3">Property</th>
                          <th className="px-4 py-3">Value</th>
                        </tr>
                      </thead>
                      <tbody className="divide-y bg-white">
                        {Object.entries<any>(data).map(([key, value]) => (
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
          )}
        </div>
      )}
    </div>
  );
}
