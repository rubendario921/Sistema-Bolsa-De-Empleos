import { Component, input, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { MatCardModule } from '@angular/material/card';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { CommonModule } from '@angular/common';
import { TestApiService } from '../../../services/test-api.service';
import { TestModel } from '../../../models/testModel.interface';
import { CustomToastrService } from '../../../services/custom-toastr.service';
import { MatSort } from '@angular/material/sort';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-view-status-admin',
  standalone: true,
  imports: [
    CommonModule,
    MatCardModule,
    MatTableModule,
    MatPaginatorModule,
    MatFormFieldModule,
    MatInputModule,
  ],
  templateUrl: './view-status-admin.component.html',
  styleUrls: ['./view-status-admin.component.css'],
})
export class ViewStatusAdminComponent implements OnInit {
  displayedColumns: string[] = [
    'id',
    'first_name',
    'last_name',
    'email',
    'avatar',
    'actions',
  ];
  dataSource = new MatTableDataSource<TestModel>();
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private testApiService: TestApiService,
    private toastr: CustomToastrService
  ) {}

  ngOnInit(): void {
    this.loadstatus();
  }

  loadstatus(): void {
    this.testApiService.getAllUsers().subscribe(
      (result: any) => {
        this.dataSource.data = result.data;
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
        this.toastr.success('Información cargada exitosamente', 'Correcto');
      },
      (error) => {
        console.error(error);
        this.toastr.error('Error al cargar los datos', 'Error');
      }
    );
  }
  applyFilter(filterValue: KeyboardEvent): void {
    const inputFilter = event?.target as HTMLInputElement;
    if (inputFilter) {
      const filterValue = inputFilter.value.trim().toLowerCase();
      this.dataSource.filter = filterValue;
    }
  }
}
