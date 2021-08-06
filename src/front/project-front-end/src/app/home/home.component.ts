import { Component, OnInit } from '@angular/core';
import { UserFactory } from '../factories/user.factory';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  user_name = "";
  user_pwd = "";

  constructor(private userFactory: UserFactory) {
  }

  ngOnInit(): void {
  }

  public ConnectUser() {
    if (!this.user_name || !this.user_pwd) {
      return;
    }

    var a = this.userFactory.connectUser(this.user_name, this.user_pwd);
    console.log(a);
  }

}
