import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { HttpClient } from '@angular/common/http';
import { rolesDTO } from '../models/rolesDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class RolesService {
  //Api
  private apiUrl = environment.apiURL;
  constructor(private http: HttpClient) {}
  //Métodos
  getAllRoles(): Observable<any> {
    return this.http.get<rolesDTO[]>(this.apiUrl + 'Roles/GetAllRoles');
  }

  getRolById(id: number): Observable<any> {
    return this.http.get<any>(this.apiUrl + 'Roles/GetAllRoles/' + id);
  }

  saveRol(rolDTO: rolesDTO): Observable<any> {
    return this.http.post<any>(this.apiUrl + 'Roles/SaveRol', rolDTO);
  }
  updateRol(id: number, rolDTO: rolesDTO): Observable<any> {
    return this.http.put<any>(this.apiUrl + 'Roles/UpdateRol/' + id, rolDTO);
  }
  deleteRol(id: number): Observable<any> {
    return this.http.delete<any>(this.apiUrl + 'Roles/DeleteRol/' + id);
  }
}
