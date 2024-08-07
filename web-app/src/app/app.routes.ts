import { provideRouter, Routes } from '@angular/router';
import { UsersComponent } from './main/users/users.component';
import { MainComponent } from './main/main.component';
import { LandingComponent } from './main/landing/landing.component';

export const routes: Routes = [
  { path: '', redirectTo: '/main', pathMatch: 'full' },
  {path:'***',redirectTo:'/main'},
  { path: 'main', component: MainComponent, children:[
    {path:'landing',component: LandingComponent},    
]},
{path: 'users', component: UsersComponent },  
];
export const appRouterProviders = [provideRouter(routes)];
