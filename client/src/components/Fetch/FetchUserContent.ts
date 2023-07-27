import axios from "axios";

export async function GetMacrosAndEnergy(id: string | undefined) {
    const {data} = await axios.get(`https://localhost:7247/v1/api/userscontent/get-macros-and-energy/${id}`, {
        headers: {
            Accept: 'application/json',
        },
    });
    return data;
}