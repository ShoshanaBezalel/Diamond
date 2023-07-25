import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BrideCategoriesComponent } from './bride-categories.component';

describe('BrideCategoriesComponent', () => {
  let component: BrideCategoriesComponent;
  let fixture: ComponentFixture<BrideCategoriesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [BrideCategoriesComponent]
    });
    fixture = TestBed.createComponent(BrideCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
