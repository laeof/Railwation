import { Country } from "./Country";

export interface BorderCrossing {
    countryAId: string,
    countryA: Country,
    countryBId: string,
    countryB: Country,
    hasRailway: boolean,
}