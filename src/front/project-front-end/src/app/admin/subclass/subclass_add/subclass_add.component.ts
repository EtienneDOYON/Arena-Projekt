import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClassFactory } from '../../../factories/class.factory';
import { SubclassFactory } from '../../../factories/subclass.factory';

@Component({
  selector: 'app-home',
  templateUrl: './subclass_add.component.html',
  styleUrls: ['./subclass_add.component.scss']
})
export class SubclassAdd implements OnInit {

  classes: any;
  subclass_name = "";
  subclassClassId = 0;

  constructor(private classFactory: ClassFactory, private subclassFactory: SubclassFactory, private route: Router) {
    classFactory.GetAllClasses().then((classes) => {
      this.classes = classes;
    })
  }

  ngOnInit(): void {
  }

  async SaveSubclass() {
    if (this.subclass_name == "")
      return;

    var ret = await this.subclassFactory.CreateSubclass({
      Id: 0,
      Name: this.subclass_name,
      Class_Id: this.subclassClassId
    });

    if (ret != null) {
      this.route.navigate(['/subclass_list']);
    }

    return;
  }

}
