import { Loans } from './../models/loans.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class LoansService {
  public api: string = 'https://localhost:44312/api/emprestimos';

  constructor(private http: HttpClient) { }

  getLoansById(id: number) {
    return this.http.get<Loans>(`${this.api}/${id}`);
  }

  getAllLoans() {
    return this.http.get<Loans>(`${this.api}/`);
  }

  
}