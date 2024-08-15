import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { TestModel } from '../models/testModel.interface';

@Injectable({
  providedIn: 'root',
})
export class TestApiService {
  private apiUrl = 'https://reqres.in/api';
  constructor(private http: HttpClient) {}

  getAllUsers() {
    return this.http.get<TestModel[]>(this.apiUrl + '/users');
  }
}
