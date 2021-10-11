import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClassAdd } from './class_add.component';

describe('HomeComponent', () => {
  let component: ClassAdd;
  let fixture: ComponentFixture<ClassAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ClassAdd ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ClassAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
