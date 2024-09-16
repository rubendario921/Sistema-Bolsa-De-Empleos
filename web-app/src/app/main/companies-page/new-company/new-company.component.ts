import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { empresaDTO } from '../../../models/empresasDTO';
import { EmpresasService } from '../../../services/empresas.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { Router } from '@angular/router';
import { CantidadEmpleadosService } from '../../../services/cantidad-empleados.service';
import { cantidadEmpleadosDTO } from '../../../models/cantidadEmpleadosDTO.interface';
import { IndustriasService } from '../../../services/industrias.service';
import { industriaDTO } from '../../../models/industriasDTO.interface';

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
  allCantidadEmpresas: cantidadEmpleadosDTO[] = [];
  allIndustrias: industriaDTO[] = [];

  //Constructor
  constructor(
    private empresasService: EmpresasService,
    private fb: FormBuilder,
    private toast: CustomToastrService,
    private router: Router,
    private cantidadEmpresasService: CantidadEmpleadosService,
    private industriasService: IndustriasService
  ) {
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
      staffAddress: ['', [Validators.required]],
      staffPostalCode: ['', [Validators.required]],

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

  ngOnInit(): void {
    this.loadIndustrias();
    this.loadCantidadEmpresas();
  }

  ngOnDestroy(): void {
    this.registerStaff.reset();
  }

  registerNewEmpresa() {
    if (this.registerStaff.valid) {
      let empresaData = this.registerStaff.value;
      let empresaDTO: empresaDTO = {
        empId: 0,
        empStaffName: empresaData.staffName,
        empStaffLastName: empresaData.staffLastName,
        empStaffEmail: empresaData.staffEmail,
        empStaffPassword: empresaData.staffPassword,
        empName: empresaData.staffBusinessName,
        empRazonSocial: empresaData.staffBusinessName,
        empNumRuc: empresaData.staffRuc,
        empDireccion: empresaData.staffAddress,
        empCodPostal: empresaData.staffPostalCode,
        empNumPhone: empresaData.staffNumContact,
        empProfilePicture: '',
        estId: 1,
        estName: '',
        estColor: '',
        indId: empresaData.staffIndustry,
        indName: '',
        cantEmpID: empresaData.StaffCount,
        cantEmpDetails: '',
      };
      this.empresasService.saveEmpresa(empresaDTO).subscribe((result) => {
        if (result) {
          console.log(result);
          this.toast.success('Empresa registrada con éxito');
        } else {
          console.log('Error en crear la empresa.');
          this.toast.error('Error en crear la empresa.');
        }
      });
    } else {
      this.registerStaff.markAllAsTouched();
    }
  }

  viewPassword(): void {
    this.viewPasswordInput = !this.viewPasswordInput;
  }
  viewConfirmPassword(): void {
    this.viewConfirmPasswordInput = !this.viewConfirmPasswordInput;
  }

  //Cantidad Empleados
  loadCantidadEmpresas(): void {
    this.cantidadEmpresasService
      .getAllCantidadEmpleados()
      .subscribe((result) => {
        if (result) {
          console.log(result);
          this.allCantidadEmpresas = result;
        }
      });
  }
  //Industrias
  loadIndustrias(): void {
    this.industriasService.getAllIndustrias().subscribe((result) => {
      if (result) {
        console.log(result);
        this.allIndustrias = result;
      }
    });
  }
}
