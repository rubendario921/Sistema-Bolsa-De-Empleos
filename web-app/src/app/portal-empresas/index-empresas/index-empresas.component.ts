import { Component } from '@angular/core';
import { HeaderAdminComponent } from '../../portal-admin/template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../../portal-admin/template-admin/footer-admin/footer-admin.component';
import { NewOfertaEmpresasComponent } from './new-oferta-empresas/new-oferta-empresas.component';

@Component({
  selector: 'app-index-empresas',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NewOfertaEmpresasComponent,
  ],
  templateUrl: './index-empresas.component.html',
  styleUrl: './index-empresas.component.css',
})
export class IndexEmpresasComponent {}
