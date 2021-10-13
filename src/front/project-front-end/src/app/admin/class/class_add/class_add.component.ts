import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClassFactory } from '../../../factories/class.factory';

@Component({
  selector: 'app-home',
  templateUrl: './class_add.component.html',
  styleUrls: ['./class_add.component.scss']
})
export class ClassAdd implements OnInit {

  classes: any;
  class_name = "";

  constructor(private classFactory: ClassFactory, private route: Router) {
    classFactory.GetAllClasses().then((classes) => {
      this.classes = classes;
    })
  }

  ngOnInit(): void {
  }

  async SaveClass() {
    if (this.class_name == "")
      return;

    var ret = await this.classFactory.CreateClass({
      Id: 0,
      Name: this.class_name
    });

    if (ret != null) {
      this.route.navigate(['/class_list']);
    }

    return;
  }

}
