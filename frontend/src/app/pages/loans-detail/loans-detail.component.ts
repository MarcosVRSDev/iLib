import { LoansService } from './../../services/loans.service';
import { BooksService } from './../../services/books.service';
import { Books } from './../../models/books.model';
import { Loans } from './../../models/loans.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'ngx-loans-detail',
  styleUrls: ['loans-detail.component.scss'],
  templateUrl: './loans-detail.component.html',
})
export class LoansDetailComponent implements OnInit {
  public loan: Loans;
  public book: Books;
  public form: FormGroup;
  public busy = true;

  constructor(
    private router: ActivatedRoute,
    private loanService: LoansService,
    private bookService: BooksService,
    private fb: FormBuilder) {

    this.form = this.fb.group({
      date: ['', Validators.required],
      obs: ["", Validators.compose([
        Validators.maxLength(250)
      ])]
    })

  }

  ngOnInit(): void {

    let id = parseInt(this.router.snapshot.paramMap.get('id'));
    console.log(id);

    this.loanService.getLoansById(id)
      .subscribe((loan) => {
        this.loan = loan
        setTimeout(() => {
          console.log(this.loan);
          this.retriveBook();
          this.busy = false
        }, 1000);

      });
  }

  retriveBook() {
    this.bookService.getBookById(this.loan.livroId)
      .subscribe((book) => {
        this.book = book;
        console.log(this.book);
      });
  }

  submit() {
    console.log(this.form.value);
  }

}
