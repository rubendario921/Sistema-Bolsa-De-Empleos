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
}
