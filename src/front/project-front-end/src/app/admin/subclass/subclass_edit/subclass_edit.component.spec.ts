import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubclassEdit } from './subclass_edit.component';

describe('HomeComponent', () => {
  let component: SubclassEdit;
  let fixture: ComponentFixture<SubclassEdit>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubclassEdit ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubclassEdit);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
