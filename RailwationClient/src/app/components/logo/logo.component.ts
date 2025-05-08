import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
    selector: 'app-logo',
    imports: [],
    templateUrl: './logo.component.html',
    styleUrl: './logo.component.scss'
})
export class LogoComponent {

    redirectTo(undefined: string) {
        window.location.href = "home"
    }

}
