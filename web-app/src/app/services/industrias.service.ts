import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { industriaDTO } from '../models/industriasDTO.interface';

@Injectable({
  providedIn: 'root',
})
export class IndustriasService {
  //Api
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}

  //Métodos
  getAllIndustrias(): Observable<any> {
    return this.http.get<industriaDTO[]>(
      this.apiUrl + 'Industrias/GetAllIndustrias'
    );
  }
  getIndustriaById(id: number): Observable<any> {
    return this.http.get<any>(
      this.apiUrl + 'Industrisas/GetIndustriaById/' + id
    );
  }

  SaveIndustria(industriaDTO: industriaDTO): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'Industrias/SaveIndustria',
      industriaDTO
    );
  }
  UpdateIndustria(id: number, industriaDTO: industriaDTO): Observable<any> {
    return this.http.put<any>(this.apiUrl + '' + id, industriaDTO);
  }
  DeleteIndustria(id: number): Observable<any> {
    return this.http.delete<any>(
      this.apiUrl + 'Industrias/DeleteIndustria' + id
    );
  }
}
