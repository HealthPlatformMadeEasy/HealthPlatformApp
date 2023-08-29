import Fuse from "fuse.js";
import React, { useEffect, useState } from "react";
import { queryClient } from "../../main.tsx";
import { Food, FoodItem, UserIdResponse } from "../../Model";
import { fuse } from "../../utils";
import { Loading } from "../Loading";
import { useRegisterMeal } from "../../hooks";
import { NutrientTable } from "./NutrientTable";
import { MealList } from "./MealList.tsx";
import { MealFrom } from "./MealForm.tsx";

export function Meal(props: { loadChart: () => void }) {
  const [form, setForm] = useState({ FoodName: "", Quantity: 0 });
  const [list, setList] = useState<FoodItem[]>([]);
  const [isEditing, setIsEditing] = useState(false);
  const [currentItem, setCurrentItem] = useState<FoodItem | null>(null);
  const [modalIsOpen, setModalIsOpen] = useState(false);
  const [showData, setShowData] = useState(false);
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
  } = useRegisterMeal({ userId: user?.userId, requests: list });

  useEffect(() => {
    if (form.FoodName) {
      const searchResults = fuse.search(form.FoodName);
      setResults(searchResults);
    } else {
      setResults([]);
    }
  }, [form.FoodName]);

  useEffect(() => {
    if (user?.userId !== undefined) {
      setLogin(true);
    }
  }, [user?.userId]);

  function SetFormProps(meal: { FoodName: string; Quantity: number }) {
    setForm({ ...form, FoodName: meal.FoodName });
  }

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
      setForm({ FoodName: "", Quantity: 0 });
    }
  };

  const handleDelete = (id: number) => {
    setList(list.filter((item) => item.id !== id));
    setForm({ FoodName: "", Quantity: 0 });
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

    getMeal().then(() => {
      props.loadChart();
      setShowData(true);
    });

    if (isError) {
      alert("Error, try again");
    }
  };

  return (
    <div className="rounded-xl border-2 border-pine_green-600 bg-pine_green-900">
      {login && (
        <div>
          <div className="grid">
            <div className="p-10">
              <h1 className="mb-4 font-playfair text-3xl font-light">Meal</h1>
              {!showData && (
                <MealFrom
                  onSubmit={handleSubmit}
                  disabled={showData}
                  form={form}
                  onChangeFoodName={(e) => {
                    setForm({ ...form, FoodName: e.target.value });
                    if (e.target.value !== "") {
                      setShowSearchItem(true);
                    } else {
                      setShowSearchItem(false);
                    }
                  }}
                  onChangeQuantity={(e) =>
                    setForm({
                      ...form,
                      Quantity: parseFloat(e.target.value),
                    })
                  }
                  SetFormProps={SetFormProps}
                  Results={results}
                  SetShowSearchItems={() => setShowSearchItem(false)}
                  showSearchItems={showSearchItem}
                />
              )}
              <MealList
                FoodItems={list}
                ShowData={showData}
                HandleEdit={handleEdit}
                HandleDelete={handleDelete}
                open={modalIsOpen}
                onRequestClose={() => setModalIsOpen(false)}
                onSubmit={handleUpdate}
                form={form}
                onChangeFoodName={(e) => {
                  setForm({ ...form, FoodName: e.target.value });
                }}
                onChangeQuantity={(e) =>
                  setForm({
                    ...form,
                    Quantity: parseFloat(e.target.value),
                  })
                }
              />
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
                  {isSuccess && <NutrientTable meals={meal} />}
                </div>
              </div>
            )}
          </div>
          {isFetching && (
            <div className="m-auto flex w-full items-center justify-center space-x-5 p-10">
              <Loading />
            </div>
          )}
        </div>
      )}
    </div>
  );
}
