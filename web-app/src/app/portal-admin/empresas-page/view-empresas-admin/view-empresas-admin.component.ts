import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { empresaDTO } from '../../../models/empresasDTO';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { EmpresasService } from '../../../services/empresas.service';
import DataTable from 'datatables.net-dt';

@Component({
  selector: 'app-view-empresas-admin',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, FormsModule],
  templateUrl: './view-empresas-admin.component.html',
  styleUrl: './view-empresas-admin.component.css',
})
export class ViewEmpresasAdminComponent implements OnInit, OnDestroy {
  //Variables
  dataTable: any;
  apiData: any;
  empresaDetail: empresaDTO[] = [];
  empresaId!: number;
  //Constructor
  constructor(
    private toast: CustomToastrService,
    private empresasService: EmpresasService
  ) {
    //Validaciones del Formulario
  }
  ngOnInit(): void {
    //Lamar a Api
    this.empresasService.getAllEmpresas().subscribe(
      (result) => {
        //console.log(result);
        if (result) {
          this.toast.success('Carga de datos exitosa.');
          this.apiData = result;
          this.empresaDetail = result;
          this.loadDataTable();
        } else {
          console.error(result);
          this.toast.error('Error en cargar los datos.');
        }
      },
      (error) => {
        console.error(error);
        this.toast.error('Error en cargar los datos.');
      }
    );
  }
  ngOnDestroy(): void {
    if (this.dataTable) {
      this.dataTable.destroy();
    }
  }
  //Funciones
  //Contenido de la tabla
  loadDataTable(): void {
    this.dataTable = new DataTable('#TableEmpresas', {
      data: this.apiData,
      language: {
        url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json',
      },
      columns: [
        { title: '# Id', data: 'empId' },
        { title: 'Nombre Empresa', data: 'empName' },
        { title: '# RUC', data: 'empNumRuc' },
        {
          title: 'Responsable',
          data: null,
          render(data: any, type: any, full: any) {
            return `${full.empStaffLastName} ${full.empStaffName}`;
          },
        },
        {
          title: 'Estado',
          data: 'estadoName',
          render(data: any, type: any, full: any) {
            return `<label for="EstadoName" class="fw-semibold" style="color: ${full.estColor};">${full.estName}</label>`;
          },
        },
        {
          title: 'Acción',
          data: 'empId',
          render(data: any, type: any, full: any) {
            return `<a href="/empresas-page/details-empresa/${full.empId}" type="button" class="btn btn-warning" title="Ver Detalles"><i class="bi bi-search"></i></a>`;
          },
        },
      ],
    });
  }
}
