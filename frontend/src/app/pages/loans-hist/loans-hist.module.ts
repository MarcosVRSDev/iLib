import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule, NbListModule, NbBadgeModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { LoansHistComponent } from './loans-hist.component';
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
    LoansHistComponent
  ],
})
export class LoansHistModule { }
