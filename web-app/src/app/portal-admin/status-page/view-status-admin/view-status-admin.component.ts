import { Component, OnInit } from '@angular/core';
import { TestApiService } from '../../../services/test-api.service';
import { TestModel } from '../../../models/testModel.interface';
import { CommonModule } from '@angular/common';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-view-status-admin',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './view-status-admin.component.html',
  styleUrl: './view-status-admin.component.css',
})
export class ViewStatusAdminComponent implements OnInit {
  //Variables
  dataTable!: TestModel[];
  userId: any;

  constructor(
    private testApiService: TestApiService,
    private toastr: ToastrService
  ) {}

  //Carga Inicial del componente
  ngOnInit(): void {
    this.testApiService.getAllUsers().subscribe(
      (response: any) => {
        this.dataTable = response.data;
        this.toastr.success('Información cargada exitosamente', 'Correcto');
      },
      (error) => {
        console.error(error);
        this.toastr.error('Error al cargar los datos', 'Incorrecto');
      }
    );
  }
}
