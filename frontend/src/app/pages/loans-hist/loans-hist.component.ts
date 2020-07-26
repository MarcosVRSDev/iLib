import { LoansService } from './../../services/loans.service';
import { Loans } from './../../models/loans.model';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-loans-hist',
  styleUrls: ['loans-hist.component.scss'],
  templateUrl: './loans-hist.component.html',
})
export class LoansHistComponent implements OnInit {
  public loans: Loans[];

  constructor(private router: Router, private loanService: LoansService) { }

  ngOnInit(): void {
    this.loanService.getAllLoans()
      .subscribe((loans) => {
        this.loans = loans.slice(0).reverse();
        console.log(loans);
      });
  }

  goToDetail(id) {
    this.router.navigateByUrl(`/pages/loans-detail/${id}`);
  }
}
