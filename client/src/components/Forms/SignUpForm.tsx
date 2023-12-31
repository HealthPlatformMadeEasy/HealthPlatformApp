﻿import React, { useEffect, useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import { Loading } from "../Loading";
import { queryClient } from "../../main.tsx";
import { useSignUp } from "../../hooks";

export function SignUpForm() {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [repeatPassword, setRepeatPassword] = useState("");
  const navigate = useNavigate();

  const {
    isSuccess,
    isFetching,
    isError,
    refetch: createUser,
  } = useSignUp({ name: username, email: email, password: password });

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
  };

  useEffect(() => {
    if (isError) {
      alert("An Error happened, please try again");
    }
  }, [isError]);

  useEffect(() => {
    if (isSuccess) return navigate("/food");
  }, [isSuccess]);

  return (
    <>
      <form onSubmit={handleSubmit} className="mb-4 px-8 pb-8 pt-6">
        <div className="rounded-xl border-2 border-pine_green-600 bg-pine_green-900 p-10 md:w-1/2 lg:w-1/3">
          <p className="mb-4 font-playfair text-3xl leading-6 text-gray-200 focus:outline-none">
            Created Account
          </p>
          <div>
            <label id="UserName" className="text-sm leading-none text-gray-400">
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
            <Link
              to="/"
              onClick={() => queryClient.removeQueries(["user-id"])}
              className="flex h-12 w-24 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-madder px-6 font-semibold text-white transition duration-300 ease-in-out hover:scale-125"
            >
              Cancel
            </Link>
            <button
              type="submit"
              className="flex h-12 transform items-center justify-center space-x-2 overflow-hidden rounded-full bg-tea_green px-6 font-semibold text-pine_green-900 transition duration-300 ease-in-out hover:scale-125"
            >
              Sign In
            </button>
          </div>
        </div>
      </form>
      {isFetching && (
        <div className="px-8 pb-8">
          <Loading />
        </div>
      )}
    </>
  );
}
