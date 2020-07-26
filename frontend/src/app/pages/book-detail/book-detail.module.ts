import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule, NbLayoutModule, NbIconModule, NbListModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { BookDetailComponent } from './book-detail.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    NbCardModule,
    ThemeModule,
    NbButtonModule,
    NbTabsetModule,
    NbLayoutModule,
    NbIconModule,
    RouterModule,
    NbListModule,
  ],
  declarations: [
    BookDetailComponent
  ],
})
export class BookDetailModule { }
