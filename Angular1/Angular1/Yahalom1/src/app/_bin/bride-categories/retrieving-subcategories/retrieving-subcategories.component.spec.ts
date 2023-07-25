import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetrievingSubcategoriesComponent } from './retrieving-subcategories.component';

describe('RetrievingSubcategoriesComponent', () => {
  let component: RetrievingSubcategoriesComponent;
  let fixture: ComponentFixture<RetrievingSubcategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetrievingSubcategoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RetrievingSubcategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
