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

interface IChartDate {
    x: Date,
    y: number
}

export function UserContentCharts() {
    const [data, setData] = useState<IMacrosAndEnergy | undefined>()
    const {userId} = useUserId();

    useEffect(() => {
        if (userId === undefined) {
            return
        }
        const test = () => {
            GetMacrosAndEnergy(userId?.userId)
                .then(data => setData(data));
        }

        test();
    }, [userId])

    let carbs: IChartDate[] | undefined = data?.carbs.map(row => {
        return {x: row.createdAt, y: row.origContent}
    })
    let protein: IChartDate[] | undefined = data?.proteins.map(row => {
        return {x: row.createdAt, y: row.origContent}
    })
    let fats: IChartDate[] | undefined = data?.fats.map(row => {
        return {x: row.createdAt, y: row.origContent}
    })


    console.log(JSON.stringify(data));

    return (
        <>
            <h1>Carbs</h1>
            <VictoryChart name='Carbs'
                          theme={VictoryTheme.material}
            >

                <VictoryStack>
                    <VictoryBar name="carbs"
                                colorScale='heatmap'
                                data={carbs}
                    />
                </VictoryStack>
            </VictoryChart>
            <h1>Fats</h1>
            <VictoryChart
                theme={VictoryTheme.material}
            >
                <VictoryStack>
                    <VictoryBar name="fats"
                                colorScale='qualitative'
                                data={fats}
                    />
                </VictoryStack>
            </VictoryChart>
            <h1>Protein</h1>
            <VictoryChart
                theme={VictoryTheme.material}
            >
                <VictoryStack>
                    <VictoryBar name="protein"
                                colorScale='red'
                                data={protein}
                    />
                </VictoryStack>
            </VictoryChart>
        </>
    );
}