import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HardDrivesComponent } from './hard-drives.component';

describe('HardDrivesComponent', () => {
  let component: HardDrivesComponent;
  let fixture: ComponentFixture<HardDrivesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HardDrivesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HardDrivesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
