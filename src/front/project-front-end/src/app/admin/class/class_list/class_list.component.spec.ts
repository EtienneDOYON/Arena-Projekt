import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassList } from './class_list.component';

describe('HomeComponent', () => {
  let component: ClassList;
  let fixture: ComponentFixture<ClassList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassList ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
