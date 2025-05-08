import { Injectable } from "@angular/core";

@Injectable({ providedIn: 'root' })

export class ApiService {
    private apiUrl = 'http://localhost:5185/';

    getApiUrl() {
        return this.apiUrl;
    }
}