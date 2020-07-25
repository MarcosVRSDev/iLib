import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule, NbLayoutModule, NbIconModule } from '@nebular/theme';

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
  ],
  declarations: [
    BookDetailComponent
  ],
})
export class BookDetailModule { }
