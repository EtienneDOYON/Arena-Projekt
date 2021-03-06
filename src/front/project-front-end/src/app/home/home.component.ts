import { Component, OnInit } from '@angular/core';
import { UserFactory } from '../factories/user.factory';
import { WarriorFactory } from '../factories/warrior.factory';
import { Router } from '@angular/router';

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

  constructor(private userFactory: UserFactory, private warriorFactory: WarriorFactory, private route: Router) {
    localStorage.removeItem("UserToken");
  }

  ngOnInit(): void {
    localStorage.removeItem("UserToken");
  }

  public async ConnectUser() {
    if (!this.user_name || !this.user_pwd) {
      return;
    }

    var connectionResult = await this.userFactory.connectUser(this.user_name, this.user_pwd);

    if (!connectionResult) {
      this.LogInFailure = true;
      this.LogInSuccess = false;
    } else {
      localStorage.setItem("UserToken", connectionResult.access_token);
      this.route.navigate(['/team_warriors']);
    }
  }

  public async CheckToken() {
    var connectionResult = await this.warriorFactory.GetAllWarriors();
  }

}
