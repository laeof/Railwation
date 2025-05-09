import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { City } from 'src/app/dto/City';
import { CityConnection } from 'src/app/dto/CityConnection';
import { CityService } from 'src/app/service/city.service';
import { ConnectionService } from 'src/app/service/connection.service';

@Component({
    selector: 'app-cityconnection',
    imports: [CommonModule, ReactiveFormsModule, MatSelectModule],
    templateUrl: './cityconnection.component.html',
    styleUrl: './cityconnection.component.scss'
})
export class CityconnectionComponent {
    cityConnections: CityConnection[] = []

    cities: City[] = [];

    crossingForm: FormGroup = new FormGroup({
        cityIdA: new FormControl(''),
        cityIdB: new FormControl(''),
        frequencyPerWeek: new FormControl(),
        isPassenger: new FormControl(true),
        isFreight: new FormControl(true),
    });

    /**
     *
     */
    constructor(private connectionService: ConnectionService, private citiesService: CityService) {
        this.connectionService.getCityConnections().subscribe(
            (value: CityConnection[]) => {
                if (!value)
                    return
                this.cityConnections = value
                console.log(value)
            }
        )

        this.citiesService.getAll().subscribe((value: City[]) => {
            if (!value)
                return

            this.cities = value;
        })
    }

    createCrossing() {
        if (this.crossingForm.value.fromCityId == '' ||
            this.crossingForm.value.toCityId == ''
        )
            return;

        this.connectionService.createCityConnections(
            {
                fromCityId: this.crossingForm.value.cityIdA,
                toCityId: this.crossingForm.value.cityIdB,
                frequencyPerWeek: this.crossingForm.value.frequencyPerWeek,
                isPassenger: this.crossingForm.value.isPassenger,
                isFreight: this.crossingForm.value.isFreight,

                fromCity: {
                    id: '',
                    name: '',
                    countryId: '',
                    country: {
                        id: '',
                        name: '',
                        photoUrl: '',
                        fromCountryConnections: [],
                        toCountryConnections: [],
                        borderCrossingsAsA: [],
                        borderCrossingsAsB: []
                    },
                    fromCityConnections: [],
                    toCityConnections: [],
                    photoUrl: ''
                },
                toCity: {
                    id: '',
                    name: '',
                    countryId: '',
                    country: {
                        id: '',
                        name: '',
                        photoUrl: '',
                        fromCountryConnections: [],
                        toCountryConnections: [],
                        borderCrossingsAsA: [],
                        borderCrossingsAsB: []
                    },
                    fromCityConnections: [],
                    toCityConnections: [],
                    photoUrl: ''
                },
            }).subscribe(
                value => window.location.reload()
            )
    }
}
