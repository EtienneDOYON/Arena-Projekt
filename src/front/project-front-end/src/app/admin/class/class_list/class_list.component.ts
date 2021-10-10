import { Component, OnInit } from '@angular/core';
import { ClassFactory } from '../../../factories/class.factory';

@Component({
  selector: 'app-home',
  templateUrl: './team-warriors.component.html',
  styleUrls: ['./team-warriors.component.scss']
})
export class ClassList implements OnInit {

  public classes: any;

  constructor(private classFactory: ClassFactory) {
    classFactory.GetAllClasses().then((classes) => {
      this.classes = classes;
    })
  }

  ngOnInit(): void {
  }

  public async CheckToken() {
  }

}
