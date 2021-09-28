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

  LogInFailure = false;
  LogInSuccess = false;

  constructor(private userFactory: UserFactory) {
  }

  ngOnInit(): void {
  }

  public async ConnectUser() {
    if (!this.user_name || !this.user_pwd) {
      return;
    }

    var connectionResult = await this.userFactory.connectUser(this.user_name, this.user_pwd);

    if (connectionResult == "false") {
      this.LogInFailure = true;
      this.LogInSuccess = false;
    } else if (connectionResult == "true") {
      this.LogInFailure = false;
      this.LogInSuccess = true;
    }
  }

}
