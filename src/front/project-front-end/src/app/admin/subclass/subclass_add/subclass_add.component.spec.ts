import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SubclassAdd } from './subclass_add.component';

describe('HomeComponent', () => {
  let component: SubclassAdd;
  let fixture: ComponentFixture<SubclassAdd>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubclassAdd ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubclassAdd);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
