import { Component, OnDestroy, OnInit } from '@angular/core';
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
    private toastrService: CustomToastrService
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
      //Crear el objeto
      const loginDTO: loginDTO = {
        usuNumDni: this.loginForm.get('numDniLogin')?.value,
        usuPassword: this.loginForm.get('passwordLogin')?.value,
      };
      //console.log(loginDTO);
      this.authService.loginUser(loginDTO).subscribe(
        (response) => {
          if (response) {
            this.toastrService.success(
              'Bienvenido: ' +
                response.usuLastName +
                ' ' +
                response.usuName +
                ' ' +
                response.rolName,
              'Correcto'
            );
            this.router.navigate(['portal-admin']);
          } else {
            this.toastrService.error(response.message, 'Error');
          }
        },
        (error) => {
          this.toastrService.error(error.message, 'Error');
        }
      );
    }
  }
  onsubmitForgot(): void {
    if (this.forgotForm.valid) {
      //Crear el objeto
      const forgotDTO: forgotDTO = {
        usuNumDni: this.forgotForm.get('numDniForgot')?.value,
        usuEmail: this.forgotForm.get('emailForgot')?.value,
        usuNumPhone: this.forgotForm.get('numPhoneForgot')?.value,
      };
      console.log(forgotDTO);
      this.authService.forgotLogin(forgotDTO).subscribe(
        (response) => {
          if (response) {
            this.toastrService.success('Contraseña Restablecida', 'Correcto');
          } else {
            this.toastrService.error('Error al actualizar contraseña');
            this.forgotForm.markAllAsTouched();
          }
        },
        (error) => {
          this.toastrService.error('Error al actualizar la contraseña');
          this.forgotForm.markAllAsTouched();
        }
      );
    } else {
      this.toastrService.warning('Formulario no valido');
      this.forgotForm.markAllAsTouched();
    }
  }
}
// this.authService.forgotLogin(forgotDTO).subscribe(
//   (response) => {
//     if (response) {
//       this.toastrService.success(response.message);
//     } else {
//       this.toastrService.error(response.message);
//       this.forgotForm.markAllAsTouched();
//     }
//   },
//   (error) => {
//     this.toastrService.error(error.error.message);
//     this.forgotForm.markAllAsTouched();
//   }
// );
