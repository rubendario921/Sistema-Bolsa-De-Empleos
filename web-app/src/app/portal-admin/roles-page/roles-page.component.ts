import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';

@Component({
  selector: 'app-roles-page',
  standalone: true,
  imports: [HeaderAdminComponent, FooterAdminComponent, NavbarAdminComponent],
  templateUrl: './roles-page.component.html',
  styleUrl: './roles-page.component.css',
})
export class RolesPageComponent {}
