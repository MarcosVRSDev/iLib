import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-loans-detail',
  styleUrls: ['loans-detail.component.scss'],
  templateUrl: './loans-detail.component.html',
})
export class LoansDetailComponent implements OnInit {
  constructor(private router: Router) {
  }
  ngOnInit(): void {
  }

}
