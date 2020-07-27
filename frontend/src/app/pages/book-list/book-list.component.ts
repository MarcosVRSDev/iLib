import { BooksService } from './../../services/books.service';
import { Component, OnInit } from '@angular/core';
import { Books } from '../../models/books.model';

@Component({
  selector: 'ngx-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.scss']
})
export class BookListComponent implements OnInit {

  public books: Books[];

  constructor(private bookService: BooksService) { }

  ngOnInit(): void {


    this.bookService.getAllBooks()
        .subscribe(
			(books) => {
				this.books = books;
			}
		)

  }

  submit() {
	  
  }

}
