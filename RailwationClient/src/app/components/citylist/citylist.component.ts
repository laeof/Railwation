import { CommonModule } from '@angular/common';
import { Component, Input } from '@angular/core';
import { City } from 'src/app/dto/City';

@Component({
    selector: 'app-citylist',
    imports: [CommonModule],
    templateUrl: './citylist.component.html',
    styleUrl: './citylist.component.scss'
})
export class CitylistComponent {
    @Input() cities: City[] = []
    @Input() disablePadding: boolean = false;
}
