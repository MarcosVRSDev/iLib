import { BooksService } from './../../services/books.service';
import { Component, OnInit } from '@angular/core';
import { NbDialogService } from '@nebular/theme';
import { DialogPromptComponent } from '../../components/dialog-prompt/dialog-prompt.component';
import { Books } from '../../models/books.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'ngx-book-detail',
  styleUrls: ['book-detail.component.scss'],
  templateUrl: './book-detail.component.html',
})
export class BookDetailComponent implements OnInit {

  public book: Books;

  constructor(
    private dialogService: NbDialogService, 
    private bookService: BooksService, 
    private router: ActivatedRoute) {
  }
  ngOnInit(): void {

    const id = parseInt(this.router.snapshot.paramMap.get("id"));
    
    this.bookService.getBookById(id)
        .subscribe((book) => {
          this.book = book;
        },
        (() => {
          console.log("Erro")
        }));
  }
  open() {
    this.dialogService.open(DialogPromptComponent);
  }
}
