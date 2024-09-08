import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { estadoDTO } from '../models/estadosDTO.interface';

@Injectable({
  providedIn: 'root',
})
export class EstadosService {
  //Api
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}

  //Métodos
  getAllEstados(): Observable<any> {
    return this.http.get<estadoDTO[]>(this.apiUrl + 'Estados/GetAllEstados');
  }

  getEstadoById(id: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + 'Estados/GetEstadosById/' + id);
  }

  saveEstado(estadoDTO: estadoDTO): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'Estados/SaveEstado', estadoDTO);
  }
  updateEstado(id: number, estadoDTO: estadoDTO): Observable<any> {
    return this.http.put<any>(
      this.apiUrl + 'Estados/UpdateEstado/' + id,
      estadoDTO
    );
  }
  deleteEstado(id: number): Observable<any> {
    return this.http.delete<any>(this.apiUrl + 'Estados/DeleteEstado/' + id);
  }
}
