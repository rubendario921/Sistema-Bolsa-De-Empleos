import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { rolesDTO } from '../../../models/rolesDTO';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { RolesService } from '../../../services/roles.service';
import DataTable from 'datatables.net-dt';
import { catchError } from 'rxjs';

@Component({
    selector: 'app-view-roles-admin',
    imports: [ReactiveFormsModule, CommonModule, FormsModule],
    templateUrl: './view-roles-admin.component.html',
    styleUrl: './view-roles-admin.component.css'
})
export class ViewRolesAdminComponent implements OnInit, OnDestroy {
  //Variables
  dataTable: any;
  apiData: any;
  rolesDetails: rolesDTO[] = [];
  idRol!: number;
  //constructor
  constructor(
    private toast: CustomToastrService,
    private rolService: RolesService
  ) {}

  ngOnInit(): void {
    this.rolService.getAllRoles().subscribe(
      (result) => {
        if (result != null) {
          this.toast.success('Carga de datos exitosa');
          this.apiData = result;
          this.rolesDetails = result;
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
    this.dataTable = new DataTable('#TableRoles', {
      data: this.apiData,
      language: {
        url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json',
      },
      columns: [
        { title: '# Id', data: 'rolId' },
        { title: 'Nombre', data: 'rolName' },
        { title: 'Descripción', data: 'rolDescription' },
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
