import axios from "axios";

export async function GetMacrosAndEnergy(id: string | undefined) {
    const {data} = await axios.get(`https://localhost:7247/api/nutrients/energy-macros/${id}`, {
        headers: {
            Accept: 'application/json',
        },
    });
    return data;
}