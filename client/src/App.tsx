import './App.css'
import CalorieCalculator from "./components/CalorieCalculator/CalorieCalculator.tsx";

const data = {"calories": 250}

function App() {

    const foodSummaryFeature = false;

    return (
        <>
            < CalorieCalculator/>
            {foodSummaryFeature??
            <div>
                <pre>
                    {JSON.stringify(data, null, 2)}
                </pre>
            </div>
            }
        </>
    )
}

export default App;
