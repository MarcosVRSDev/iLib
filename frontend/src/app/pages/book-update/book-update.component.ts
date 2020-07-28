import { UploadFirebaseService } from './../../services/upload-firabse.service';
import { ActivatedRoute, Router } from '@angular/router';
import { BooksService } from './../../services/books.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { AngularFireStorage } from 'angularfire2/storage';

@Component({
  selector: 'ngx-book-update',
  templateUrl: './book-update.component.html',
  styleUrls: ['./book-update.component.scss']
})
export class BookUpdateComponent implements OnInit {

  public form: FormGroup;
  public busy = false;
  public id: number = parseInt(this.activateRouter.snapshot.paramMap.get("id"));

  constructor(
    private fb: FormBuilder, 
    private bookService: BooksService, 
    private router: Router,
    private activateRouter: ActivatedRoute,
    private toastrService: NbToastrService,
    private afStorage: AngularFireStorage,
    private ufService: UploadFirebaseService
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
        fotoUrl: [""],
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

    this.busy = true;
    this.form.value.estado = parseInt(this.form.value.estado);
    this.form.value.id = this.id;
    this.busy = true;

    if (this.form.value.novaFotoUrl != ''){
      this.ufService.uploadFile().then(() => {
        this.ufService.getUrl().subscribe((url) => {
          this.form.value.fotoUrl = url;
          this.updateBook()
        })
      });
    } else {
      this.updateBook();
    }   
  }

  showToast(status, message) {
    this.toastrService.show(null,
      message, { status });
  }

  updateBook() {
    this.bookService.editBook(this.form.value)
      .subscribe((book) => {
        this.router.navigate(['pages/books']);
        this.showToast('success', 'Livro atualizado com sucesso')
        this.busy = false;
      },
      () => {
        this.showToast('danger', 'Não foi possível comunicar com o servidor')
        this.busy = false;
      })
  }

  upload(event) {
    this.ufService.handleFiles(event);
  }
}
