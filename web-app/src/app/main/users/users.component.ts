import { Component } from '@angular/core';
import { HeaderMainComponent } from '../templates/header-main/header-main.component';
import { FooterMainComponent } from '../templates/footer-main/footer-main.component';
import { NewUserComponent } from './new-user/new-user.component';

@Component({
  selector: 'app-users',
  standalone: true,
  imports: [HeaderMainComponent,FooterMainComponent, NewUserComponent],
  templateUrl: './users.component.html',
  styleUrl: './users.component.css'
})
export class UsersComponent {

}
