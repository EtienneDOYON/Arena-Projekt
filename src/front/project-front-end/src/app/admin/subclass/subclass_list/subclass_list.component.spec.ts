import { ComponentFixture, TestBed } from '@angular/core/testing';
import { SubclassList } from './subclass_list.component';


describe('HomeComponent', () => {
  let component: SubclassList;
  let fixture: ComponentFixture<SubclassList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SubclassList ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SubclassList);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
