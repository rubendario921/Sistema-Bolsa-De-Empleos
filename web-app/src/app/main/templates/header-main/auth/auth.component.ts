import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormControl,
  FormGroup,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';
import { CommonModule } from '@angular/common';

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
  }
  onsubmitLogin(): void {}
  onsubmitForgot(): void {}
}
