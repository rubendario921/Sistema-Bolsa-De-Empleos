import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { EstadosService } from '../../../services/estados.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import DataTable from 'datatables.net-dt';

@Component({
  selector: 'app-view-status-admin',
  standalone: true,
  imports: [],
  templateUrl: './view-status-admin.component.html',
  styleUrl: './view-status-admin.component.css',
})
export class ViewStatusAdminComponent implements OnInit, OnDestroy {
  //Variables
  //Data for table Estados
  dataTable: any;
  //Resultado de la consulta de la Api
  apiData: any;
  //Reenviar el id Estados
  estId: any;

  constructor(
    private router: Router,
    private estadoService: EstadosService,
    private toast: CustomToastrService
  ) {}
  ngOnInit(): void {
    this.estadoService.getAllEstados().subscribe(
      (result) => {
        this.toast.success('Carga de datos exitosa');
        this.apiData = result;
        //console.log(result);
        this.infoTable();
      },
      (error) => {
        console.error(error);
        this.toast.error('Error al cargar los datos');
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
        { title: '#', data: 'estId' },
        {
          title: 'Nombre',
          data: 'estName',
          render(data: any, type: any, full: any) {
            return `
        <label for="estName" class="fw-semibold" style="color: ${full.estColor};">${full.estName}</label>
        `;
          },
        },
        { title: 'Categoría', data: 'estCategory' },
        {
          title: 'Acción',
          data: 'estId',
          render(data: any, type: any, full: any) {
            //console.log(full);
            return `
          <button class="btn btn-warning btn-sm" onclick="viewEstado(${data})"><i class="bi bi-search"></i></button>
          <button class="btn btn-info btn-sm" onclick="editEstado(${data})"><i class="bi bi-pencil-square"></i></button>
    <button class="btn btn-danger btn-sm" onclick="deleteEstado(${full.estId})"><i class="bi bi-trash2-fill"></i></button>      
    `;
          },
        },
      ],
    });
  }

  //Eliminar el registro
  deleteEstado = (estId: any) => {
    if (confirm('¿Estás seguro de eliminar este registro?')) {
      this.estadoService.deleteEstado(estId).subscribe(
        (result) => {
          this.toast.success('Registro eliminado con éxito');
          this.estadoService.getAllEstados().subscribe(
            (result) => {
              this.apiData = result;
              this.dataTable.destroy();
              this.infoTable();
            },
            (error) => {
              console.error(error);
              this.toast.error('Error al cargar los datos');
            }
          );
        },
        (error) => {
          console.error(error);
          this.toast.error('Error al eliminar el registro');
        }
      );
    }
  };
}
