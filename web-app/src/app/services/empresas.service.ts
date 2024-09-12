import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs/internal/Observable';
import { empresaDTO } from '../models/empresasDTO';

@Injectable({
  providedIn: 'root',
})
export class EmpresasService {
  //Api
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}
  //Métodos
  getAllEmpresas(): Observable<any> {
    return this.http.get<empresaDTO[]>(this.apiUrl + 'Empresas/GetAllEmpresas');
  }

  getEmpresaById(id: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + 'Empresas/GetEmpresaById/' + id);
  }

  saveEmpresa(empresaDTO: empresaDTO): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'Empresas/SaveEmpresa',
      empresaDTO
    );
  }

  updateEmpresa(id: number, empresaDTO: empresaDTO): Observable<any> {
    return this.http.put<any>(
      this.apiUrl + 'Empresas/UpdateEmpresa/' + id,
      empresaDTO
    );
  }

  deleteEmpresa(id: number): Observable<any> {
    return this.http.delete<any>(this.apiUrl + 'Empresas/DeleteEstado/' + id);
  }
}
