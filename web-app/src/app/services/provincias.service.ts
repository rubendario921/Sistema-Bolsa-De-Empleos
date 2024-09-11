import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { provinciasDTO } from '../models/provinciasDTO';

@Injectable({
  providedIn: 'root',
})
export class ProvinciasService {
  //Api
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}

  //Métodos
  getAllProvincias(): Observable<any> {
    return this.http.get<provinciasDTO[]>(
      this.apiUrl + 'Provincias/GetAllProvincias'
    );
  }
  getProvinciaById(id: number): Observable<any> {
    return this.http.get<any>(
      this.apiUrl + 'Provincias/GetProvinciaById/' + id
    );
  }

  SaveProvincia(provinciasDTO: provinciasDTO): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'Provincias/SaveProvincia',
      provinciasDTO
    );
  }
  UpdateProvincia(id: number, provinciasDTO: provinciasDTO): Observable<any> {
    return this.http.put<any>(this.apiUrl + '' + id, provinciasDTO);
  }
  DeleteProvincias(id: number): Observable<any> {
    return this.http.delete<any>(
      this.apiUrl + 'Provincias/DeleteProvincia' + id
    );
  }
}
