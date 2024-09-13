import { Component, OnDestroy, OnInit } from '@angular/core';
import { HeaderAdminComponent } from '../../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../../template-admin/navbar-admin/navbar-admin.component';
import {
  FormBuilder,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { empresaDTO } from '../../../models/empresasDTO';
import { rolesDTO } from '../../../models/rolesDTO';
import { estadoDTO } from '../../../models/estadosDTO.interface';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { EmpresasService } from '../../../services/empresas.service';
import { EstadosService } from '../../../services/estados.service';

@Component({
  selector: 'app-details-empresas-admin',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ReactiveFormsModule,
    CommonModule,
    FormsModule,
  ],
  templateUrl: './details-empresas-admin.component.html',
  styleUrl: './details-empresas-admin.component.css',
})
export class DetailsEmpresasAdminComponent implements OnInit, OnDestroy {
  //Variables
  detailsEmpresaForm!: FormGroup;
  empresaDTO: empresaDTO[] = [];
  allRoles: rolesDTO[] = [];
  allEstados: estadoDTO[] = [];
  empresaId!: number;

  //Constructor
  constructor(
    private fb: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private toast: CustomToastrService,
    private empresaService: EmpresasService,
    private estadoService: EstadosService
  ) {
    this.detailsEmpresaForm = this.fb.group({
      empId: [''],
      empStaffName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      empStaffLastName: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      empStaffEmail: [
        '',
        [
          Validators.required,
          Validators.email,
          Validators.pattern(/^[a-zA-Z@.-_]+$/),
        ],
      ],
      empStaffPassword: ['', [Validators.required]],
      empName: ['', [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)]],
      empRazonSocial: [
        '',
        [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
      ],
      empNumRuc: [''],
      empDireccion: [''],
      empCodPostal: [''],
      empNumPhone: [''],
      empActvidadEconomica: [''],
      empCantidadEmpelados: [''],
      empProfilePicture: [''],
      estId: [''],
      estName: [''],
      estColor: [''],
    });
  }
  ngOnInit(): void {
    //Llamar a la API
    this.route.params.subscribe((params) => {
      this.empresaId = params['id'];
      this.empresaService.getEmpresaById(this.empresaId).subscribe((result) => {
        if (result) {
          this.detailsEmpresaForm = this.fb.group({
            empId: [result.empId, [Validators.required]],
            empStaffName: [
              result.empStaffName,
              [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
            ],
            empStaffLastName: [
              result.empStaffLastName,
              [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
            ],
            empStaffEmail: [
              result.empStaffEmail,
              [
                Validators.required,
                Validators.email,
                Validators.pattern(/^[a-zA-Z@.-_]+$/),
              ],
            ],
            empStaffPassword: [result.empStaffPassword, [Validators.required]],
            empName: [
              result.empName,
              [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
            ],
            empRazonSocial: [
              result.empRazonSocial,
              [Validators.required, Validators.pattern(/^[a-zA-Z ]+$/)],
            ],
            empNumRuc: [result.empId],
            empDireccion: [result.empId],
            empCodPostal: [result.empId],
            empNumPhone: [result.empId],
            empActvidadEconomica: [result.empId],
            empCantidadEmpelados: [result.empId],
            empProfilePicture: [result.empId],
            estId: [result.empId],
            estName: [result.empId],
            estColor: [result.empId],
          });
        } else {
          console.error(result);
          this.toast.error('Error al obtener los datos.');
        }
      });
    });
  }
  ngOnDestroy(): void {
    if (this.detailsEmpresaForm) {
      this.detailsEmpresaForm.reset();
    }
  }
  //Funciones
  updateEmpresa(): void {}
  deleteEmpresa(): void {}
}
