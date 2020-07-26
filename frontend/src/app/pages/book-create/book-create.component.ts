import { Router } from '@angular/router';
import { BooksService } from './../../services/books.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';

@Component({
  selector: 'ngx-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.scss']
})
export class BookCreateComponent implements OnInit {

  public form: FormGroup;
  public busy = false;

  constructor(
    private fb: FormBuilder, 
    private booksService:  BooksService, 
    private router: Router,
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
      fotoUrl: ["", Validators.compose([
        Validators.required
      ])],
      estado: ["", Validators.required]
    })
   }

  ngOnInit(): void {
  }


  submit() {
    
    this.form.value.estado = parseInt(this.form.value.estado);
    this.form.value.fotoUrl = "https://images-na.ssl-images-amazon.com/images/I/41J78Xa7FYL._SX379_BO1,204,203,200_.jpg";

    this.busy = true;
    this.booksService.createBook(this.form.value)
      .subscribe((book) => {
        this.router.navigate(['pages/home'])
        this.showToast('success', 'Livro cadastrado com sucesso');
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
