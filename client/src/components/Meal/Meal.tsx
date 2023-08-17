﻿import axios from "axios";
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
} from "../../Model";
import { AddButton } from "../Buttons";
import { FoodItemRequestRow } from "../Tables";
import Fuse from "fuse.js";
import { listOfDbFoods } from "../../utils/ListOfDbFoods.ts";

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

const fuseOptions: Fuse.IFuseOptions<{ title: string }> = {
  keys: ["title"],
  includeMatches: true,
  threshold: 0.3,
};

const fuse = new Fuse(
  listOfDbFoods.map((food) => ({ title: food })),
  fuseOptions,
);

export function Meal(props: { loadChart: () => void }) {
  const [form, setForm] = useState({ FoodName: "", Quantity: 0 });
  const [list, setList] = useState<FoodItem[]>([]);
  const [isEditing, setIsEditing] = useState(false);
  const [currentItem, setCurrentItem] = useState<FoodItem | null>(null);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [data, setData] = useState<INorwegianFoodResponse[] | null>(null);
  const [loading, setLoading] = useState(false);
  const [showData, setShowData] = useState(false);
  const mutation = useSaveFoodData();
  const { userId } = useUserId();
  const [login, setLogin] = useState(false);
  const [showSearchItem, setShowSearchItem] = useState(false);
  const [results, setResults] = useState<Fuse.FuseResult<{ title: string }>[]>(
    [],
  );

  useEffect(() => {
    if (form.FoodName) {
      const searchResults = fuse.search(form.FoodName);
      setResults(searchResults);
    } else {
      setResults([]);
    }
  }, [form.FoodName]);

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
        props.loadChart();
      })
      .catch((error) => console.error(error));
  };

  return (
    <div>
      {login && (
        <div>
          <div className="grid rounded-xl border-2 border-pine_green-600 p-10">
            <h1 className="mb-4 font-playfair text-3xl font-light">
              List of Food Items
            </h1>
            <form
              onSubmit={handleSubmit}
              className="flex items-center justify-center space-x-2"
            >
              <div className="flex items-center justify-evenly gap-6">
                <div className="relative ">
                  <div>
                    <label
                      id="UserName"
                      className="text-sm font-medium leading-none text-gray-400"
                    >
                      Search for a food...
                    </label>
                    <input
                      type="text"
                      required
                      aria-labelledby="userName"
                      value={form.FoodName}
                      onChange={(e) => {
                        setForm({ ...form, FoodName: e.target.value });
                        if (e.target.value !== "") {
                          setShowSearchItem(true);
                        } else {
                          setShowSearchItem(false);
                        }
                      }}
                      className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
                    />
                  </div>
                  {showSearchItem && (
                    <ul className="absolute z-50 my-2 max-h-60 w-full overflow-auto rounded border-2 border-pine_green-600 bg-pine_green-800 py-1 pl-2 text-gray-300">
                      {results.map((result) => (
                        <li
                          key={result.item.title}
                          onClick={() => {
                            setForm({ ...form, FoodName: result.item.title });
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
                <div>
                  <label
                    id="UserName"
                    className="text-sm font-medium leading-none text-gray-400"
                  >
                    Quantity in g
                  </label>
                  <input
                    type="number"
                    required
                    value={form.Quantity}
                    aria-labelledby="userName"
                    onChange={(e) =>
                      setForm({ ...form, Quantity: parseFloat(e.target.value) })
                    }
                    className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
                  />
                </div>
                <div>
                  <AddButton />
                </div>
              </div>
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
                  color: "white",
                  top: "50%",
                  left: "50%",
                  right: "auto",
                  bottom: "auto",
                  marginRight: "-50%",
                  transform: "translate(-50%, -50%)",
                  backgroundColor: "#041613",
                  borderRadius: "0.75rem", // 6px
                  padding: "2rem", // 32px
                },
              }}
            >
              <h2 className="mb-4 font-playfair text-3xl font-bold">
                Update Food Item
              </h2>
              <form onSubmit={handleUpdate} className="grid grid-cols-2 gap-2">
                <div>
                  <label
                    id="UserName"
                    className="text-sm font-medium leading-none text-gray-400"
                  >
                    Search for a food...
                  </label>
                  <input
                    disabled={true}
                    type="text"
                    required
                    aria-labelledby="userName"
                    value={form.FoodName}
                    onChange={(e) => {
                      setForm({ ...form, FoodName: e.target.value });
                    }}
                    className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
                  />
                </div>
                <div>
                  <label
                    id="UserName"
                    className="text-sm font-medium leading-none text-gray-400"
                  >
                    Quantity in g
                  </label>
                  <input
                    type="number"
                    required
                    value={form.Quantity}
                    aria-labelledby="userName"
                    onChange={(e) =>
                      setForm({ ...form, Quantity: parseFloat(e.target.value) })
                    }
                    className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
                  />
                </div>
                <div className="col-span-2 mt-6 flex justify-end gap-8">
                  <button
                    onClick={() => setModalIsOpen(false)}
                    className="group relative flex h-12 transform items-center space-x-2 overflow-hidden rounded-full border-2 border-madder-600 px-6 transition duration-300 ease-in-out hover:scale-110"
                  >
                    <span className="text-m relative text-madder">Cancel</span>
                  </button>
                  <button
                    type="submit"
                    className="group relative flex h-12 transform items-center space-x-2 overflow-hidden rounded-full border-2 border-marian_blue px-6 transition duration-300 ease-in-out hover:scale-110"
                  >
                    <span className="text-m relative text-marian_blue-300">
                      Submit
                    </span>
                  </button>
                </div>
              </form>
            </Modal>
            <button
              onClick={callData}
              className="group relative mx-auto mt-10 flex h-12 transform items-center overflow-hidden rounded-full border-2 border-marian_blue px-6 transition duration-300 ease-in-out hover:scale-110"
            >
              <span className="text-m relative text-marian_blue-200">
                Submit Meal
              </span>
            </button>
            {showData && (
              <div className="mt-8 rounded-xl border-2 border-pine_green-600">
                <button
                  onClick={() => setShowData(false)}
                  className="group relative mx-auto my-5 flex h-12 transform items-center overflow-hidden rounded-full border-2 border-marian_blue px-6 transition duration-300 ease-in-out hover:scale-110"
                >
                  <span className="text-m relative text-marian_blue-200">
                    Close
                  </span>
                </button>
                <div className="h-60 w-full overflow-auto">
                  {data && (
                    <div>
                      <table>
                        <thead>
                          <tr className="border border-pine_green-600 text-left text-xs font-semibold uppercase tracking-wide text-marian_blue-100">
                            <th>Property</th>
                            <th>Value</th>
                          </tr>
                        </thead>
                        <tbody className="">
                          {Object.entries<any>(data).map(([key, value]) => (
                            <tr
                              key={key}
                              className="border border-pine_green-600 text-gray-400"
                            >
                              <td>{key}</td>
                              <td>{value}</td>
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
          {loading && (
            <div className="m-auto w-full space-x-5 p-10">
              <Loading />
            </div>
          )}
        </div>
      )}
    </div>
  );
}
