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
  selector: 'app-new-company',
  standalone: true,
  imports: [ReactiveFormsModule, CommonModule],
  templateUrl: './new-company.component.html',
  styleUrl: './new-company.component.css',
})
export class NewCompanyComponent implements OnInit, OnDestroy {
  //Variables del componente
  registerStaff!: FormGroup;
  viewPasswordInput: boolean = false;
  viewConfirmPasswordInput: boolean = false;
  //Constructor
  constructor(private fb: FormBuilder) {}

  ngOnInit(): void {
    //Formulario del registro
    this.registerStaff = this.fb.group({
      staffName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      staffLastName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      staffEmail: ['', [Validators.required, Validators.email]],
      staffPassword: ['', [Validators.required, Validators.minLength(8)]],
      confirmStaffPassword: [
        '',
        [Validators.required, Validators.minLength(8)],
      ],
      staffNameCompany: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z 0-9]+$/)],
      ],
      staffBusinessName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      staffRuc: [
        '',
        [
          Validators.required,
          Validators.pattern(/^[0-9]+$/),
          Validators.minLength(13),
        ],
      ],
      staffNumContact: [
        '',
        [
          Validators.required,
          Validators.pattern(/^[0-9]+$/),
          Validators.minLength(10),
        ],
      ],
      staffIndustry: ['', [Validators.required]],
      StaffCount: ['', [Validators.required]],
    });
  }
  ngOnDestroy(): void {
    this.registerStaff.reset();
  }

  onsubmit() {}
  viewPassword(): void {
    this.viewPasswordInput = !this.viewPasswordInput;
  }
  viewConfirmPassword(): void {
    this.viewConfirmPasswordInput = !this.viewConfirmPasswordInput;
  }
}
