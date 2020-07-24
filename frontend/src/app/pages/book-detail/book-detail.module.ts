import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { BookDetailComponent } from './book-detail.component';

@NgModule({
  imports: [
    NbCardModule,
    ThemeModule,
    NbButtonModule,
    NbTabsetModule,
  ],
  declarations: [
    BookDetailComponent
  ],
})
export class BookDetailModule { }
