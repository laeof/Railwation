import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Country } from 'src/app/dto/Country';

@Component({
    selector: 'app-country-sidebar',
    imports: [],
    templateUrl: './country-sidebar.component.html',
    styleUrl: './country-sidebar.component.scss'
})
export class CountrySidebarComponent {
    @Input() country: Country | undefined = undefined;

    @Output() page = new EventEmitter<number>()
    currentPage: number = 0;

    constructor(private router: Router) {

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
