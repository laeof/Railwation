import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { City } from 'src/app/dto/City';
import { Country } from 'src/app/dto/Country';
import { CityService } from 'src/app/service/city.service';
import { CountryService } from 'src/app/service/country.service';
import { CitylistComponent } from "../citylist/citylist.component";

@Component({
    selector: 'app-city',
    imports: [ReactiveFormsModule, CommonModule, MatSelectModule, CitylistComponent],
    templateUrl: './city.component.html',
    styleUrl: './city.component.scss'
})
export class CityComponent {
    countries: Country[] = []
    cities: City[] = []

    cityForm: FormGroup = new FormGroup({
        name: new FormControl(''),
        countryId: new FormControl('')
    });

    /**
     *
     */
    constructor(private countryService: CountryService, private cityService: CityService) {
        this.countryService.getAll().subscribe((value: Country[]) => {
            if (!value)
                return

            this.countries = value;
        })

        this.cityService.getAll().subscribe((value: City[]) => {
            if (!value)
                return

            this.cities = value;
        })
    }

    createCity() {

        return this.cityService.create({ id: '00000000-0000-0000-0000-000000000000', photoUrl: '', countryId: this.cityForm.value.countryId, name: this.cityForm.value.name }).subscribe(
            value => window.location.href = '/cities'
        );
    }
}
