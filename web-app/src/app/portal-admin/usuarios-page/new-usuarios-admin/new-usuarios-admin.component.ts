import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UsersService } from '../../../services/users.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { Router } from '@angular/router';
import { userDTO } from '../../../models/userDTO.interface';
import { EstadosService } from '../../../services/estados.service';
import { estadoDTO } from '../../../models/estadosDTO.interface';
import { rolesDTO } from '../../../models/rolesDTO';
import { RolesService } from '../../../services/roles.service';

@Component({
    selector: 'app-new-usuarios-admin',
    imports: [ReactiveFormsModule, CommonModule],
    templateUrl: './new-usuarios-admin.component.html',
    styleUrl: './new-usuarios-admin.component.css'
})
export class NewUsuariosAdminComponent implements OnInit, OnDestroy {
  //Variables
  newFormUser!: FormGroup;
  allEstados: estadoDTO[] = [];
  allRoles: rolesDTO[] = [];
  //Constructor
  constructor(
    private userServices: UsersService,
    private statusServices: EstadosService,
    private rolServices: RolesService,
    private fb: FormBuilder,
    private toast: CustomToastrService,
    private router: Router
  ) {}

  ngOnInit(): void {
    //Validaciones del formulario
    this.newFormUser = this.fb.group({
      newName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      newLastName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      newTypeDni: ['', [Validators.required]],
      newNumDni: [
        '',
        [
          Validators.required,
          Validators.pattern(/^[0-9A-Z]+$/),
          Validators.minLength(10),
          Validators.maxLength(13),
        ],
      ],
      newNumPhone: [
        '',
        [
          Validators.required,
          Validators.pattern(/^[0-9]+$/),
          Validators.minLength(10),
          Validators.maxLength(13),
        ],
      ],
      newEmail: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern(/^[a-z0-9@._-]+$/),
        ],
      ],
      newPassword: ['', [Validators.required, Validators.minLength(8)]],
      newStatus: ['', [Validators.required]],
      newRol: ['', [Validators.required]],
    });
    //Carga de datos Estados
    this.loadStatusData();
    this.loadRolData();
  }
  ngOnDestroy(): void {
    if (this.newFormUser) {
      this.newFormUser.reset();
    }
  }
  //Roles
  loadRolData(): void {
    this.rolServices.getAllRoles().subscribe((result) => {
      if (result != null) {
        this.allRoles = result;
        //return result;
      } else {
        console.log('Error, no hay datos registrados.');
      }
    });
  }
  //Estados
  loadStatusData(): void {
    this.statusServices.getAllEstados().subscribe((result) => {
      if (result != null) {
        this.allEstados = result;
        //return result;
      } else {
        console.log('Error, No hay datos registrado');
      }
    });
  }

  registerNewUser(): void {
    if (this.newFormUser.valid) {
      let newUserData = this.newFormUser.value;
      let userDTO: userDTO = {
        usuId: 0,
        usuName: newUserData.newName,
        usuLastName: newUserData.newLastName,
        usuTypeDni: newUserData.newTypeDni,
        usuNumDni: newUserData.newNumDni,
        usuNumPhone: newUserData.newNumPhone,
        usuEmail: newUserData.newEmail,
        usuPassword: newUserData.newPassword,
        usuAttempts: 0,
        usuProfilePicture: '',
        usuAdicionalArchive: '',
        rolId: newUserData.newRol,
        estId: newUserData.newStatus,
        rolName: '',
        estadoName: '',
        estadoColor: '',
      };
      console.log(userDTO);
      this.userServices.saveUsuarios(userDTO).subscribe((result) => {
        if (result) {
          this.toast.success('Usuario registrado con éxito');
          this.router.navigate(['usuarios-page']).then(() => {
            window.location.reload();
          });
        } else {
          console.log('Error al crear al usuario.');
          this.toast.error('Error al crear al usuario. intente nuevamente');
        }
      });
    }
  }
}
