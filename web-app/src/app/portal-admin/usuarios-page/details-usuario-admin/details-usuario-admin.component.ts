import { Component, OnDestroy, OnInit } from '@angular/core';
import { HeaderAdminComponent } from '../../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../../template-admin/navbar-admin/navbar-admin.component';
import {
  FormBuilder,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { UsersService } from '../../../services/users.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { CommonModule } from '@angular/common';
import { rolesDTO } from '../../../models/rolesDTO';
import { estadoDTO } from '../../../models/estadosDTO.interface';
import { userDTO } from '../../../models/userDTO.interface';
import { EstadosService } from '../../../services/estados.service';
import { RolesService } from '../../../services/roles.service';
import { ActivatedRoute, Router } from '@angular/router';
import { subscribeOn } from 'rxjs';

@Component({
  selector: 'app-details-usuario-admin',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './details-usuario-admin.component.html',
  styleUrl: './details-usuario-admin.component.css',
})
export class DetailsUsuarioAdminComponent implements OnInit, OnDestroy {
  //Variables
  detailsUserForm!: FormGroup;
  userDetails: userDTO[] = [];
  allRoles: rolesDTO[] = [];
  allEstados: estadoDTO[] = [];
  userId!: number;
  //Constructor
  constructor(
    private userService: UsersService,
    private estadoService: EstadosService,
    private rolService: RolesService,
    private fb: FormBuilder,
    private toastService: CustomToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.detailsUserForm = this.fb.group({
      newId: [''],
      newName: [''],
      newLastName: [''],
      newTypeDni: [''],
      newNumDni: [''],
      newNumPhone: [''],
      newEmail: [''],
      newPassword: [''],
      newRol: [''],
      newStatus: [''],
    });
  }

  ngOnInit(): void {
    //Obtener información del user
    this.route.params.subscribe((params) => {
      this.userId = params['id'];
      this.userService.getUsuarioById(this.userId).subscribe((result) => {
        if (result) {
          this.detailsUserForm = this.fb.group({
            newId: [result.id],
            newName: [
              result.usuName,
              [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
            ],
            newLastName: [result.usuLastName],
            newTypeDni: [result.usuTypeDni],
            newNumDni: [result.usuNumDni],
            newNumPhone: [result.usuNumPhone],
            newEmail: [result.usuEmail],
            newPassword: [result.usuPassword],
            newRol: [result.rolId],
            newStatus: [result.estId],
          });
        } else {
          console.error(result);
          this.toastService.error('Error al obtener los datos.');
        }
      });
    });
    //Carga de Datos Rol
    this.loadRolData();
    //Carga de Datos Estados
    this.loadStatusData();
  }
  ngOnDestroy(): void {
    if (this.detailsUserForm.invalid) {
      this.detailsUserForm.reset();
    }
  }
  //Funciones

  //Estados
  loadStatusData(): void {
    this.estadoService.getAllEstados().subscribe((result) => {
      if (result != null) {
        this.allEstados = result;
        //return result;
      } else {
        console.log('Error, No hay datos registrado');
      }
    });
  }
  //Roles
  loadRolData(): void {
    this.rolService.getAllRoles().subscribe((result) => {
      if (result != null) {
        this.allRoles = result;
        //return result;
      } else {
        console.log('Error, no hay datos registrados.');
      }
    });
  }

  updateUser(): void {
    let updateUserData = this.detailsUserForm.value;
    let userDTO: userDTO = {
      usuId: this.userId,
      usuName: updateUserData.newName,
      usuLastName: updateUserData.newLastName,
      usuTypeDni: updateUserData.newTypeDni,
      usuNumDni: updateUserData.newNumDni,
      usuNumPhone: updateUserData.newNumPhone,
      usuEmail: updateUserData.newEmail,
      usuPassword: updateUserData.newPassword,
      usuAttempts: 0,
      usuProfilePicture: 'NULL',
      usuAdicionalArchive: 'NULL',
      rolId: updateUserData.newRol,
      estId: updateUserData.newStatus,
      rolName: '',
      estadoName: '',
      estadoColor: '',
    };
    console.log(userDTO);
    this.userService
      .updateUsuarios(userDTO.estId, userDTO)
      .subscribe((result) => {
        if (result) {
          this.toastService.success('Usuario actualizado correctamente');
          this.router.navigate(['/usuarios-page']);
        } else {
          console.log('Error en actualizar el usuario.');
          this.toastService.error('Error en actualizar el usuario.');
        }
      });
  }

  deleteUser(): void {
    if (confirm('¿Estas seguro de eliminar el registro?')) {
      this.userService.deleteUsuarios(this.userId).subscribe((result) => {
        if (result) {
          this.toastService.success('Usuario eliminado correctamente');
        } else {
          console.error(result);
          this.toastService.error('Error al eliminar el usuario');
        }
      });
    }
  }
}
