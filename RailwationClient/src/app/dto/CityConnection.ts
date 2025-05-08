import { City } from "./City";

export interface CityConnection {
    fromCityId: string,
    fromCity: City,
    toCityId: string,
    toCity: City,
    isPassenger: boolean,
    isFreight: boolean,
    frequencyPerWeek: number,
}