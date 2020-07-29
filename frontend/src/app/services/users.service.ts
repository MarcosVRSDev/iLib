import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class UsersService {

  private api: string = `${environment.api_url}/usuarios`;

  constructor(private http: HttpClient) { }

  getAllUsers() {
    return this.http.get<any[]>(`${this.api}`);
  }

  createUser(user: any) {
    return this.http.post(`${this.api}`, user);
  }
}