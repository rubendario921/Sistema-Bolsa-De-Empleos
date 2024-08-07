import { Component } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AuthComponent } from './auth/auth.component';

@Component({
  selector: 'app-header-main',
  standalone: true,
  imports: [RouterOutlet, RouterLink, AuthComponent],
  templateUrl: './header-main.component.html',
  styleUrl: './header-main.component.css',
})
export class HeaderMainComponent {}
