import { Component } from '@angular/core';
import { LandingComponent } from './landing/landing.component';
import { HeaderMainComponent } from './templates/header-main/header-main.component';
import { FooterMainComponent } from './templates/footer-main/footer-main.component';

@Component({
    selector: 'app-main',
    imports: [LandingComponent, HeaderMainComponent, FooterMainComponent],
    templateUrl: './main.component.html',
    styleUrl: './main.component.css'
})
export class MainComponent {}
