import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassEdit } from './class_edit.component';

describe('HomeComponent', () => {
  let component: ClassEdit;
  let fixture: ComponentFixture<ClassEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassEdit ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassEdit);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
