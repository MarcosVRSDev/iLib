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
    return this.http.get<Loans[]>(`${this.api}/`);
  }

  getLoansByBookId(id: number) {
    return this.http.get<Loans>(`${this.api}/livros/${id}`)
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

  cancelLoans(id: number) {
    return this.http.put<Loans>(`${this.api}/cancelar/${id}`, null);
  }

  confirmLoans(id: number) {
    return this.http.put<Loans>(`${this.api}/confirmar/${id}`, null);
  }

  giveBackLoansBook(id: number) {
    return this.http.put<Loans>(`${this.api}/devolver/${id}`, null);
  }



}