import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit, resolveForwardRef } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { userDTO } from '../../../models/userDTO.interface';
import { UsersService } from '../../../services/users.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { Router } from '@angular/router';

@Component({
    selector: 'app-new-user',
    imports: [ReactiveFormsModule, CommonModule],
    templateUrl: './new-user.component.html',
    styleUrl: './new-user.component.css'
})
export class NewUserComponent implements OnInit, OnDestroy {
  //Variables de Componente
  registerUser!: FormGroup;
  viewPasswordInput: boolean = false;
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private userService: UsersService,
    private toast: CustomToastrService
  ) {
    //Validaciones del formulario
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

  ngOnInit(): void {}
  ngOnDestroy(): void {
    if (this.registerUser) {
      this.registerUser.reset();
    }
  }
  registerNewUser(): void {
    if (this.registerUser.valid) {
      let newUserData = this.registerUser.value;
      let userDTO: userDTO = {
        usuId: 0,
        usuName: newUserData.name,
        usuLastName: newUserData.lastName,
        usuTypeDni: newUserData.typeDni,
        usuNumDni: newUserData.numDni,
        usuNumPhone: newUserData.phoneNumber,
        usuEmail: newUserData.email,
        usuPassword: newUserData.password,
        usuAttempts: 0,
        usuProfilePicture: '',
        usuAdicionalArchive: '',
        rolId: 2,
        estId: 1,
        rolName: '',
        estadoName: '',
        estadoColor: '',
      };
      //console.log(userDTO);
      this.userService.saveUsuarios(userDTO).subscribe((result) => {
        if (result) {
          this.toast.success('Usuario registrado con éxito');
          this.router.navigate(['/users']).then(() => {
            window.location.reload();
          });
        } else {
          console.log('Error al crear el usuario.');
          this.toast.error('Error al crear el usuario.');
        }
      });
    }
  }
  viewPassword(): void {
    this.viewPasswordInput = !this.viewPasswordInput;
  }
}
