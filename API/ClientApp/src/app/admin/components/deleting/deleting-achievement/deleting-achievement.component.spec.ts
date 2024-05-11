/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { DeletingAchievementComponent } from './deleting-achievement.component';

describe('DeletingAchievementComponent', () => {
  let component: DeletingAchievementComponent;
  let fixture: ComponentFixture<DeletingAchievementComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DeletingAchievementComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DeletingAchievementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
