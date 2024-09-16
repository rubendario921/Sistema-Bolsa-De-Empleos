import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../environment/environment.development';
import { loginDTO } from '../models/loginDTOs.interface';
import { Observable, tap } from 'rxjs';
import { forgotDTO } from '../models/forgotDTOs.interface';
import { loginEmpresasDTO } from '../models/loginEmpresasDTO.interface';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private apiUrl = environment.apiURL;
  private accessTokenKey = 'access_token';
  public userInfoKey = 'userInfo';

  constructor(private http: HttpClient) {}

  //Obtener el token
  getToken(): string | null {
    return localStorage.getItem(this.accessTokenKey);
  }
  //Almacenar token
  setToken(token: string): void {
    localStorage.setItem(this.accessTokenKey, token);
  }
  //Eliminar token
  removeToken(): void {
    localStorage.removeItem(this.accessTokenKey);
  }

  //Auth
  isAuthenticated(): boolean {
    const token = this.getToken();
    return !!token;
  }

  //Método Login
  loginUser(loginDTO: loginDTO): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}auth`, loginDTO).pipe(
      tap((response) => {
        if (response) {
          this.setToken(response.token);
          const userInfo = {
            usuName: response.usuName,
            usuLastName: response.usuLastName,
            usuNumDni: response.usuNumDni,
            rolName: response.rolName,
          };
          localStorage.setItem(this.userInfoKey, JSON.stringify(userInfo));
          console.log('Inicio de sesión correcto', response);
        } else {
          console.error('Inicio de sesión incorrecto:');
        }
      })
    );
  }

  //Método LoginCompanies
  loginEmpresas(loginEmpresasDTO: loginEmpresasDTO): Observable<any> {
    return this.http.post<any>(
      this.apiUrl + 'Authentication/AuthEmpresas',
      loginEmpresasDTO
    );
  }

  //Método Forgot
  forgotLogin(forgotDTO: forgotDTO): Observable<any> {
    return this.http.put(`${this.apiUrl}forgotUser`, forgotDTO).pipe(
      tap(
        (response) => {
          console.log('Usuario modificado correctamente', response);
        },
        (error) => {
          console.error('Error al modificar usuario', error);
        }
      )
    );
  }

  //Método LogOut
  logOut(): void {
    this.removeToken();
    localStorage.removeItem(this.userInfoKey);
  }
}
