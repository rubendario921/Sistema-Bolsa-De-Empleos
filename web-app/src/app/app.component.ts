//Angular
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
//PrimeNg
import { PrimeNGConfig } from 'primeng/api';
import { ToastModule } from 'primeng/toast';
import { MessagesModule } from 'primeng/messages';
import { ButtonModule } from 'primeng/button';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    //PrimeNg
    ToastModule,
    MessagesModule,
    ButtonModule,
  ],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
})
export class AppComponent {
  title = 'web-app';

  constructor(private primeNgConfig: PrimeNGConfig) {}
}
