import { Component, OnDestroy, OnInit, viewChild } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { loginDTO } from '../../../../models/loginDTOs.interface';
import { AuthService } from '../../../../services/auth.service';
import { Router } from '@angular/router';
import { CustomToastrService } from '../../../../services/custom-toastr.service';
import { forgotDTO } from '../../../../models/forgotDTOs.interface';
import { loginEmpresasDTO } from '../../../../models/loginEmpresasDTO.interface';

@Component({
  selector: 'app-auth',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './auth.component.html',
  styleUrl: './auth.component.css',
})
export class AuthComponent implements OnInit, OnDestroy {
  // Variables del componente
  forgotForm!: FormGroup;
  loginForm!: FormGroup;

  //Constructor
  constructor(
    private authService: AuthService,
    private router: Router,
    private toast: CustomToastrService
  ) {}

  ngOnInit(): void {
    //Formulario Login
    this.loginForm = new FormGroup({
      numDniLogin: new FormControl('', [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(13),
        Validators.pattern(/^[0-9]+$/),
      ]),
      passwordLogin: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
    });
    //Formulario Forgot
    this.forgotForm = new FormGroup({
      numDniForgot: new FormControl('', [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(13),
        Validators.pattern(/^[0-9]+$/),
      ]),
      emailForgot: new FormControl('', [
        Validators.required,
        Validators.email,
        Validators.pattern(/^[a-z0-9@.]+$/),
      ]),
      numPhoneForgot: new FormControl('', [
        Validators.required,
        Validators.minLength(10),
        Validators.maxLength(10),
        Validators.pattern(/^[0-9]+$/),
      ]),
    });
  }
  ngOnDestroy(): void {
    this.loginForm.reset();
    this.forgotForm.reset();
  }
  onsubmitLogin(): void {
    if (this.loginForm.valid) {
      let newLoginData = this.loginForm.value;
      //console.log(newLoginData.numDniLogin);

      //Validaciones del tamaño del NumDni
      if (newLoginData.numDniLogin.length == 10) {
        //Crear el objeto Usuario
        let loginDTO: loginDTO = {
          usuNumDni: newLoginData.numDniLogin,
          usuPassword: newLoginData.passwordLogin,
        };
        //console.log(loginDTO);
        this.authService.loginUser(loginDTO).subscribe(
          (response) => {
            if (response) {
              this.toast.success('Inicio de sesión de correcto.');
              this.router.navigate(['portal-admin']);
            } else {
              this.toast.error('Error campos incorrectos');
            }
          },
          (error) => {
            this.toast.error(error.message, 'Error');
          }
        );
      } else {
        //Crear el objeto Empresas
        let loginEmpresasDTO: loginEmpresasDTO = {
          empNumRuc: newLoginData.numDniLogin,
          empStaffPassword: newLoginData.passwordLogin,
        };
        //console.log(loginEmpresasDTO);
        this.authService.loginEmpresas(loginEmpresasDTO).subscribe(
          (result) => {
            //console.log(result);
            this.toast.success('Inicio de sesión de correcto');
            this.router.navigate(['portal-empresas']);
          },
          (error) => {
            //console.error(error);
            this.toast.error('Error la iniciar sesión. Intente nuevamente');
          }
        );
      }
    }
  }
  onsubmitForgot(): void {
    if (this.forgotForm.valid) {
      let newForgotData = this.forgotForm.value;
      let forgotDTO: forgotDTO = {
        usuNumDni: newForgotData.numDniForgot,
        usuEmail: newForgotData.emailForgot,
        usuNumPhone: newForgotData.numPhoneForgot,
      };
      console.log(forgotDTO);
      this.authService.forgotLogin(forgotDTO).subscribe(
        (response) => {
          if (response) {
            this.toast.success('Contraseña restablecida.');
            this.router.navigate(['main']).then(() => {
              window.location.reload();
            });
          } else {
            this.toast.error('Error de campos incorrectos');
            this.router.navigate(['main']).then(() => {
              window.location.reload();
            });
          }
        },
        (error) => {
          console.error(error);
          this.toast.error('Error al recuperar la contraseña.');
          this.router.navigate(['main']).then(() => {
            window.location.reload();
          });
        }
      );
    }
  }
}
