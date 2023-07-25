import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EnterSupplierComponent } from './enter-supplier.component';

describe('EnterSupplierComponent', () => {
  let component: EnterSupplierComponent;
  let fixture: ComponentFixture<EnterSupplierComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EnterSupplierComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EnterSupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
