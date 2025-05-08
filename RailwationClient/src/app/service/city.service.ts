import { HttpClient } from "@angular/common/http";
import { Observable } from "rxjs";
import { City } from "../dto/City";
import { ApiService } from "./api.service";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })

export class CityService {
    constructor(private http: HttpClient,
        private apiService: ApiService
    ) { }

    getAll(): Observable<City[]> {
        return this.http.get<City[]>(this.apiService.getApiUrl() + "City");
    }

    getId(id: string): Observable<City[]> {
        return this.http.get<City[]>(this.apiService.getApiUrl() + "City/by-country/" + id);
    }

    create(country: City): Observable<City> {
        return this.http.post<City>(this.apiService.getApiUrl() + "City", country);
    }
}