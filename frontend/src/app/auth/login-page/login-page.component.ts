import { Component, OnInit } from '@angular/core';

import { AngularFireAuth } from '@angular/fire/auth';
import * as firebase from 'firebase';
import { UsersService } from '../../services/users.service';

@Component({
  selector: 'ngx-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {
  public isValidLogin = true;
  public user: any = {
    uid: "",
    nome: "",
    email: ""
  }

  constructor(
    private afAuth: AngularFireAuth,
    private usersService: UsersService
  ) { }

  ngOnInit(): void {
  }

  login() {
    this.afAuth
      .signInWithPopup(new firebase.auth.GoogleAuthProvider());

    /*
    Cadastro do usuario
    .then(data => {
      this.user.uid = data.user.uid;
      this.user.name = data.user.displayName;
      this.user.email = data.user.email;

      this.usersService.createUser(this.user)
        .subscribe(user => {
          console.log(user);
        });
    });*/
  }

}
