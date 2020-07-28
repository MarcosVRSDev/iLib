import { environment } from './../../environments/environment';
import { BookUpdateModule } from './book-update/book-update.module';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { NbMenuModule, NbButtonModule, NbTabsetModule, NbIconModule, NbListModule, NbBadgeModule, NbInputModule } from '@nebular/theme';
import { AngularFireStorageModule } from 'angularfire2/storage';
import { AngularFireModule } from 'angularfire2';

import { ThemeModule } from '../@theme/theme.module';
import { PagesComponent } from './pages.component';
import { HomeModule } from './home/home.module';
import { LoansModule } from './loans/loans.module';
import { LoansDetailModule } from './loans-detail/loans-detail.module';
import { BookDetailModule } from './book-detail/book-detail.module';
import { PagesRoutingModule } from './pages-routing.module';
import { RouterModule } from '@angular/router';
import { BookListModule } from './book-list/book-list.module';

@NgModule({
  imports: [
    RouterModule,
    PagesRoutingModule,
    ThemeModule,
    NbMenuModule,
    NbButtonModule,
    NbTabsetModule,
    NbListModule,
    HomeModule,
    BookDetailModule,
    LoansModule,
    LoansDetailModule,
    NbIconModule,
    NbBadgeModule,
    NbInputModule,
    ReactiveFormsModule,
    BookUpdateModule,
    BookListModule,
    AngularFireModule.initializeApp({
      apiKey: environment.firebase.apiKey,
      authDomain: environment.firebase.authDomain,
      storageBucket: environment.firebase.storageBucket,
      projectId: environment.firebase.projectId,
    }),
    AngularFireStorageModule
  ],
  declarations: [
    PagesComponent
  ],
})
export class PagesModule {
}
