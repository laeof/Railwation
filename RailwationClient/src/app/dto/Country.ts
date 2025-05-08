import { BorderCrossing } from "./BorderCrossing";
import { CountryConnection } from "./CountryConnection";

export interface Country {
    id: string,
    name: string,
    photoUrl: string,
    fromCountryConnections: CountryConnection[],
    toCountryConnections: CountryConnection[],
    borderCrossingsAsA: BorderCrossing[],
    borderCrossingsAsB: BorderCrossing[],
}