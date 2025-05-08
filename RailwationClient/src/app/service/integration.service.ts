import { Observable } from "rxjs";
import { Integrations } from "../dto/Integrations";
import { HttpClient } from "@angular/common/http";
import { ApiService } from "./api.service";
import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })

export class IntegrationService {
    constructor(private http: HttpClient,
        private apiService: ApiService
    ) { }

    getIntegrations(id: string) : Observable<Integrations>{
        return this.http.get<Integrations>(this.apiService.getApiUrl() + "IntegrationScore/" + id);
    }
}