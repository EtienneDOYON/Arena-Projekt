import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { ClassFactory } from '../../../factories/class.factory';


@Component({
  selector: 'app-home',
  templateUrl: './class_edit.component.html',
  styleUrls: ['./class_edit.component.scss']
})
export class ClassEdit implements OnInit {

  _class = {name: ""};
  class_name = "";

  constructor(private classFactory: ClassFactory, private route: Router, private activatedRoute: ActivatedRoute) {
    this.activatedRoute.params.subscribe( params => {
      this.classFactory.GetClass(params.id).then((data) => {
        this._class = data;
      })
    });

  }

  ngOnInit(): void {
  }

  SaveClass() {
    this.classFactory.EditClass(this._class).then((ret) => {
      if (ret) {
        this.route.navigate(['/class_list']);
      }
    })
  }

}
