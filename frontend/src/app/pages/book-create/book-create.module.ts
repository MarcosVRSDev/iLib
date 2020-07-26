import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule, NbListModule, NbBadgeModule, NbInputModule, NbDatepickerModule, NbTooltipModule, NbRadioModule, NbSpinnerModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { RouterModule } from '@angular/router';
import { BookCreateComponent } from './book-create.component';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  imports: [
    NbCardModule,
    ThemeModule,
    NbButtonModule,
    NbListModule,
    NbCardModule,
    RouterModule,
    NbTabsetModule,
    NbInputModule,
    NbDatepickerModule,
    NbTooltipModule,
    NbRadioModule,
    ReactiveFormsModule,
    NbSpinnerModule,
  ],
  declarations: [
    BookCreateComponent
  ],
})
export class BookCreateModule { }