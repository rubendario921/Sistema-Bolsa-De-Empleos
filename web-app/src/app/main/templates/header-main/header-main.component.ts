import { Component } from '@angular/core';
import { AuthComponent } from '../../auth/auth.component';

@Component({
  selector: 'app-header-main',
  standalone: true,
  imports: [AuthComponent],
  templateUrl: './header-main.component.html',
  styleUrl: './header-main.component.css',
})
export class HeaderMainComponent {}
