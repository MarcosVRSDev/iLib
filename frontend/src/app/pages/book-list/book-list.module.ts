import { BookListComponent } from './book-list.component';
import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule, NbListModule, NbBadgeModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    NbCardModule,
    ThemeModule,
    NbButtonModule,
    NbListModule,
    NbTabsetModule,
    NbCardModule,
    RouterModule,
    NbBadgeModule,
  ],
  declarations: [
    BookListComponent
  ],
})
export class BookListModule { }
