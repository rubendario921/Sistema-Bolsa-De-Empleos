import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, ObservedValueOf } from 'rxjs';
import { environment } from '../environment/environment';
import { usuarioDTO } from '../models/userDTOs.interface';

@Injectable({
  providedIn: 'root',
})
export class UsersService {
  private apiUrl = environment.apiURL;

  constructor(private http: HttpClient) {}

  getAllUsuarios(): Observable<usuarioDTO[]> {
    return this.http.get<usuarioDTO[]>(
      `${this.apiUrl}/Usuarios/GetAllUsuarios`
    );
  }

  getAllUsuarioById(id: number): Observable<usuarioDTO[]> {
    return this.http.get<usuarioDTO[]>(
      `${this.apiUrl}/Usuarios/GetUsuarioById/${id}`
    );
  }

  // getUser(id: number): Observable<User> {
  //   return this.http.get<User>(`${this.apiUrl}/${id}`);
  // }

  // createUser(user: User): Observable<User> {
  //   return this.http.post<User>(this.apiUrl, user);
  // }

  // updateUser(id: number, user: User): Observable<User> {
  //   return this.http.put<User>(`${this.apiUrl}/${id}`, user);
  // }

  // deleteUser(id: number): Observable<void> {
  //   return this.http.delete<void>(`${this.apiUrl}/${id}`);
  // }
}
