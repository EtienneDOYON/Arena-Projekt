import { Component } from '@angular/core';
import {TranslateService} from '@ngx-translate/core';
import { Router } from '@angular/router';
import { UserFactory } from './factories/user.factory';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'God\'s Game';

  public isUserConnected = false;

  constructor(private translate: TranslateService, private route: Router, private userFactory: UserFactory) {
    translate.setDefaultLang('fr');

    route.events.subscribe((val) => {
      var auth_token = localStorage.getItem("UserToken");

      if (auth_token) {
        this.isUserConnected = true;
      }
    });
  }

  public async LogOut() {
    this.isUserConnected = false;
    this.userFactory.LogOut();
  }
}
