import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-loans',
  styleUrls: ['loans.component.scss'],
  templateUrl: './loans.component.html',
})
export class LoansComponent implements OnInit {
  constructor(private router: Router) {
  }
  ngOnInit(): void {
  }

  goToDetail() {
    this.router.navigateByUrl('/pages/loans-detail/1');
  }
}
