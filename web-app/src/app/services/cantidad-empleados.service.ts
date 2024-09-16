import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { cantidadEmpleadosDTO } from '../models/cantidadEmpleadosDTO.interface';
import { observableToBeFn } from 'rxjs/internal/testing/TestScheduler';

@Injectable({
  providedIn: 'root',
})
export class CantidadEmpleadosService {
  //Api
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}
  //Métodos
  getAllCantidadEmpleados(): Observable<any> {
    return this.http.get<cantidadEmpleadosDTO[]>(
      this.apiUrl + 'CantidadEmpleados/GetAllCantidadEmpleados'
    );
  }

  getCantidadEmpleadoById(id: number): Observable<any> {
    return this.http.get<cantidadEmpleadosDTO[]>(
      this.apiUrl + 'CantidadEmpleados/GetCantidadEmpleadoById' + id
    );
  }

  saveCantidadEmpleado(
    cantidadEmpleadosDTO: cantidadEmpleadosDTO
  ): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'CantidadEmpleados/SaveCantidadEmpleado',
      cantidadEmpleadosDTO
    );
  }

  updateCantidadEmpleado(
    id: number,
    cantidadEmpleadosDTO: cantidadEmpleadosDTO
  ): Observable<any> {
    return this.http.put<any>(
      this.apiUrl + 'CantidadEmpleados/UpdateCantidadEmpleado' + id,
      cantidadEmpleadosDTO
    );
  }

  deleteCantidadEmpleado(id: number): Observable<any> {
    return this.http.delete<any>(
      this.apiUrl + 'CantidadEmpleados/DeleteCantidadEmpleado' + id
    );
  }
}
