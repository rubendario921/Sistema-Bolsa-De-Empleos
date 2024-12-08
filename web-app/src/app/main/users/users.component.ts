import { Component } from '@angular/core';
import { HeaderMainComponent } from '../templates/header-main/header-main.component';
import { FooterMainComponent } from '../templates/footer-main/footer-main.component';
import { NewUserComponent } from './new-user/new-user.component';
import { BasicInformationComponent } from '../landing/basic-information/basic-information.component';

@Component({
    selector: 'app-users',
    imports: [
        HeaderMainComponent,
        FooterMainComponent,
        NewUserComponent,
        BasicInformationComponent,
    ],
    templateUrl: './users.component.html',
    styleUrl: './users.component.css'
})
export class UsersComponent {}
