import { BooksService } from './../../services/books.service';
import { Component, OnInit } from '@angular/core';
import { Books } from '../../models/books.model';

@Component({
  selector: 'ngx-home',
  styleUrls: ['home.component.scss'],
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  
  public availableBooks: Books[];
  public allBooks: Books[];

  constructor(public bookService: BooksService) {
  }
  ngOnInit(): void {
      this.getAllBooks();
      this.getAllAvailableBooks();
      
  }

  getAllBooks() {
    this.bookService.getAllBooks()
        .subscribe((books) => {
          this.allBooks = books;
        });
  }

  getAllAvailableBooks() {
    this.bookService.getAllAvailableBooks()
      .subscribe((books) => {
        this.availableBooks = books;
      });
  }
}
