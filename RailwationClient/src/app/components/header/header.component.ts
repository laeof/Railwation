import { Component } from '@angular/core';
import { LogoComponent } from "../logo/logo.component";
import { Router } from '@angular/router';

@Component({
    selector: 'app-header',
    imports: [LogoComponent],
    templateUrl: './header.component.html',
    styleUrl: './header.component.scss'
})
export class HeaderComponent {
    /**
     *
     */
    constructor(private router: Router) {

    }
    redirectTo(arg0: string) {
        this.router.navigate([arg0]);
    }

}
