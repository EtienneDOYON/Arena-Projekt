import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeamWarriors } from './team-warriors.component';

describe('HomeComponent', () => {
  let component: TeamWarriors;
  let fixture: ComponentFixture<TeamWarriors>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeamWarriors ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TeamWarriors);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
