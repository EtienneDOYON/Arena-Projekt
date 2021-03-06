import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ClassFactory } from '../../../factories/class.factory';

@Component({
  selector: 'app-home',
  templateUrl: './class_list.component.html',
  styleUrls: ['./class_list.component.scss']
})
export class ClassList implements OnInit {

  public classes: any;
  public displayedColumns = ['name', 'edit-column'];

  constructor(private classFactory: ClassFactory, private route: Router) {
    classFactory.GetAllClasses().then((classes) => {
      this.classes = classes;
    })
  }

  ngOnInit(): void {
  }

  public async CreateNewClass() {
    // TODO : Check if user is admin
    this.route.navigate(['/class_add']);
  }

  public EditClass(_class: any) {
    // TODO : Check if user is admin
    console.log(_class.id);
    this.route.navigate([`/class_edit/${_class.id}`]);
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
