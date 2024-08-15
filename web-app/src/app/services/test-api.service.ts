import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

//Interface
interface DataTest {
  id: number;
  email: string;
  first_name: string;
  last_name: string;
  avatar: string;
}

@Injectable({
  providedIn: 'root',
})
export class TestApiService {
  private apiUrl = 'https://reqres.in/api/users';
  constructor(private http: HttpClient) {}

  getAllUsers(): Observable<DataTest[]> {
    return this.http.get<DataTest[]>(this.apiUrl);
  }
}
