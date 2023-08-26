import {useQuery} from "@tanstack/react-query";
import React, {useEffect, useState} from "react";
import {useNavigate} from "react-router-dom";
import {CreateUser} from "../../FetchFunctions/Axios";
import {useUserId} from "../../hooks";
import {CancelBackPreviousRouteButton} from "../Buttons";
import {Loading} from "../Loading";

export function SignUpForm() {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [repeatPassword, setRepeatPassword] = useState("");
  const { setUserId } = useUserId();
  const navigate = useNavigate();

  const {
    data,
    isSuccess,
    isRefetching,
    isError,
    refetch: createUser,
  } = useQuery(
    ["user-id"],
    () => CreateUser({ name: username, email: email, password: password }),
    {
      enabled: false,
      retry: false,
    },
  );

  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    if (password !== repeatPassword) {
      alert("Passwords must match.");
      return;
    }

    if (
      !RegExp(/^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d@$!%*#?&]{8,}$/).exec(password)
    ) {
      alert(
        "Password should be minimum eight characters, at least one letter and one number",
      );
      return;
    }

    createUser();

    //TODO remove when finish with react-query
    setUserId({ userId: data?.userId });
  };

  if (isError) {
    alert("An Error happened, please try again");
  }

  useEffect(() => {
    if (isSuccess) return navigate("/food");
  }, [isSuccess]);

  if (isRefetching) {
    setTimeout(() => {}, 300);
    return <Loading />;
  }

  return (
    <>
      {!isRefetching && (
        <form onSubmit={handleSubmit} className="mb-4 px-8 pb-8 pt-6">
          <div className="w-1/3 rounded-xl border-2 border-pine_green-600 bg-pine_green-900 p-10">
            <p className="mb-4 font-playfair text-3xl leading-6 text-gray-200 focus:outline-none">
              Created Account
            </p>
            <div>
              <label
                id="UserName"
                className="text-sm leading-none text-gray-400"
              >
                Name
              </label>
              <input
                onChange={(e) => setUsername(e.target.value)}
                value={username}
                aria-labelledby="userName"
                type="userName"
                className="mt-2 w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
              />
            </div>
            <div>
              <label id="email" className="text-sm leading-none text-gray-400">
                Email
              </label>
              <input
                onChange={(e) => setEmail(e.target.value)}
                value={email}
                aria-labelledby="email"
                type="email"
                className="mt-2 w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
              />
            </div>
            <div className="mt-6  w-full">
              <label className="text-sm leading-none text-gray-400">
                Password
              </label>
              <div className="relative flex items-center justify-center">
                <input
                  onChange={(e) => setPassword(e.target.value)}
                  value={password}
                  id="pass"
                  type="password"
                  className="mt-2 w-full rounded-full border bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
                />
              </div>
            </div>
            <div className="mt-6  w-full">
              <label className="text-sm leading-none text-gray-400">
                Repeat Password
              </label>
              <div className="relative flex items-center justify-center">
                <input
                  onChange={(e) => setRepeatPassword(e.target.value)}
                  value={repeatPassword}
                  id="pass"
                  type="password"
                  className="mt-2 w-full rounded-full bg-tea_green-100 py-3 pl-3 text-xs font-medium leading-none text-gray-800"
                />
              </div>
            </div>
            <div className="mt-8 flex items-center justify-around">
              <CancelBackPreviousRouteButton />
              <button
                type="submit"
                className="flex h-12 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-tea_green px-6 font-semibold text-pine_green-900 transition duration-300 ease-in-out hover:scale-125"
              >
                Sign In
              </button>
            </div>
          </div>
        </form>
      )}
    </>
  );
}
