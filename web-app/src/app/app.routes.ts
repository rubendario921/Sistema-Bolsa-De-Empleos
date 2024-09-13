import { provideRouter, Routes } from '@angular/router';
import { UsersComponent } from './main/users/users.component';
import { MainComponent } from './main/main.component';
import { LandingComponent } from './main/landing/landing.component';
import { CompaniesPageComponent } from './main/companies-page/companies-page.component';
import { IndexPageComponent } from './portal-admin/index-page/index-page.component';
import { StatusPageComponent } from './portal-admin/status-page/status-page.component';
import { DetailsStatusAdminComponent } from './portal-admin/status-page/details-status-admin/details-status-admin.component';
import { UsuariosPageComponent } from './portal-admin/usuarios-page/usuarios-page.component';
import { DetailsUsuarioAdminComponent } from './portal-admin/usuarios-page/details-usuario-admin/details-usuario-admin.component';
import { RolesPageComponent } from './portal-admin/roles-page/roles-page.component';
import { DetailsRolesAdminComponent } from './portal-admin/roles-page/details-roles-admin/details-roles-admin.component';
import { PostulacionesPageComponent } from './main/postulaciones-page/postulaciones-page.component';
import { EmpresasPageComponent } from './portal-admin/empresas-page/empresas-page.component';
import { DetailsEmpresasAdminComponent } from './portal-admin/empresas-page/details-empresas-admin/details-empresas-admin.component';

export const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: '***', redirectTo: '/main' },
  {
    path: 'main',
    component: MainComponent,
    children: [{ path: 'landing', component: LandingComponent }],
  },
  { path: 'users', component: UsersComponent },
  { path: 'companies', component: CompaniesPageComponent },
  { path: 'postulaciones-page', component: PostulacionesPageComponent },

  { path: 'portal-admin', component: IndexPageComponent },
  //Usuarios
  { path: 'usuarios-page', component: UsuariosPageComponent },
  {
    path: 'usuarios-page/details-users/:id',
    component: DetailsUsuarioAdminComponent,
  },
  //Estados
  { path: 'status-page', component: StatusPageComponent },
  {
    path: 'status-page/details-status/:id',
    component: DetailsStatusAdminComponent,
  },
  //Roles
  { path: 'roles-page', component: RolesPageComponent },
  {
    path: 'roles-page/details-status/:id',
    component: DetailsRolesAdminComponent,
  },
  //Empresas
  { path: 'empresas-page', component: EmpresasPageComponent },
  {
    path: 'empresas-page/details-empresa/:id',
    component: DetailsEmpresasAdminComponent,
  },
];
export const appRouterProviders = [provideRouter(routes)];
