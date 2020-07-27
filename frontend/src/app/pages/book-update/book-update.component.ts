import { ActivatedRoute, Router } from '@angular/router';
import { BooksService } from './../../services/books.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Books } from '../../models/books.model';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'ngx-book-update',
  templateUrl: './book-update.component.html',
  styleUrls: ['./book-update.component.scss']
})
export class BookUpdateComponent implements OnInit {

  public form: FormGroup;
  public busy = false;
  public book: Books;
  public id: number = parseInt(this.activateRouter.snapshot.paramMap.get("id"));

  constructor(
    private fb: FormBuilder, 
    private bookService: BooksService, 
    private router: Router,
    private activateRouter: ActivatedRoute,
    private toastrService: NbToastrService
    ) {
  
      this.form = this.fb.group({
        titulo: ["", Validators.compose([
          Validators.minLength(8),
          Validators.maxLength(60),
          Validators.required
        ])],
        autor: ["", Validators.compose([
          Validators.minLength(4),
          Validators.maxLength(60),
          Validators.required
        ])],
        editora: ["", Validators.compose([
          Validators.minLength(8),
          Validators.maxLength(60),
          Validators.required
        ])],
        codigo: ["", Validators.compose([
          Validators.minLength(1),
          Validators.maxLength(255),
          Validators.required
        ])],
        observacoes: ["", Validators.compose([
          Validators.minLength(8),
          Validators.minLength(1),
          Validators.required
        ])],
        novaFotoUrl: [""],
        estado: ["", Validators.required]
      })

   }

  ngOnInit(): void {
    this.bookService
    .getBookById(this.id)
      .subscribe((book) => {
          this.form.patchValue(book);
      });
  }

  submit() {
    this.form.value.estado = parseInt(this.form.value.estado);
    this.form.value.fotoUrl = "https://images-na.ssl-images-amazon.com/images/I/41J78Xa7FYL._SX379_BO1,204,203,200_.jpg";
    
  
    
    this.form.value.id = this.id;

    this.busy = true;
    this.bookService.editBook(this.form.value)
      .subscribe((book) => {
        this.router.navigate(['pages/books'])
        this.showToast('success', 'Livro atualizado com sucesso')
        this.busy = false;
      },
      () => {
        this.showToast('danger', 'Não foi possível comunicar com o servidor')
        this.busy = false;
      })
  }

  showToast(status, message) {
    this.toastrService.show(null,
      message, { status });
  }

}
