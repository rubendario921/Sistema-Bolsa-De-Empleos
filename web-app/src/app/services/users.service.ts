import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { usuarioDTO } from '../models/userDTOs.interface';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}

  //Métodos
  getAllUsuarios(): Observable<any> {
    return this.http.get<usuarioDTO[]>(this.apiUrl + 'Usuarios/GetAllUsuarios');
  }

  getUsuarioById(id: number): Observable<any> {
    return this.http.get<usuarioDTO[]>(
      this.apiUrl + 'Usuarios/GetUsuarioById/' + id
    );
  }
  saveUsuarios(usuarioDTO: usuarioDTO): Observable<any> {
    return this.http.post<usuarioDTO>(
      this.apiUrl + 'Usuarios/SaveUsuario',
      usuarioDTO
    );
  }
  updateUsuarios(id: number, usuarioDTO: usuarioDTO): Observable<any> {
    return this.http.put<usuarioDTO>(
      this.apiUrl + 'Usuarios/UpdateUsuario/' + id,
      usuarioDTO
    );
  }
  deleteUsuarios(id: number): Observable<any> {
    return this.http.delete<usuarioDTO>(
      this.apiUrl + 'Usuarios/DeleteUsuario/' + id
    );
  }
}
