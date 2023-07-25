import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserAreaSupplierComponent } from './user-area-supplier.component';

describe('UserAreaSupplierComponent', () => {
  let component: UserAreaSupplierComponent;
  let fixture: ComponentFixture<UserAreaSupplierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserAreaSupplierComponent]
    });
    fixture = TestBed.createComponent(UserAreaSupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
