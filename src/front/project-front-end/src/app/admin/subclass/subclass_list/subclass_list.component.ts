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

  public classes: any;
  public subclasses: any;
  public displayedColumns = ['name', 'className', 'edit-column'];

  constructor(private classFactory: ClassFactory, private subclassFactory: SubclassFactory, private route: Router) {
    classFactory.GetAllClasses().then((classes) => {
      this.classes = classes;
    });
    subclassFactory.GetAllSubclasses().then((subclasses) => {
      this.subclasses = subclasses;
    })
  }

  ngOnInit(): void {
  }

  public async CreateNewClass() {
    // TODO : Check if user is admin
    this.route.navigate(['/subclass_add']);
  }

  public EditClass(_class: any) {
    // TODO : Check if user is admin
    console.log(_class.id);
    this.route.navigate([`/subclass_edit/${_class.id}`]);
  }

  public DeleteClass(id: number) {
    // TODO : Check if user is admin
    this.classFactory.DeleteClass(id).then(() => {
      this.classFactory.GetAllClasses().then((classes) => {
        this.classes = classes;
      });
    });
  }

}
