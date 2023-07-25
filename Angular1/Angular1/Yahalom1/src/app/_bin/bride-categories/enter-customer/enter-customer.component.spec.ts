import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterCustomerComponent } from './enter-customer.component';

describe('EnterCustomerComponent', () => {
  let component: EnterCustomerComponent;
  let fixture: ComponentFixture<EnterCustomerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnterCustomerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnterCustomerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
