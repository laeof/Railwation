import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { Router } from '@angular/router';
import { Country } from 'src/app/dto/Country';

@Component({
    selector: 'app-country-sidebar',
    imports: [],
    templateUrl: './country-sidebar.component.html',
    styleUrl: './country-sidebar.component.scss'
})
export class CountrySidebarComponent implements OnChanges {
    @Input() country: Country | undefined = undefined;
    @Output() page = new EventEmitter<number>()
    @Input() pageNumber: number = 0;

    currentPage: number = 0;

    constructor(private router: Router) {

    }

    ngOnChanges(changes: SimpleChanges) {
        if (changes['pageNumber']) {
            this.currentPage = changes['pageNumber'].currentValue;
        }
    }

    redirectTo(path: string) {
        this.router.navigate([path])
        window.location.href = "/"
    }

    showPage(arg0: number) {
        this.currentPage = arg0;
        this.page.emit(arg0);
    }
}
