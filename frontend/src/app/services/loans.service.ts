import { Loans } from './../models/loans.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class LoansService {
  
  private api: string = `${environment.api_url}/emprestimos`;

  constructor(private http: HttpClient) { }

  getLoansById(id: number) {
    return this.http.get<Loans>(`${this.api}/${id}`);
  }

  getAllLoans() {
    return this.http.get<Loans[]>(`${this.api}/`);
  }

  getLoansByBookId(id: number) {
    return this.http.get<Loans>(`${this.api}/livro/${id}`)
  }

  getLoansByStatusId(id: number) {
    return this.http.get<Loans[]>(`${this.api}/status/${id}`)

  }

  createLoans(loan: Loans) {
    return this.http.post<Loans>(`${this.api}/`, loan);
  }

  updateLoans(loan: Loans) {
    return this.http.put<Loans>(`${this.api}/`, loan);
  }

  cancelLoans(loan: Loans) {
    return this.http.put<Loans>(`${this.api}/cancelar/`, loan);
  }

  confirmLoans(loan: Loans) {
    return this.http.put<Loans>(`${this.api}/confirmar/`, loan);
  }

  giveBackLoansBook(loan: Loans) {
    return this.http.put<Loans>(`${this.api}/devolver/`, loan);
  }
}