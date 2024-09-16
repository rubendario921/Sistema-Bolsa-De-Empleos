import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';
import { ViewIndustriasAdminComponent } from './view-industrias-admin/view-industrias-admin.component';
import { NewIndustriaAdminComponent } from './new-industria-admin/new-industria-admin.component';

@Component({
  selector: 'app-industrias-page',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ViewIndustriasAdminComponent,
    NewIndustriaAdminComponent,
  ],

  templateUrl: './industrias-page.component.html',
  styleUrl: './industrias-page.component.css',
})
export class IndustriasPageComponent {}
