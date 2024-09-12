import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../environment/environment';
import { userDTO } from '../models/userDTO.interface';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}

  //Métodos
  getAllUsuarios(): Observable<any> {
    return this.http.get<userDTO[]>(this.apiUrl + 'Usuarios/GetAllUsuarios');
  }

  getUsuarioById(id: number): Observable<any> {
    return this.http.get<userDTO[]>(
      this.apiUrl + 'Usuarios/GetUsuarioById/' + id
    );
  }
  saveUsuarios(usuarioDTO: userDTO): Observable<any> {
    return this.http.post<userDTO>(
      this.apiUrl + 'Usuarios/SaveUsuarios',
      usuarioDTO
    );
  }
  updateUsuarios(id: number, usuarioDTO: userDTO): Observable<any> {
    return this.http.put<userDTO>(
      this.apiUrl + 'Usuarios/UpdateUsuario/' + id,
      usuarioDTO
    );
  }
  deleteUsuarios(id: number): Observable<any> {
    return this.http.delete<userDTO>(
      this.apiUrl + 'Usuarios/DeleteUsuario/' + id
    );
  }
}
