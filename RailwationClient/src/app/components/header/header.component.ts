import { Component } from '@angular/core';
import { LogoComponent } from "../logo/logo.component";
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
    selector: 'app-header',
    imports: [LogoComponent, CommonModule],
    templateUrl: './header.component.html',
    styleUrl: './header.component.scss'
})
export class HeaderComponent {

    burger: boolean = false;
    /**
     *
     */
    constructor(private router: Router) {

    }
    redirectTo(arg0: string) {
        this.router.navigate([arg0]);
    }

    toggleBurger() {
        this.burger = !this.burger;
    }

}
