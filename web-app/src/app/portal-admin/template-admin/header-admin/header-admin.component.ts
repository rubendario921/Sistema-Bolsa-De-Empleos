import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../../../services/auth.service';

@Component({
    selector: 'app-header-admin',
    imports: [RouterLink],
    templateUrl: './header-admin.component.html',
    styleUrl: './header-admin.component.css'
})
export class HeaderAdminComponent implements OnInit, OnDestroy {
  //Datos del candidato
  protected userData: any;
  //Constructor
  constructor(private authServices: AuthService, private router: Router) {}
  ngOnInit(): void {
    //Verificación de autentificación

    // if (!this.authServices.isAuthenticated()) {
    //   this.router.navigate(['main']);
    // }

    //Extraer datos de AuthService
    this.userData = JSON.parse(
      localStorage.getItem(this.authServices.userInfoKey) ?? ''
    );
    //console.log(this.userData);
  }
  ngOnDestroy(): void {}

  logoutUser(): void {
    this.authServices.logOut();
    this.router.navigate(['main']);
  }
}
