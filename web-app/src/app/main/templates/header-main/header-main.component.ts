import { Component, OnInit } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
import { AuthComponent } from './auth/auth.component';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-header-main',
  standalone: true,
  imports: [RouterOutlet, RouterLink, AuthComponent],
  templateUrl: './header-main.component.html',
  styleUrl: './header-main.component.css',
})
export class HeaderMainComponent implements OnInit{
  //Constructor
  constructor(private authService: AuthService){}

  ngOnInit(): void {
    //Destruir informacion local y token
    this.authService.removeToken();
  }  
}