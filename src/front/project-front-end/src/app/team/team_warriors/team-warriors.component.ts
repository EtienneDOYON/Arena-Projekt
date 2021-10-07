import { Component, OnInit } from '@angular/core';
import { UserFactory } from '../../factories/user.factory';
import { WarriorFactory } from '../../factories/warrior.factory';

@Component({
  selector: 'app-home',
  templateUrl: './team-warriors.component.html',
  styleUrls: ['./team-warriors.component.scss']
})
export class TeamWarriors implements OnInit {

  user_name = "";
  user_pwd = "";

  constructor(private userFactory: UserFactory, private warriorFactory: WarriorFactory) {
    this.warriorFactory.GetAllWarriors().then((ret) => {
      console.log(ret);
    });
  }

  ngOnInit(): void {
  }

  public async CheckToken() {
  }

}
