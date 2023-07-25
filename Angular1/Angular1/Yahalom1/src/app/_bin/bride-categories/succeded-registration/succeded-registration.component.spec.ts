import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SuccededRegistrationComponent } from './succeded-registration.component';

describe('SuccededRegistrationComponent', () => {
  let component: SuccededRegistrationComponent;
  let fixture: ComponentFixture<SuccededRegistrationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SuccededRegistrationComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SuccededRegistrationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
