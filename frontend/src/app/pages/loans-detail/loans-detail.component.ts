import { LoansService } from './../../services/loans.service';
import { BooksService } from './../../services/books.service';
import { Books } from './../../models/books.model';
import { Loans } from './../../models/loans.model';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { NbToastrService } from '@nebular/theme';

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
    private route: Router,
    private loanService: LoansService,
    private bookService: BooksService,
    private toastrService: NbToastrService,
    private fb: FormBuilder) {

    this.form = this.fb.group({
      id: '',
      dataPrevDevolucao: '',
      observacao: ['', Validators.compose([
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
          this.retriveBook(loan.livroId);
        }, 1000);
      }, (err) => {
        this.route.navigateByUrl('/');
        this.showToast('danger', 'Não foi possível carregar o empréstimo. Tente novamente.');
        console.log(err);
      });
  }

  retriveBook(id) {
    this.bookService.getBookById(id)
      .subscribe((book) => {
        this.book = book;
        this.busy = false;
      }, (err) => {
        this.route.navigateByUrl('/');
        this.showToast('danger', 'Não foi possível carregar o empréstimo. Tente novamente.');
        console.log(err);
      });
  }

  confirm() {
    this.form.value.id = this.loan.id;
    console.log(this.form.value);
    this.loanService.confirmLoans(this.form.value)
      .subscribe((loan) => {
        this.showToast('success', 'Empréstimo alterado com sucesso.');
        this.route.navigateByUrl('/pages/loans');
      },
        (err) => {
          this.showToast('danger', 'Não foi possível concluir o processo. Tente novamente.');
          console.log(err);
          this.route.navigateByUrl('/pages/loans');
        });
  }

  cancel() {
    this.loanService.cancelLoans(this.loan)
      .subscribe((loan) => {
        this.showToast('success', 'Empréstimo cancelado com sucesso.');
        this.route.navigateByUrl('/pages/loans');
      },
        (err) => {
          this.showToast('danger', 'Não foi possível concluir o processo. Tente novamente.');
          console.log(err);
          this.route.navigateByUrl('/pages/loans');
        });
  }


  submitBook() {
    this.loanService.giveBackLoansBook(this.loan)
      .subscribe((loan) => {
        this.showToast('success', 'Empréstimo finalizado com sucesso.');
        this.route.navigateByUrl('/pages/loans');
      },
        (err) => {
          this.showToast('danger', 'Não foi possível concluir o processo. Tente novamente.');
          console.log(err);
          this.route.navigateByUrl('/pages/loans');
        });
  }


  showToast(status, title) {
    this.toastrService.show(null,
      title, { status });
  }
}
