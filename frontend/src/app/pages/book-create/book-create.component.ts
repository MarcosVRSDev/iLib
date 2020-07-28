import { Router } from '@angular/router';
import { BooksService } from './../../services/books.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NbToastrService } from '@nebular/theme';
import { AngularFireStorage, AngularFireStorageReference } from 'angularfire2/storage';

@Component({
  selector: 'ngx-book-create',
  templateUrl: './book-create.component.html',
  styleUrls: ['./book-create.component.scss']
})
export class BookCreateComponent implements OnInit {

  public form: FormGroup;
  public busy = false;
  private ref: AngularFireStorageReference;
  private imageRandomId = `${new Date().getTime()}_${Math.random().toString(36).substring(2)}`;

  constructor(
    private fb: FormBuilder, 
    private booksService:  BooksService, 
    private router: Router,
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
      fotoUrl: ["", Validators.compose([
        Validators.required
      ])],
      estado: ["", Validators.required]
    })
   }

  ngOnInit(): void {
  }


  submit() {
    this.busy = true;
    
    this.form.value.estado = parseInt(this.form.value.estado);

    

    this.ref.getDownloadURL().subscribe((ref) => {
      this.form.value.fotoUrl = ref;
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
    
    });
    
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
