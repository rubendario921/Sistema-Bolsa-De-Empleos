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
  //Construcutor
  constructor(private authServices: AuthService, private router: Router) {}
  ngOnInit(): void {
    // if (!this.authServices.isAuthenticated()) {      
    //   this.router.navigate(['main']);
    // }
  }
  ngOnDestroy(): void {}
}
