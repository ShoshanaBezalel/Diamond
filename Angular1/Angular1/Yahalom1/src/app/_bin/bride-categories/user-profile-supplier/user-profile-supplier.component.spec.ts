import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserProfileSupplierComponent } from './user-profile-supplier.component';

describe('UserProfileSupplierComponent', () => {
  let component: UserProfileSupplierComponent;
  let fixture: ComponentFixture<UserProfileSupplierComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [UserProfileSupplierComponent]
    });
    fixture = TestBed.createComponent(UserProfileSupplierComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
