import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { industriaDTO } from '../../../models/industriasDTO.interface';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { IndustriasService } from '../../../services/industrias.service';
import DataTable from 'datatables.net-dt';

@Component({
    selector: 'app-view-industrias-admin',
    imports: [ReactiveFormsModule, CommonModule, FormsModule],
    templateUrl: './view-industrias-admin.component.html',
    styleUrl: './view-industrias-admin.component.css'
})
export class ViewIndustriasAdminComponent implements OnInit, OnDestroy {
  //Variables
  dataTable: any;
  apiData: any;
  industriaDetails: industriaDTO[] = [];
  idIndustria!: number;
  //Constructor
  constructor(
    private toast: CustomToastrService,
    private industriasService: IndustriasService
  ) {}
  //Procesos
  ngOnInit(): void {
    this.industriasService.getAllIndustrias().subscribe(
      (result) => {
        if (result != null) {
          this.toast.success('Carga de datos exitosa');
          this.apiData = result;
          this.industriaDetails = result;
          this.loadDataTable();
        } else {
          console.error(result);
          this.toast.error('Error en cargar los datos');
        }
      },
      (error) => {
        console.error(error);
        this.toast.error('Error en cargar los datos');
      }
    );
  }
  ngOnDestroy(): void {
    if (this.dataTable) {
      this.dataTable.destroy();
    }
  }
  //Funciones
  loadDataTable(): void {
    this.dataTable = new DataTable('#TableIndustrias', {
      data: this.apiData,
      language: {
        url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json',
      },
      columns: [
        { title: '# Id', data: 'indId' },
        { title: 'Nombre', data: 'indName' },
        { title: 'Descripción', data: 'indDetails' },
        {
          title: 'Acción',
          data: 'rolId',
          render(data: any, type: any, full: any) {
            return `<a href="/roles-page/details-status/${full.rolId}" type="button" class="btn btn-warning" title="Ver Detalles"><i class="bi bi-search"></i></a>`;
          },
        },
      ],
    });
  }
}
