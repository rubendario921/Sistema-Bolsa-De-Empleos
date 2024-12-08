import { Component } from '@angular/core';
import { BasicInformationComponent } from './basic-information/basic-information.component';
import { CarouselMainComponent } from './carousel-main/carousel-main.component';
import { CarouselNoticesComponent } from './carousel-notices/carousel-notices.component';

@Component({
    selector: 'app-landing',
    imports: [
        BasicInformationComponent,
        CarouselMainComponent,
        CarouselNoticesComponent,
    ],
    templateUrl: './landing.component.html',
    styleUrl: './landing.component.css'
})
export class LandingComponent {}
