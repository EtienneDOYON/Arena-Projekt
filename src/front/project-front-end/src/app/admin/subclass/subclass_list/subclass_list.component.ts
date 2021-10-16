import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SubclassFactory } from 'src/app/factories/subclass.factory';
import { ClassFactory } from '../../../factories/class.factory';

@Component({
  selector: 'app-home',
  templateUrl: './subclass_list.component.html',
  styleUrls: ['./subclass_list.component.scss']
})
export class SubclassList implements OnInit {

  public classNames: Array<string> = new Array();
  public subclasses: any;
  public displayedColumns = ['name', 'className', 'edit-column'];

  constructor(private classFactory: ClassFactory, private subclassFactory: SubclassFactory, private route: Router) {
    classFactory.GetAllClasses().then((classes) => {
      for (var i = 0; i < classes.length; i++) {
        this.classNames[classes[i].id] = classes[i].name;
      }
    });

    subclassFactory.GetAllSubclasses().then((subclasses) => {
      this.subclasses = subclasses;
    })
  }

  ngOnInit(): void {
  }

  public async CreateNewSubclass() {
    // TODO : Check if user is admin
    this.route.navigate(['/subclass_add']);
  }

  public EditSubclass(_subclass: any) {
    // TODO : Check if user is admin
    this.route.navigate([`/subclass_edit/${_subclass.id}`]);
  }

  public DeleteSubclass(id: number) {
    // TODO : Check if user is admin
    this.subclassFactory.DeleteSubclass(id).then(() => {
      this.subclassFactory.GetAllSubclasses().then((subclasses) => {
        this.subclasses = subclasses;
      })
    });
  }

}
