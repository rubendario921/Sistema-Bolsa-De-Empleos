import { Component, input, OnDestroy, OnInit, ViewChild } from '@angular/core';
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
import { MatDialog } from '@angular/material/dialog';
import { DetailsStatusAdminComponent } from '../details-status-admin/details-status-admin.component';
import { ReactiveFormsModule } from '@angular/forms';
import { EditStatusAdminComponent } from '../edit-status-admin/edit-status-admin.component';

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
    ReactiveFormsModule 
  ],
  templateUrl: './view-status-admin.component.html',
  styleUrls: ['./view-status-admin.component.css'],
})
export class ViewStatusAdminComponent implements OnInit, OnDestroy {
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
    private toastr: CustomToastrService,
    private dialog:MatDialog
  ) {}

  ngOnInit(): void {
    this.loadstatus();
  }

  ngOnDestroy(): void {      
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
  //Filtro de busqueda
  applyFilter(filterValue: KeyboardEvent): void {
    const inputFilter = event?.target as HTMLInputElement;
    if (inputFilter) {
      const filterValue = inputFilter.value.trim().toLowerCase();
      this.dataSource.filter = filterValue;
    }
  }
//Abrir el Details-Modal
openDetailsModal(status:TestModel):void{
  this.dialog.open(DetailsStatusAdminComponent,{data:status})
}
//Abrir el Edti-Modal
openEditModal(status: TestModel): void {
  const dialogRef = this.dialog.open(EditStatusAdminComponent, {
    data: status,
    width: '600px'
  });

  dialogRef.afterClosed().subscribe(() => {
    this.loadstatus(); // Re-cargar los datos después de editar
  });
}
}
