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
  public displayAdminMenu = false;

  constructor(private translate: TranslateService, private route: Router, private userFactory: UserFactory) {
    var language = localStorage.getItem("Language");
    if (!language) {
      this.translate.setDefaultLang('fr');
    } else {
      this.translate.setDefaultLang(language);
    }

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
