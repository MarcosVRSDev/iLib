import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Loans } from '../../models/loans.model';
import { LoansService } from '../../services/loans.service';

@Component({
  selector: 'ngx-loans',
  styleUrls: ['loans.component.scss'],
  templateUrl: './loans.component.html',
})
export class LoansComponent implements OnInit {
  public pendingLoans: Loans[] = [];
  public loanedLoans: Loans[] = [];
  public busy = true;

  constructor(private router: Router,
    private loanService: LoansService,) {
  }
  ngOnInit(): void {

    this.loanService.getLoansByStatusId(0)
      .subscribe((loans) => {
        this.pendingLoans = loans;
      });

    this.loanService.getLoansByStatusId(1)
      .subscribe((loans) => {
        this.loanedLoans = loans;
      });
  }

  goToDetail(id) {
    this.router.navigateByUrl(`/pages/loans-detail/${id}`);
  }
}
