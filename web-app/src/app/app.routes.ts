import { provideRouter, Routes } from '@angular/router';
import { UsersComponent } from './main/users/users.component';
import { MainComponent } from './main/main.component';

export const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  { path: 'main', component: MainComponent },
  { path: 'users', component: UsersComponent },
];
export const appRouterProviders = [provideRouter(routes)];
