import { NgModule } from '@angular/core';
import { NbMenuModule, NbButtonModule, NbTabsetModule } from '@nebular/theme';

import { ThemeModule } from '../@theme/theme.module';
import { PagesComponent } from './pages.component';
import { HomeModule } from './home/home.module';
import { BookDetailModule } from './book-detail/book-detail.module';
import { PagesRoutingModule } from './pages-routing.module';

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    NbMenuModule,
    NbButtonModule,
    NbTabsetModule,
    HomeModule,
    BookDetailModule,
  ],
  declarations: [
    PagesComponent,
  ],
})
export class PagesModule {
}
