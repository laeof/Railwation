import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Country } from 'src/app/dto/Country';
import { CountrySidebarComponent } from "../country-sidebar/country-sidebar.component";
import { City } from 'src/app/dto/City';
import { IntegrationService } from 'src/app/service/integration.service';
import { Integrations } from 'src/app/dto/Integrations';

@Component({
    selector: 'app-country-details',
    imports: [CommonModule, CountrySidebarComponent],
    templateUrl: './country-details.component.html',
    styleUrl: './country-details.component.scss'
})
export class CountryDetailsComponent implements OnInit {
    @Input() country: Country | undefined = undefined;
    @Input() cities: City[] = [];
    score: Integrations | undefined = undefined

    constructor(private integrationService: IntegrationService) {

    }
    ngOnInit(): void {
        if (!this.country)
            return

        this.integrationService.getIntegrations(this.country?.id).subscribe((value: any) => {
            this.score = value.value;
            console.log(value.value)
            this.score!.scoreBorderCrossings = Math.round((this.score!.scoreBorderCrossings / 15) * 100);
            this.score!.scoreCityCoverage = Math.round((this.score!.scoreCityCoverage / 15) * 100);
            this.score!.scoreInternationalConnections = Math.round((this.score!.scoreInternationalConnections / 25) * 100);
            this.score!.scoreLogistics = Math.round((this.score!.scoreLogistics / 30) * 100);
            this.score!.scoreRailServices = Math.round((this.score!.scoreRailServices / 20) * 100);
            console.log(this.score)
        });
    }

    page: number = 0;

    onValueChanged(value: number) {
        this.page = value;
    }

}
