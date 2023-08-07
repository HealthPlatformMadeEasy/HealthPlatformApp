import {useEffect, useState} from "react";
import {VictoryBar, VictoryChart, VictoryStack, VictoryTheme} from "victory";
import {GetMacrosAndEnergy} from "../../context/Fetch";
import {useUserId} from "../../hooks";


interface IEnergyDto {
    createdAt: Date,
    kilokalorierKcal: number
}

interface ICarbDto {
    createdAt: Date,
    karbohydrat: number
}

interface IFatDto {
    createdAt: Date,
    fett: number
}

interface IProteinDto {
    createdAt: Date,
    protein: number
}

interface IEnergyAndMacros {
    energyDtos: IEnergyDto[],
    carbDtos: ICarbDto[],
    fatDtos: IFatDto[],
    proteinDtos: IProteinDto[]
}

export function UserContentCharts() {
    const [data, setData] = useState<IEnergyAndMacros>({energyDtos: [], carbDtos: [], fatDtos: [], proteinDtos: []});
    const [isDataNotUndefined, setIsDataNotUndefined] = useState(false)
    const {userId} = useUserId();

    useEffect(() => {
        if (
            data.carbDtos.length !== 0 &&
            data.energyDtos.length !== 0 &&
            data.fatDtos.length !== 0 &&
            data.proteinDtos.length !== 0) setIsDataNotUndefined(true)

    }, [data]);

    useEffect(() => {
        if (typeof userId === undefined) {
            return
        }
        const getData = () => {
            GetMacrosAndEnergy(userId?.userId)
                .then(data => setData(data));
        }

        getData();

    }, [userId])

    return (

        <>
            <p>userId: {userId?.userId}</p>
            <h1 className="text-2xl font-extrabold text-pink-700">Energy</h1>
            {
                !isDataNotUndefined &&
                <div className="grid w-1/2 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1 className="text-5xl font-extrabold text-pink-700">No Content</h1>
                </div>
            }
            {
                isDataNotUndefined && <VictoryChart name='Energy'
                                                    theme={VictoryTheme.material}
                >

                    <VictoryStack>
                        <VictoryBar name="carbs"
                                    colorScale='warm'
                                    data={data?.energyDtos.map(row => {
                                        return {x: row.createdAt, y: row.kilokalorierKcal}
                                    })}
                        />
                    </VictoryStack>
                </VictoryChart>
            }

            <h1 className="text-2xl font-extrabold text-pink-700">Carbs</h1>
            {
                !isDataNotUndefined &&
                <div className="grid w-1/2 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1 className="text-5xl font-extrabold text-pink-700">No Content</h1>
                </div>
            }
            {
                isDataNotUndefined && <VictoryChart name='Carbs'
                                                    theme={VictoryTheme.material}
                >

                    <VictoryStack>
                        <VictoryBar name="carbs"
                                    colorScale='heatmap'
                                    data={data?.carbDtos.map(row => {
                                        return {x: row.createdAt, y: row.karbohydrat}
                                    })}
                        />
                    </VictoryStack>
                </VictoryChart>
            }

            <h1 className="text-2xl font-extrabold text-pink-700">Fats</h1>
            {
                !isDataNotUndefined &&
                <div className="grid w-1/2 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1 className="text-5xl font-extrabold text-pink-700">No Content</h1>
                </div>
            }
            {
                isDataNotUndefined && <VictoryChart
                    theme={VictoryTheme.material}
                >
                    <VictoryStack>
                        <VictoryBar name="fats"
                                    colorScale='qualitative'
                                    data={data?.fatDtos.map(row => {
                                        return {x: row.createdAt, y: row.fett}
                                    })}
                        />
                    </VictoryStack>
                </VictoryChart>
            }

            <h1 className="text-2xl font-extrabold text-pink-700">Protein</h1>
            {
                !isDataNotUndefined &&
                <div className="grid w-1/2 border border-solid p-10 border-blue-800 rounded-xl m-auto my-16">
                    <h1 className="text-5xl font-extrabold text-pink-700">No Content</h1>
                </div>
            }
            {
                isDataNotUndefined && <VictoryChart
                    theme={VictoryTheme.material}
                >
                    <VictoryStack>
                        <VictoryBar name="protein"
                                    colorScale='red'
                                    data={data?.proteinDtos.map(row => {
                                        return {x: row.createdAt, y: row.protein}
                                    })}
                        />
                    </VictoryStack>
                </VictoryChart>
            }
        </>
    );
}
