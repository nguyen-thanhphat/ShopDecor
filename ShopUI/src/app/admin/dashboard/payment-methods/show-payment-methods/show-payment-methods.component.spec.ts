import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowPaymentMethodsComponent } from './show-payment-methods.component';

describe('ShowPaymentMethodsComponent', () => {
  let component: ShowPaymentMethodsComponent;
  let fixture: ComponentFixture<ShowPaymentMethodsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShowPaymentMethodsComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowPaymentMethodsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
