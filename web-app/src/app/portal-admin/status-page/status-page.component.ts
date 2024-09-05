import { Component, OnDestroy, OnInit } from '@angular/core';
import { HeaderAdminComponent } from '../template-admin/header-admin/header-admin.component';
import { FooterAdminComponent } from '../template-admin/footer-admin/footer-admin.component';
import { NavbarAdminComponent } from '../template-admin/navbar-admin/navbar-admin.component';
import { ViewStatusAdminComponent } from './view-status-admin/view-status-admin.component';
import { Router } from '@angular/router';
import { EstadosService } from '../../services/estados.service';
import { CustomToastrService } from '../../services/custom-toastr.service';
import DataTable from 'datatables.net-dt';

@Component({
  selector: 'app-status-page',
  standalone: true,
  imports: [
    HeaderAdminComponent,
    FooterAdminComponent,
    NavbarAdminComponent,
    ViewStatusAdminComponent,
  ],
  templateUrl: './status-page.component.html',
  styleUrl: './status-page.component.css',
})
export class StatusPageComponent implements OnInit, OnDestroy {
  //Data for table Estados
  dataTable: any;
  //Resultado de la consulta de la Api
  apiData: any;
  //Reenviar el id Estados
  estId: any;

  //Constructor
  constructor(
    private router: Router,
    private estadoService: EstadosService,
    private toastr: CustomToastrService
  ) {}

  ngOnInit(): void {
    this.estadoService.getAllEstados().subscribe(
      (result) => {
        this.toastr.success('Carga de datos exitosa');
        this.apiData = result;
        console.log(result);
        this.infoTable();
      },
      (error) => {
        console.error(error);
        this.toastr.error('Error al cargar los datos');
      }
    );
  }

  ngOnDestroy(): void {
    if (this.dataTable) {
      this.dataTable.destroy();
    }
  }
  //Contenido de la tabla
  infoTable(): void {
    this.dataTable = new DataTable('#TableEstados', {
      data: this.apiData,

      language: {
        url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json',
      },
      columns: [
        { title: '#', data: 'estId'},
        { title: 'Nombre', data: 'estName',render(data:any,type:any,full:any){
          return`
          <label for="estName" class="fw-semibold" style="color: ${full.estColor};">${full.estName}</label>
          `;
        } },
        { title: 'Categoria', data: 'estCategory' },
        {
          title: 'Acción',
          data: 'estId',
          render(data: any, type: any, full: any) {
            return `
            <button class="btn btn-warning btn-sm" onclick="viewEstado(${data})">Ver</button>
            <button class="btn btn-info btn-sm" onclick="editEstado(${data})">Editar</button>
      <button class="btn btn-danger btn-sm" onclick="deleteEstado(${data})">Eliminar</button>      
      `;
          },
        },
      ],
    });
  }
}
