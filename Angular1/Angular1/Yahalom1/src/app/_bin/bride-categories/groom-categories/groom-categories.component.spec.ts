import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroomCategoriesComponent } from './groom-categories.component';

describe('GroomCategoriesComponent', () => {
  let component: GroomCategoriesComponent;
  let fixture: ComponentFixture<GroomCategoriesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [GroomCategoriesComponent]
    });
    fixture = TestBed.createComponent(GroomCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
