import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { HomeComponent } from './home.component';
import { DialogPromptComponent } from '../../components/dialog-prompt/dialog-prompt.component';
import { RouterModule } from '@angular/router';

@NgModule({
  imports: [
    NbCardModule,
    ThemeModule,
    NbButtonModule,
    NbTabsetModule,
    RouterModule,
  ],
  declarations: [
    HomeComponent,
    DialogPromptComponent
  ],
})
export class HomeModule { }
