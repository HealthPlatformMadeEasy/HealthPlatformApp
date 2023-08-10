export interface IEnergyDto {
  createdAt: Date;
  kilokalorierKcal: number;
}

export interface ICarbDto {
  createdAt: Date;
  karbohydrat: number;
}

export interface IFatDto {
  createdAt: Date;
  fett: number;
}

export interface IProteinDto {
  createdAt: Date;
  protein: number;
}

export interface IGenericMacroDataChart {
  createdAt: Date;
  value: number;
}

export interface IEnergyAndMacros {
  energyDtos: IEnergyDto[];
  carbDtos: ICarbDto[];
  fatDtos: IFatDto[];
  proteinDtos: IProteinDto[];
}

export interface ChartRowData {
  createdAt: Date;
  kilokalorierKcal: number;
}
