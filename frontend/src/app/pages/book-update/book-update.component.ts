import { ActivatedRoute, Router } from '@angular/router';
import { BooksService } from './../../services/books.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { Books } from '../../models/books.model';
import { NbToastrService } from '@nebular/theme';
import { AngularFireStorageReference, AngularFireStorage } from 'angularfire2/storage';

@Component({
  selector: 'ngx-book-update',
  templateUrl: './book-update.component.html',
  styleUrls: ['./book-update.component.scss']
})
export class BookUpdateComponent implements OnInit {

  public form: FormGroup;
  public busy = false;
  public id: number = parseInt(this.activateRouter.snapshot.paramMap.get("id"));
  private ref: AngularFireStorageReference;
  private imageRandomId = `${new Date().getTime()}_${Math.random().toString(36).substring(2)}`;

  constructor(
    private fb: FormBuilder, 
    private bookService: BooksService, 
    private router: Router,
    private activateRouter: ActivatedRoute,
    private toastrService: NbToastrService,
    private afStorage: AngularFireStorage
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


    console.log(this.form.value);

    if (this.form.value.novaFotoUrl != "") {
      this.ref.getDownloadURL().subscribe((ref) => {
        this.form.value.fotoUrl = ref;
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
      });
    } else {
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
  }

  showToast(status, message) {
    this.toastrService.show(null,
      message, { status });
  }

  upload(event) {
    this.ref = this.afStorage.ref(this.imageRandomId);
    this.ref.put(event.target.files[0]);  
  }
}
