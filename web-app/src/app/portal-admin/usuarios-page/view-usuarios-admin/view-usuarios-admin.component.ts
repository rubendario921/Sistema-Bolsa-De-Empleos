import { CommonModule } from '@angular/common';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { UsersService } from '../../../services/users.service';
import DataTable from 'datatables.net-dt';
import { userDTO } from '../../../models/userDTO.interface';
declare var $: any;

@Component({
  selector: 'app-view-usuarios-admin',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './view-usuarios-admin.component.html',
  styleUrl: './view-usuarios-admin.component.css',
})
export class ViewUsuariosAdminComponent implements OnInit, OnDestroy {
  //Variables
  dataTable: any;
  apiData: any;
  usuarioDetail: userDTO[] = [];
  idUsuario!: number;
  //Constructor
  constructor(
    private toast: CustomToastrService,
    private userService: UsersService
  ) {}

  ngOnInit(): void {
    this.userService.getAllUsuarios().subscribe((response: userDTO[]) => {
      if (response) {
        //console.log(response);
        this.toast.success('Carga de datos exitosa');
        this.apiData = response;
        this.usuarioDetail = response;
        this.loadDataTable();
      } else {
        this.toast.error('Error en la carga de datos');
      }
    });
  }
  ngOnDestroy(): void {
    if (this.dataTable) {
      this.dataTable.destroy();
    }
  }
  //Contenido de la tabla
  loadDataTable(): void {
    this.dataTable = new DataTable('#TableUsuarios', {
      data: this.apiData,
      language: {
        url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json',
      },
      columns: [
        { title: '# Id', data: 'usuId' },
        { title: 'Apellidos', data: 'usuLastName' },
        { title: 'Nombres', data: 'usuName' },
        { title: '# DNI', data: 'usuNumDni' },
        { title: 'Rol', data: 'rolName' },
        {
          title: 'Estado',
          data: 'estadoName',
          render(data: any, type: any, full: any) {
            return `<label for="EstadoName" class="fw-semibold" style="color: ${full.estadoColor};">${full.estadoName}</label>`;
          },
        },
        {
          title: 'Acción',
          data: 'usuId',
          render(data: any, type: any, full: any) {
            return `<a href="/usuarios-page/details-usuarios/${full.usuId}" type="button" class="btn btn-warning" title="Ver Detalles"><i class="bi bi-search"></i></a>`;
          },
        },
      ],
    });
  }
}
