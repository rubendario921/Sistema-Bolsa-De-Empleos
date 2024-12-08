import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';
import { ViewProvinciasAdminComponent } from './view-provincias-admin/view-provincias-admin.component';

@Component({
    selector: 'app-provincias-page',
    imports: [
        HeaderAdminComponent,
        FooterAdminComponent,
        NavbarAdminComponent,
        ViewProvinciasAdminComponent,
    ],
    templateUrl: './provincias-page.component.html',
    styleUrl: './provincias-page.component.css'
})
export class ProvinciasPageComponent {}
