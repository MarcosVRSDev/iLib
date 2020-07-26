import { ReactiveFormsModule } from '@angular/forms';
import { NbCardModule, NbSpinnerModule, NbListModule, NbRadioModule, NbInputModule, NbButtonModule, NbTabsetModule, NbDatepickerModule, NbTooltipModule } from '@nebular/theme';
import { BookUpdateComponent } from './book-update.component';
import { NgModule } from '@angular/core';
import { ThemeModule } from '../../@theme/theme.module';
import { RouterModule } from '@angular/router';


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
    BookUpdateComponent
  ],
})
export class BookUpdateModule { }
