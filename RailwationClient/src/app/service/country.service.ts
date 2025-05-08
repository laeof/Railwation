import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Country } from "../dto/Country";
import { ApiService } from "./api.service";

@Injectable({ providedIn: 'root' })

export class CountryService {
    constructor(private http: HttpClient,
        private apiService: ApiService
    ) { }

    getAll(): Observable<Country[]> {
        return this.http.get<Country[]>(this.apiService.getApiUrl() + "Country");
    }

    getId(id: string): Observable<Country> {
        return this.http.get<Country>(this.apiService.getApiUrl() + "Country/" + id);
    }

    create(country: {name: string, photoUrl: string}): Observable<Country> {
        return this.http.post<Country>(this.apiService.getApiUrl() + "Country", country);
    }
}