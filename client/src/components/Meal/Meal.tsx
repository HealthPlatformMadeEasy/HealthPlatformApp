import {PencilIcon, PlusIcon, TrashIcon} from "@heroicons/react/24/outline";
import {useMutation, useQuery} from "@tanstack/react-query";
import Fuse from "fuse.js";
import React, {useEffect, useState} from "react";
import Modal from "react-modal";
import {pushFoodData} from "../../FetchFunctions/Axios";
import {useUserId} from "../../hooks";
import {queryClient} from "../../main.tsx";
import {Food, FoodItem, INorwegianFoodResponse, UserIdResponse,} from "../../Model";
import {listOfDbFoods} from "../../utils/ListOfDbFoods.ts";
import {Loading} from "../Loading";

interface IError {
  response?: { data: { message: string } };
}

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
  const [data, setData] = useState<INorwegianFoodResponse | null>(null);
  const [loading, setLoading] = useState(false);
  const [showData, setShowData] = useState(false);
  const mutation = useSaveFoodData();
  const { userId } = useUserId();
  const [login, setLogin] = useState(false);
  const [showSearchItem, setShowSearchItem] = useState(false);
  const [results, setResults] = useState<Fuse.FuseResult<{ title: string }>[]>(
    [],
  );

  const user: UserIdResponse | undefined = queryClient.getQueryData([
    "user-id",
  ]);

  const {
    data: meal,
    refetch: getMeal,
    isFetching,
    isSuccess,
    isError,
  } = useQuery(
      ["meal"],
      () => pushFoodData({userId: user?.userId, requests: list}),
      {enabled: false},
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
    const request: Food[] = [];
    list.forEach((row) =>
      request.fill({ FoodName: row.FoodName, Quantity: row.Quantity }),
    );

    getMeal().then((r) => {
      if (r.data === "") {
        alert("Food Not Found");
      }
    });

    if (isSuccess) {
      setShowData(true);
    }

    if (isError) {
      alert("Error, try again");
    }

    // mutation
    //   .mutateAsync({ userId: userId?.userId, requests: list })
    //   .then((response) => {
    //     setData(response);
    //     setLoading(false);
    //     setShowData(true);
    //     props.loadChart();
    //   })
    //   .catch((error) => console.error(error));
  };

  return (
    <div className="rounded-xl bg-pine_green-900">
      {login && (
        <div>
          <div className="grid rounded-xl border-2 border-pine_green-600">
            <div className="p-10">
              <h1 className="mb-4 font-playfair text-3xl font-light">Meal</h1>
              {!showData && (
                <form
                  onSubmit={handleSubmit}
                  className="flex items-center justify-center space-x-2"
                >
                  <div className="flex items-center justify-evenly gap-6">
                    <div className="relative">
                      <div>
                        <label
                          id="UserName"
                          className="text-sm font-medium leading-none text-gray-400"
                        >
                          Search
                        </label>
                        <input
                          type="text"
                          required
                          disabled={showData}
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
                        <ul className="absolute z-50 my-2 max-h-60 w-full overflow-auto rounded border-2 border-pine_green-600 bg-pine_green-800 p-2 text-gray-300">
                          {results.map((result) => (
                            <button
                              type="button"
                              key={result.item.title}
                              onClick={() => {
                                setForm({
                                  ...form,
                                  FoodName: result.item.title,
                                });
                                setShowSearchItem(false);
                              }}
                              className="m-1 w-full text-left hover:cursor-pointer"
                            >
                              {result.item.title}
                            </button>
                          ))}
                        </ul>
                      )}
                    </div>
                    <div className="w-60">
                      <label
                        id="UserName"
                        className="text-sm font-medium leading-none text-gray-400"
                      >
                        Quantity in grams
                      </label>
                      <input
                        type="number"
                        required
                        disabled={showData}
                        value={form.Quantity}
                        aria-labelledby="userName"
                        onChange={(e) =>
                          setForm({
                            ...form,
                            Quantity: parseFloat(e.target.value),
                          })
                        }
                        className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
                      />
                    </div>
                    <div>
                      <button
                        type="submit"
                        className="group mt-3 flex h-9 w-9 transform items-center justify-center rounded-full bg-marian_blue transition duration-300 ease-in-out hover:scale-125"
                      >
                        <PlusIcon className="h-6 w-6 text-white" />
                      </button>
                    </div>
                  </div>
                </form>
              )}
              <ul className="mt-8 space-y-4">
                {list.map((item) => (
                  <li
                    key={item.FoodName}
                    className="flex justify-between gap-4 border-b border-pine_green-100 p-1"
                  >
                    <div className="flex w-full items-center justify-between py-1 text-xl font-light leading-none text-gray-400">
                      <div>{item.FoodName}:</div>
                      <div>{item.Quantity} g.</div>
                    </div>
                    <div className="flex items-center justify-between">
                      {!showData && (
                        <div className="grid grid-cols-2 gap-4">
                          <button
                            onClick={() => handleEdit(item)}
                            className="group mx-1 flex h-9 w-9 transform items-center justify-center rounded-full bg-hunyadi_yellow transition duration-300 ease-in-out hover:scale-125"
                          >
                            <PencilIcon className="h-5 w-5 text-pine_green-900" />
                          </button>
                          <button
                            onClick={() => handleDelete(item.id)}
                            className="group mx-1 flex h-9  w-9 transform items-center justify-center rounded-full bg-madder transition duration-300 ease-in-out hover:scale-125"
                          >
                            <TrashIcon className="h-5 w-5 text-white" />
                          </button>
                        </div>
                      )}
                    </div>
                  </li>
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
                <form
                  onSubmit={handleUpdate}
                  className="grid grid-cols-2 gap-2"
                >
                  <div>
                    <label
                      id="UserName"
                      className="text-sm font-medium leading-none text-gray-400"
                    >
                      Food
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
                      Quantity in grams
                    </label>
                    <input
                      type="number"
                      required
                      value={form.Quantity}
                      aria-labelledby="userName"
                      onChange={(e) =>
                        setForm({
                          ...form,
                          Quantity: parseFloat(e.target.value),
                        })
                      }
                      className="mt-2 w-full appearance-none border-b border-pine_green-100 bg-transparent px-2 py-1 leading-tight text-gray-100 focus:outline-none"
                    />
                  </div>
                  <div className="col-span-2 mt-6 flex justify-end gap-8">
                    <button
                      onClick={() => setModalIsOpen(false)}
                      className="group flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-madder px-6 transition duration-300 ease-in-out hover:scale-125"
                    >
                      <span className="font-semibold text-white">Cancel</span>
                    </button>
                    <button
                      type="submit"
                      className="group flex h-12 transform items-center space-x-2 overflow-hidden rounded-full bg-marian_blue px-6 transition duration-300 ease-in-out hover:scale-125"
                    >
                      <span className="font-semibold text-white ">Update</span>
                    </button>
                  </div>
                </form>
              </Modal>
              {!showData && (
                <button
                  onClick={callData}
                  className="group mx-auto mt-10 flex h-12 transform items-center overflow-hidden rounded-full bg-marian_blue px-6 transition duration-300 ease-in-out hover:scale-125"
                >
                  <span className="font-semibold text-white">Register</span>
                </button>
              )}
              {showData && (
                <button
                  onClick={() => {
                    setList([]);
                    setShowData(false);
                    setForm({ FoodName: "", Quantity: 0 });
                  }}
                  className="group mx-auto mt-10 flex h-12 transform items-center overflow-hidden rounded-full bg-marian_blue px-6 transition duration-300 ease-in-out hover:scale-125"
                >
                  <span className="font-semibold text-white">New Meal</span>
                </button>
              )}
            </div>
            {showData && (
              <div className=" border-t border-pine_green-600">
                <div className="h-96 overflow-auto">
                  {isSuccess && (
                    <div>
                      <table className="w-full">
                        <thead className="sticky top-0 h-10 bg-pine_green-900">
                          <tr className="font-semibold uppercase tracking-wide text-marian_blue-100">
                            <th>Property</th>
                            <th>Value</th>
                          </tr>
                        </thead>
                        <tbody>
                        {Object.entries<any>(meal).map(([key, value]) => (
                            <tr
                              key={key}
                              className="border-t border-pine_green-600 text-center text-gray-400"
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
          {isFetching && (
            <div className="m-auto w-full space-x-5 p-10">
              <Loading />
            </div>
          )}
        </div>
      )}
    </div>
  );
}
