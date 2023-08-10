export interface INorwegianFoodResponse {
    createdAt: string;
    spiseligDel: number;
    vann: number;
    kilojouleKJ: number;
    kilokalorierKcal: number;
    fett: number;
    mettet: number;
    c12_0g: number;
    c14_0: number;
    c16_0: number;
    c18_0: number;
    trans: number;
    enumettet: number;
    c16_1Sum: number;
    c18_1Sum: number;
    flerumettet: number;
    c18_2n_6: number;
    c18_3n_3: number;
    c20_3n_3: number;
    c20_3n_6: number;
    c20_4n_3: number;
    c20_4n_6: number;
    c20_5n_3_EPA: number;
    c22_5n_3_DPA: number;
    c22_6n_3_DHA: number;
    omega_3: number;
    omega_6: number;
    kolesterolMg: number;
    karbohydrat: number;
    stivelse: number;
    monoPlusDisakk: number;
    sukkerTilsatt: number;
    kostfiber: number;
    protein: number;
    salt: number;
    alkohol: number;
    vitaminARAE: number;
    retinolMug: number;
    betaKarotenMug: number;
    vitaminDMug: number;
    vitaminEAlfaTE: number;
    tiaminMg: number;
    riboflavinMg: number;
    niacinMg: number;
    vitaminB6Mg: number;
    folatMug: number;
    vitaminB12Mug: number;
    vitaminCMg: number;
    kalsiumMg: number;
    jernMg: number;
    natriumMg: number;
    kaliumMg: number;
    magnesiumMg: number;
    sinkMg: number;
    selenMug: number;
    kopperMg: number;
    fosforMg: number;
    jodMug: number;
}

export type FoodItem = {
    id: number;
    FoodName: string,
    Quantity: number
};
export type Food = {
    FoodName: string,
    Quantity: number
}
export type FoodRequest = {
    userId: string | undefined,
    requests: Food[]
}
