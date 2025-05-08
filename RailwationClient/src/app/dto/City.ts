import { CityConnection } from "./CityConnection";
import { Country } from "./Country";

export interface City {
    id: string,
    name: string,
    countryId: string,
    country: Country,
    fromCityConnections: CityConnection[],
    toCityConnections: CityConnection[],
}