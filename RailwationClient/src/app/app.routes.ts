import { Routes } from '@angular/router';
import { CountryComponent } from './components/country/country.component';
import { CityComponent } from './components/city/city.component';
import { CityconnectionComponent } from './components/cityconnection/cityconnection.component';
import { CountryconnectionComponent } from './components/countryconnection/countryconnection.component';
import { BordercrossingComponent } from './components/bordercrossing/bordercrossing.component';

export const routes: Routes = [
    { path: '', redirectTo: "countries", pathMatch: "full" },
    { path: 'home', redirectTo: "countries", pathMatch: "full" },
    { path: 'countries', component: CountryComponent },
    { path: 'cities', component: CityComponent },
    { path: 'city-connections', component: CityconnectionComponent },
    { path: 'country-connections', component: CountryconnectionComponent },
    { path: 'border-crossings', component: BordercrossingComponent },
];
