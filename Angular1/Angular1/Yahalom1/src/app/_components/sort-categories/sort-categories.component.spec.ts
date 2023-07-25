import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SortCategoriesComponent } from './sort-categories.component';

describe('SortCategoriesComponent', () => {
  let component: SortCategoriesComponent;
  let fixture: ComponentFixture<SortCategoriesComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [SortCategoriesComponent]
    });
    fixture = TestBed.createComponent(SortCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
