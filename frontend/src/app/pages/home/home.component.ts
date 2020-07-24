import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-home',
  styleUrls: ['home.component.scss'],
  templateUrl: './home.component.html',
})
export class HomeComponent {
  private router: Router;

  constructor(router: Router) {
  }
}
