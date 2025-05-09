import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { CountryService } from '../../service/country.service';
import { Country } from '../../dto/Country';
import { CountryDetailsComponent } from "../country-details/country-details.component";
import { CityService } from 'src/app/service/city.service';
import { City } from 'src/app/dto/City';

@Component({
    selector: 'app-country',
    imports: [ReactiveFormsModule, CommonModule, CountryDetailsComponent],
    templateUrl: './country.component.html',
    styleUrl: './country.component.scss'
})
export class CountryComponent {
    countries: Country[] = []

    selectedCountry: Country | undefined = undefined;
    cities: City[] = []

    countryForm: FormGroup = new FormGroup({
        name: new FormControl(''),
        photoUrl: new FormControl(''),
    });

    constructor(private countryService: CountryService,
        private cityService: CityService
    ) {
        this.countryService.getAll().subscribe(
            (countries: Country[]) => {
                if (!countries)
                    return;

                this.countries = countries;
            }
        )
    }

    addCountry() {
        return this.countryService.create({
            name: this.countryForm.value.name,
            photoUrl: this.countryForm.value.photoUrl,
        }).subscribe(
            value => window.location.href = '/countries'
        );
    }

    selectCountry(country: Country) {
        this.selectedCountry = country;
        this.cityService.getId(country.id).subscribe(
            (value: City[]) => {
                if (!value)
                    return;

                this.cities = value;
            }
        )
    }
}
