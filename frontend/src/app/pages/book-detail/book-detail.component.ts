import { Loans } from './../../models/loans.model';
import { BooksService } from './../../services/books.service';
import { Component, OnInit } from '@angular/core';
import { NbDialogService, NbToastrService } from '@nebular/theme';
import { DialogPromptComponent } from '../../components/dialog-prompt/dialog-prompt.component';
import { Books } from '../../models/books.model';
import { ActivatedRoute, Router } from '@angular/router';
import { LoansService } from '../../services/loans.service';

@Component({
  selector: 'ngx-book-detail',
  styleUrls: ['book-detail.component.scss'],
  templateUrl: './book-detail.component.html',
})
export class BookDetailComponent implements OnInit {

  public book: Books;
  public loan: Loans;
  public loanCreate: Loans;
  public busy = false;

  constructor(
    private dialogService: NbDialogService, 
    private bookService: BooksService,
    private loanService: LoansService,
    private toastrService: NbToastrService, 
    private activeRouter: ActivatedRoute,
    private router: Router) {
  }
  ngOnInit(): void {

    const id = parseInt(this.activeRouter.snapshot.paramMap.get("id"));

    this.bookService.getBookById(id)
        .subscribe((book) => {
          this.book = book;
          if(this.book.emprestado) {
                this.retriveLoan(id);
          } else {
            this.busy = true;
          } 
        });
  }


  retriveLoan(id: number) {
      this.loanService.getLoansByBookId(id)
          .subscribe((loan) => {
            this.loan = loan;
            this.busy = true;
          });
  }


  confirmLoans() {
    const createLoan: Loans = {'livroId': this.book.id, 'usuarioId' : 'Laender Morais'};
    this.loanService.createLoans(createLoan)
        .subscribe(() => {
          this.router.navigateByUrl('/');
          this.showToast('success', 'Solicitação de emprestimo efetuada');
        },
        () => {
          this.showToast('danger', 'Não foi possível comunicar com o servidor')
        });
  }

  open() {
    this.dialogService
    .open(
      DialogPromptComponent, 
      { context : 
        {'title' : 'Confirmação de empréstimo', 
        'description' : "Ao clicar em 'Confimar', você irá abrir uma solicitação para aprovação do emprestimo deste livro. Parafinalizar o empréstimo, você deverá retirar o livro junto ao responsável. Confirma a solicitação?",      
      }})
      .onClose.subscribe(confirm => {
        if(confirm) {
          this.confirmLoans();
        }
      });
  }

  showToast(status, message) {
    this.toastrService.show(null,
      message, { status });
  }
}
