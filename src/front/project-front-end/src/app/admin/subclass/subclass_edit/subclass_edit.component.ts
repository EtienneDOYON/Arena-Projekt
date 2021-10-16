import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { SubclassFactory } from 'src/app/factories/subclass.factory';
import { ClassFactory } from '../../../factories/class.factory';


@Component({
  selector: 'app-home',
  templateUrl: './subclass_edit.component.html',
  styleUrls: ['./subclass_edit.component.scss']
})
export class SubclassEdit implements OnInit {

  _subclass = {name: "", class_Id: 0};
  classes: any;

  constructor(private classFactory: ClassFactory, private route: Router, private activatedRoute: ActivatedRoute, private subclassFactory: SubclassFactory) {
    this.activatedRoute.params.subscribe( params => {
      this.subclassFactory.GetSubclass(params.id).then((data) => {
        this._subclass = data;
      })
    });

    this.classFactory.GetAllClasses().then((classes) => {
      this.classes = classes;
    })

  }

  ngOnInit(): void {
  }

  SaveSubclass() {
    this.subclassFactory.EditSubclass(this._subclass).then((ret) => {
      if (ret) {
        this.route.navigate(['/subclass_list']);
      }
    })
  }

}
