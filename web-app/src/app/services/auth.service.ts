import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { tokenToString } from 'typescript';

//interface
interface loginUser{
  usuNumDni: string | null;
  usuPassword:string | null;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl ='';
  private accessTokenKey = 'access_token';
  private userInforKey = 'user_info';

  constructor(private http:HttpClient) { }

//Obtener el token
  getToken():string | null{
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
}
