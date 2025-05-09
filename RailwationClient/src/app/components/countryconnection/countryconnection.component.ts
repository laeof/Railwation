import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormGroup, FormControl, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { Country } from 'src/app/dto/Country';
import { CountryConnection } from 'src/app/dto/CountryConnection';
import { ConnectionService } from 'src/app/service/connection.service';
import { CountryService } from 'src/app/service/country.service';

@Component({
    selector: 'app-countryconnection',
    imports: [CommonModule, ReactiveFormsModule, MatSelectModule],
    templateUrl: './countryconnection.component.html',
    styleUrl: './countryconnection.component.scss'
})
export class CountryconnectionComponent {
    countryConnections: CountryConnection[] = []

    countries: Country[] = [];

    crossingForm: FormGroup = new FormGroup({
        countryIdA: new FormControl(''),
        countryIdB: new FormControl(''),
        isFreight: new FormControl(true),
        isPassenger: new FormControl(true),
        frequencyPerWeek: new FormControl(),
        logisticsScore: new FormControl(),
    });

    /**
     *
     */
    constructor(private connectionService: ConnectionService, private countryService: CountryService) {
        this.connectionService.getCountryConnections().subscribe(
            (value: CountryConnection[]) => {
                if (!value)
                    return

                this.countryConnections = value
            }
        )

        this.countryService.getAll().subscribe((value: Country[]) => {
            if (!value)
                return

            this.countries = value;
        })
    }

    createCrossing() {
        if (this.crossingForm.value.countryIdA == '' ||
            this.crossingForm.value.countryIdB == ''
        )
            return;

        this.connectionService.createCountryConnections(
            {
                fromCountryId: this.crossingForm.value.countryIdA,
                toCountryId: this.crossingForm.value.countryIdB,
                weeklyFrequency: this.crossingForm.value.frequencyPerWeek,
                hasPassengerService: this.crossingForm.value.isPassenger,
                hasFreightService: this.crossingForm.value.isFreight,
                fromCountry: {
                    id: '',
                    name: '',
                    photoUrl: '',
                    fromCountryConnections: [],
                    toCountryConnections: [],
                    borderCrossingsAsA: [],
                    borderCrossingsAsB: []
                },
                toCountry: {
                    id: '',
                    name: '',
                    photoUrl: '',
                    fromCountryConnections: [],
                    toCountryConnections: [],
                    borderCrossingsAsA: [],
                    borderCrossingsAsB: []
                },
                logisticsScore: 0
            }).subscribe(
                value => window.location.reload()
            )
    }
}
