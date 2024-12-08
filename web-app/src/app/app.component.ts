import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MainComponent } from './main/main.component';
import { HeaderMainComponent } from './main/templates/header-main/header-main.component';
import { FooterMainComponent } from './main/templates/footer-main/footer-main.component';

@Component({
    selector: 'app-root',
    imports: [
        RouterOutlet,
        MainComponent,
        HeaderMainComponent,
        FooterMainComponent,
    ],
    templateUrl: './app.component.html',
    styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'web-app';
}
