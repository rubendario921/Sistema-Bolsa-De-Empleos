import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';

@Component({
  selector: 'app-empresas-page',
  standalone: true,
  imports: [HeaderAdminComponent, FooterAdminComponent, NavbarAdminComponent],
  templateUrl: './empresas-page.component.html',
  styleUrl: './empresas-page.component.css'
})
export class EmpresasPageComponent {

}
