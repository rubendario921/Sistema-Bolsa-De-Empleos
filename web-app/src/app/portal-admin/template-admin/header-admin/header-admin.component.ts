import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
  selector: 'app-header-admin',
  standalone: true,
  imports: [RouterLink],
  templateUrl: './header-admin.component.html',
  styleUrl: './header-admin.component.css',
})
export class HeaderAdminComponent implements OnInit, OnDestroy {
  //Datos del candidato
  public userData: any;
  //Construcutor
  constructor(private authServices: AuthService, private router: Router) {}
  ngOnInit(): void {
    //Verificacion de authentificacion

    // if (!this.authServices.isAuthenticated()) {
    //   this.router.navigate(['main']);
    // }

    //Extraer datos de AuthService
    this.userData = localStorage.getItem(this.authServices.userInfoKey);
    let user = {
      usuName: this.userData.usuName,
      usuLastName: this.userData.usuLastNameName,
      usuRol: this.userData.usuRol
    };   
  }
  ngOnDestroy(): void {}

  logoutUser(): void {
    this.authServices.logOut();
    this.router.navigate(['main']);
  }
}

