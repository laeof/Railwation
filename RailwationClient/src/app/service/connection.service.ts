import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Country } from "../dto/Country";
import { ApiService } from "./api.service";
import { CityConnection } from "../dto/CityConnection";
import { BorderCrossing } from "../dto/BorderCrossing";
import { CountryConnection } from "../dto/CountryConnection";

@Injectable({ providedIn: 'root' })

export class ConnectionService {
    constructor(private http: HttpClient,
        private apiService: ApiService
    ) { }

    getCountryConnections(): Observable<CountryConnection[]> {
        return this.http.get<CountryConnection[]>(this.apiService.getApiUrl() + "Connection/country");
    }

    getCityConnections(): Observable<CityConnection[]> {
        return this.http.get<CityConnection[]>(this.apiService.getApiUrl() + "Connection/city");
    }

    getCityConnectionsByCountryId(id: string): Observable<CityConnection[]> {
        return this.http.get<CityConnection[]>(this.apiService.getApiUrl() + "Connection/city/by-country/" + id);
    }

    createCityConnections(connection: CityConnection): Observable<CityConnection> {
        return this.http.post<CityConnection>(this.apiService.getApiUrl() + "Connection/city/create", connection);
    }

    getCountryConnectionsByCountryId(id: string): Observable<CountryConnection[]> {
        return this.http.get<CountryConnection[]>(this.apiService.getApiUrl() + "Connection/country/by-country/" + id);
    }

    createCountryConnections(connection: CountryConnection): Observable<CountryConnection> {
        return this.http.post<CountryConnection>(this.apiService.getApiUrl() + "Connection/country/create", connection);
    }

    getBorderCrossingByCountryId(id: string): Observable<BorderCrossing[]> {
        return this.http.get<BorderCrossing[]>(this.apiService.getApiUrl() + "BorderCrossing/country/by-country/" + id);
    }

    getBorderCrossings(): Observable<BorderCrossing[]> {
        return this.http.get<BorderCrossing[]>(this.apiService.getApiUrl() + "BorderCrossing");
    }

    createBorderCrossing(connection: BorderCrossing): Observable<BorderCrossing> {
        return this.http.post<BorderCrossing>(this.apiService.getApiUrl() + "BorderCrossing", connection);
    }
}