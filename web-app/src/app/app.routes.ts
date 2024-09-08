import { provideRouter, Routes } from '@angular/router';
import { UsersComponent } from './main/users/users.component';
import { MainComponent } from './main/main.component';
import { LandingComponent } from './main/landing/landing.component';
import { CompaniesPageComponent } from './main/companies-page/companies-page.component';
import { IndexPageComponent } from './portal-admin/index-page/index-page.component';
import { StatusPageComponent } from './portal-admin/status-page/status-page.component';
import { DetailsStatusAdminComponent } from './portal-admin/status-page/details-status-admin/details-status-admin.component';

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
  { path: 'portal-admin', component: IndexPageComponent },
  { path: 'status-page', component: StatusPageComponent },
  {
    path: 'status-page/details-status/:id',
    component: DetailsStatusAdminComponent,
  },
];
export const appRouterProviders = [provideRouter(routes)];
