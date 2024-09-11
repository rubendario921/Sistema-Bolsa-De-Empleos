import { Component, OnInit } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';
import { ViewUsuariosAdminComponent } from './view-usuarios-admin/view-usuarios-admin.component';
import { NewUserComponent } from '../../main/users/new-user/new-user.component';
import { NewUsuariosAdminComponent } from './new-usuarios-admin/new-usuarios-admin.component';

@Component({
  selector: 'app-usuarios-page',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ViewUsuariosAdminComponent,
    NewUsuariosAdminComponent,
  ],
  templateUrl: './usuarios-page.component.html',
  styleUrls: ['./usuarios-page.component.css'],
})
export class UsuariosPageComponent implements OnInit {
  constructor() {}

  ngOnInit() {}
}
