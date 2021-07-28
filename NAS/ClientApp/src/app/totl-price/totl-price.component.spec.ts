import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TotlPriceComponent } from './totl-price.component';

describe('TotlPriceComponent', () => {
  let component: TotlPriceComponent;
  let fixture: ComponentFixture<TotlPriceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TotlPriceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TotlPriceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
