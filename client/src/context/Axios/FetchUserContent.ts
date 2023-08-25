﻿import axios from "axios";

export async function GetMacrosAndEnergy(id: string | undefined) {
  const { data } = await axios.get(
    `${import.meta.env.VITE_BASE_URL}/api/nutrients/energy-macros/${id}`,
    {
      headers: {
        Accept: "application/json",
      },
    },
  );
  return data;
}

export async function GetMacrosAndEnergy1(id: string | undefined) {
  const { data } = await axios
    .get(`${import.meta.env.VITE_BASE_URL}/api/nutrients/energy-macros/${id}`, {
      headers: {
        Accept: "application/json",
      },
    })
    .then((response) => response.data);
  return data;
}
