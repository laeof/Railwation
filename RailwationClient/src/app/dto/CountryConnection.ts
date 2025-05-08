import { Country } from "./Country";

export interface CountryConnection {
    fromCountryId: string,
    fromCountry: Country,
    toCountryId: string,
    toCountry: Country,
    hasPassengerService: boolean,
    hasFreightService: boolean,
    weeklyFrequency: number,
    logisticsScore: number,
}