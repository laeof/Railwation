import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule } from '@angular/forms';
import { MatSelectModule } from '@angular/material/select';
import { BorderCrossing } from 'src/app/dto/BorderCrossing';
import { Country } from 'src/app/dto/Country';
import { CountryConnection } from 'src/app/dto/CountryConnection';
import { ConnectionService } from 'src/app/service/connection.service';
import { CountryService } from 'src/app/service/country.service';

@Component({
    selector: 'app-bordercrossing',
    imports: [CommonModule, MatSelectModule, ReactiveFormsModule],
    templateUrl: './bordercrossing.component.html',
    styleUrl: './bordercrossing.component.scss'
})
export class BordercrossingComponent {
    borderCrossings: BorderCrossing[] = []

    countries: Country[] = [];

    crossingForm: FormGroup = new FormGroup({
        countryIdA: new FormControl(''),
        countryIdB: new FormControl(''),
        hasRailway: new FormControl(true),
    });

    constructor(private connectionService: ConnectionService, private countryService: CountryService) {
        this.connectionService.getBorderCrossings().subscribe(
            (value: BorderCrossing[]) => {
                if (!value)
                    return

                this.borderCrossings = value
            }
        )

        this.countryService.getAll().subscribe((value: Country[]) => {
            if (!value)
                return

            this.countries = value;
        })
    }

    createCrossing() {
        if (this.crossingForm.value.countryAId == '' ||
            this.crossingForm.value.countryBId == ''
        )
            return;

        this.connectionService.createBorderCrossing(
            {
                countryAId: this.crossingForm.value.countryIdA,
                countryBId: this.crossingForm.value.countryIdB,
                hasRailway: this.crossingForm.value.hasRailway,
                countryA: {
                    id: '',
                    name: '',
                    photoUrl: '',
                    fromCountryConnections: [],
                    toCountryConnections: [],
                    borderCrossingsAsA: [],
                    borderCrossingsAsB: []
                },
                countryB: {
                    id: '',
                    name: '',
                    photoUrl: '',
                    fromCountryConnections: [],
                    toCountryConnections: [],
                    borderCrossingsAsA: [],
                    borderCrossingsAsB: []
                }
            }).subscribe(
                value => window.location.reload()
            )
    }
}
