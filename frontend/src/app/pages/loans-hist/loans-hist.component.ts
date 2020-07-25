import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-loans-hist',
  styleUrls: ['loans-hist.component.scss'],
  templateUrl: './loans-hist.component.html',
})
export class LoansHistComponent implements OnInit {
  constructor(private router: Router) {
  }
  ngOnInit(): void {
  }

  goToDetail() {
    this.router.navigateByUrl('/pages/loans-detail/1');
  }
}
