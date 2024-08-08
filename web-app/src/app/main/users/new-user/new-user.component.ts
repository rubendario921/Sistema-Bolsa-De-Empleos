import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-new-user',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-user.component.html',
  styleUrl: './new-user.component.css',
})
export class NewUserComponent implements OnInit, OnDestroy {
  //Variables de Componente
  registerUser!: FormGroup;
  viewPasswordInput: boolean = false;
  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    //Formulario de registro
    this.registerUser = this.fb.group({
      name: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      lastName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-ZÑ ]+$/)],
      ],
      typeDni: ['', [Validators.required]],
      numDni: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
          Validators.pattern(/^[0-9]+$/),
        ],
      ],
      phoneNumber: [
        '',
        [
          Validators.required,
          Validators.minLength(10),
          Validators.maxLength(10),
          Validators.pattern(/^[0-9]+$/),
        ],
      ],
      email: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern(/^[a-z0-9@_.]+$/),
        ],
      ],
      password: ['', [Validators.required, Validators.minLength(8)]],
    });
  }
  ngOnDestroy(): void {
    this.registerUser.reset();
  }
  onsubmit() {}
  viewPassword(): void {
    this.viewPasswordInput = !this.viewPasswordInput;
  }
}
