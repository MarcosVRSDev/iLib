/**
 * @license
 * Copyright Akveo. All Rights Reserved.
 * Licensed under the MIT License. See License.txt in the project root for license information.
 */
import { Component, OnInit } from '@angular/core';
import { AnalyticsService } from './@core/utils/analytics.service';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';

@Component({
  selector: 'ngx-app',
  template: '<router-outlet></router-outlet>',
})
export class AppComponent implements OnInit {

  constructor(
    private analytics: AnalyticsService,
    private afAuth: AngularFireAuth,
    private router: Router
  ) {
  }

  ngOnInit() {
    this.analytics.trackPageViews();

    this.afAuth.onAuthStateChanged(data => {
      /*let email = data.email.split('@')[1]; && email == 'inovamobil.com.br'*/
      if (data) {
        this.router.navigateByUrl('/');
      } else {
        this.router.navigateByUrl('/auth/login');
      }
    });
  }
}
