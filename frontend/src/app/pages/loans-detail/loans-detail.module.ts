import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbListModule, NbTabsetModule, NbInputModule, NbDatepickerModule, NbTooltipModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { LoansDetailComponent } from './loans-detail.component';
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
  ],
  declarations: [
    LoansDetailComponent
  ],
})
export class LoansDetailModule { }
