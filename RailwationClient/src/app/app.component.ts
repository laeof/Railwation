import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ApiService } from './service/api.service';
import { CityService } from './service/city.service';
import { ConnectionService } from './service/connection.service';
import { CountryService } from './service/country.service';
import { IntegrationService } from './service/integration.service';
import { HeaderComponent } from './components/header/header.component';

@Component({
    selector: 'app-root',
    imports: [RouterOutlet, HeaderComponent],
    providers: [ApiService, CityService, ConnectionService, CountryService, IntegrationService],
    templateUrl: './app.component.html',
    styleUrl: './app.component.scss'
})
export class AppComponent {
    title = 'RailwationClient';
}
