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
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { rolesDTO } from '../../../models/rolesDTO';
import { RolesService } from '../../../services/roles.service';
import { ReplaySubject } from 'rxjs';

@Component({
  selector: 'app-details-roles-admin',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ReactiveFormsModule,
    CommonModule,
  ],
  templateUrl: './details-roles-admin.component.html',
  styleUrl: './details-roles-admin.component.css',
})
export class DetailsRolesAdminComponent implements OnInit, OnDestroy {
  //Variables
  detailsRolesForm!: FormGroup;
  rolId!: number;
  rolDetails: rolesDTO[] = [];

  //Constructor
  constructor(
    private rolService: RolesService,
    private fb: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private toast: CustomToastrService
  ) {
    //Validaciones del formulario
    this.detailsRolesForm = this.fb.group({
      rolId: [''],
      rolName: [''],
      rolDescription: [''],
    });
  }

  ngOnInit(): void {
    //Obtener información por ID
    this.route.params.subscribe((params) => {
      this.rolId = params['id'];
      this.rolService.getRolById(this.rolId).subscribe(
        (result: rolesDTO) => {
          //console.log(result);
          this.toast.success('Datos cargador correctamente');
          this.detailsRolesForm = this.fb.group({
            rolId: [result.rolId, [Validators.required]],
            rolName: [
              result.rolName,
              [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
            ],
            rolDescription: [result.rolDescription, [Validators.required]],
          });
        },
        (error) => {
          console.error(error);
          this.toast.error('Error al cargar datos');
        }
      );
    });
  }

  ngOnDestroy(): void {
    if (this.detailsRolesForm) {
      this.detailsRolesForm.reset();
    }
  }

  //Funciones
  updateRoles(): void {
    let updateRolData = this.detailsRolesForm.value;
    let rolDTO: rolesDTO = {
      rolId: updateRolData.rolId,
      rolName: updateRolData.rolName,
      rolDescription: updateRolData.rolDescription,
    };
    //console.log(rolDTO);
    this.rolService.updateRol(rolDTO.rolId, rolDTO).subscribe(
      (result) => {
        if (result) {
          this.toast.success('Rol actualizado de manera correcta');
          this.router.navigate(['/roles-page']);
        } else {
          console.error(result);
          this.toast.error('Error en actualizar los datos.');
        }
      },
      (error) => {
        console.error(error);
        this.toast.error('Error en actualizar los datos.');
      }
    );
  }

  deleteRoles(): void {
    if (confirm('¿Estás seguro de eliminar le registro?')) {
      this.rolService.deleteRol(this.rolId).subscribe(
        (result) => {
          if (result) {
            this.toast.success('Rol eliminado correctamente');
          } else {
            this.toast.error('Error al eliminar rol');
          }
        },
        (error) => {
          console.error(error);
          this.toast.error('Error al eliminar rol.');
        }
      );
    }
  }
}
