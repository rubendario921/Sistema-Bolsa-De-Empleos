import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';
import { ViewStatusAdminComponent } from './view-status-admin/view-status-admin.component';
import { NewStatusAdminComponent } from './new-status-admin/new-status-admin.component';

@Component({
    selector: 'app-status-page',
    imports: [
        HeaderAdminComponent,
        FooterAdminComponent,
        NavbarAdminComponent,
        ViewStatusAdminComponent,
        NewStatusAdminComponent,
    ],
    templateUrl: './status-page.component.html',
    styleUrl: './status-page.component.css'
})
export class StatusPageComponent {}
