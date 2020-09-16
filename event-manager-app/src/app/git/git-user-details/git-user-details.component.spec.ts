import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GitUserDetailsComponent } from './git-user-details.component';

describe('GitUserDetailsComponent', () => {
  let component: GitUserDetailsComponent;
  let fixture: ComponentFixture<GitUserDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GitUserDetailsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GitUserDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
