import { NgModule } from '@angular/core';
import { NbCardModule, NbButtonModule, NbTabsetModule, NbListModule, NbBadgeModule, NbLayoutModule } from '@nebular/theme';

import { ThemeModule } from '../../@theme/theme.module';
import { LoginPageComponent } from './login-page.component';
import { RouterModule } from '@angular/router';
import { NbEvaIconsModule } from '@nebular/eva-icons';

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
    NbLayoutModule,
    NbEvaIconsModule,
    NbCardModule
  ],
  declarations: [
    LoginPageComponent
  ],
})
export class LoginPageModule { }