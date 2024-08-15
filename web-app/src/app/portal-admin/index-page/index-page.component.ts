import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';
import { RouterLink, RouterLinkActive } from '@angular/router';

@Component({
  selector: 'app-index-page',
  standalone: true,
  imports: [
    RouterLink,
    RouterLinkActive,
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
  ],
  templateUrl: './index-page.component.html',
  styleUrl: './index-page.component.css',
})
export class IndexPageComponent {}
