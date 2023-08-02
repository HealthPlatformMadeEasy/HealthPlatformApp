import {useEffect, useState} from "react";
import {VictoryBar, VictoryChart, VictoryStack, VictoryTheme} from "victory";
import {useUserId} from "../../hooks";
import {GetMacrosAndEnergy} from "../Fetch";


interface IUserContent {
    sourceType: string,
    origUnit: string,
    origSourceName: string,
    origContent: number,
    standardContent: number,
    createdAt: Date,
    userId: string
}

interface IMacrosAndEnergy {
    carbs: IUserContent[],
    proteins: IUserContent[],
    fats: IUserContent[],
    energy: IUserContent[]
}

export function UserContentCharts() {
    const [data, setData] = useState<IMacrosAndEnergy | undefined>()
    const {userId} = useUserId();

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

    console.log("data charts" + JSON.stringify(data));

    return (

        <>
            <p>userId: {userId?.userId}</p>
            <h1 className="text-2xl font-extrabold text-pink-700">Energy</h1>
            <VictoryChart name='Carbs'
                          theme={VictoryTheme.material}
            >

                <VictoryStack>
                    <VictoryBar name="carbs"
                                colorScale='warm'
                                data={data?.energy.map(row => {
                                    return {x: row.createdAt, y: row.origContent}
                                })}
                    />
                </VictoryStack>
            </VictoryChart>

            <h1 className="text-2xl font-extrabold text-pink-700">Carbs</h1>
            <VictoryChart name='Carbs'
                          theme={VictoryTheme.material}
            >

                <VictoryStack>
                    <VictoryBar name="carbs"
                                colorScale='heatmap'
                                data={data?.carbs.map(row => {
                                    return {x: row.createdAt, y: row.origContent}
                                })}
                    />
                </VictoryStack>
            </VictoryChart>

            <h1 className="text-2xl font-extrabold text-pink-700">Fats</h1>
            <VictoryChart
                theme={VictoryTheme.material}
            >
                <VictoryStack>
                    <VictoryBar name="fats"
                                colorScale='qualitative'
                                data={data?.fats.map(row => {
                                    return {x: row.createdAt, y: row.origContent}
                                })}
                    />
                </VictoryStack>
            </VictoryChart>

            <h1 className="text-2xl font-extrabold text-pink-700">Protein</h1>
            <VictoryChart
                theme={VictoryTheme.material}
            >
                <VictoryStack>
                    <VictoryBar name="protein"
                                colorScale='red'
                                data={data?.proteins.map(row => {
                                    return {x: row.createdAt, y: row.origContent}
                                })}
                    />
                </VictoryStack>
            </VictoryChart>
        </>
    );
}