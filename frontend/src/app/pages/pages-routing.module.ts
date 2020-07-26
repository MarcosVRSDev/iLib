import { BookCreateComponent } from './book-create/book-create.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';

import { PagesComponent } from './pages.component';
import { HomeComponent } from './home/home.component';
import { LoansComponent } from './loans/loans.component';
import { LoansHistComponent } from './loans-hist/loans-hist.component';
import { BookDetailComponent } from './book-detail/book-detail.component';
import { LoansDetailComponent } from './loans-detail/loans-detail.component';

const routes: Routes = [{
  path: '',
  component: PagesComponent,
  children: [
    {
      path: 'home',
      component: HomeComponent,
    },
    {
      path: '',
      redirectTo: 'home',
      pathMatch: 'full',
    },
    {
      path: 'book-detail/:id',
      component: BookDetailComponent,
    },
    {
      path: 'loans',
      component: LoansComponent,
    },
    {
      path: 'loans-hist',
      component: LoansHistComponent,
    },
    {
      path: 'loans-detail/:id',
      component: LoansDetailComponent,
    },
    {
      path: 'create-book',
      component: BookCreateComponent,
    },
  ],
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class PagesRoutingModule {
}
