import { Component, OnDestroy, OnInit, Renderer2 } from '@angular/core';
import { Router } from '@angular/router';
import { EstadosService } from '../../../services/estados.service';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import DataTable from 'datatables.net-dt';
import { estadoDTO } from '../../../models/estadosDTO.interface';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
declare var $: any;

@Component({
    selector: 'app-view-status-admin',
    imports: [CommonModule, FormsModule],
    templateUrl: './view-status-admin.component.html',
    styleUrl: './view-status-admin.component.css'
})
export class ViewStatusAdminComponent implements OnInit, OnDestroy {
  //Data for table Estados
  dataTable: any;
  //Resultado de la consulta de la Api
  apiData: any;
  //Reenviar el id Estados
  estadoDetail: estadoDTO[] = [];
  idEditar!: number;

  constructor(
    private router: Router,
    private estadoService: EstadosService,
    private toast: CustomToastrService,
    private renderer: Renderer2
  ) {}

  ngOnInit(): void {
    this.estadoService.getAllEstados().subscribe(
      (result) => {
        this.toast.success('Carga de datos exitosa');
        this.apiData = result;
        this.estadoDetail = result;
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
        { title: '# Id', data: 'estId' },
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
            return `<a href="/status-page/details-status/${full.estId}" type="button" class="btn btn-warning" title="Ver Detalles"><i class="bi bi-search"></i></a>`;
          },
        },
      ],
    });
  }
}
