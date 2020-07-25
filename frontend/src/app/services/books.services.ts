import { Books } from './../models/books.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})

export class BooksService {
  public api: string = 'https://localhost:44312/api/livros'

  constructor(private http: HttpClient) { }

  getAllBooks() {
    return this.http.get<Books[]>(`${this.api}`);
  }

  getBookById(id: number) {
    return this.http.get<Books>(`${this.api}/${id}`);
  }

  getAllAvailableBooks() {
    return this.http.get<Books[]>(`${this.api}/disponiveis`);
  }

  createBook(book: Books) {
    return this.http.post(`${this.api}`, book);
  }

  editBook(book: Books) {
    return this.http.put(`${this.api}`, book);
  }

  deleteBook(id: number) {
    return this.http.delete(`${this.api}/${id}`);
  }

}