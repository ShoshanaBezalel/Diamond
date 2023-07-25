import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetrievingCategoriesComponent } from './retrieving-categories.component';

describe('RetrievingCategoriesComponent', () => {
  let component: RetrievingCategoriesComponent;
  let fixture: ComponentFixture<RetrievingCategoriesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RetrievingCategoriesComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RetrievingCategoriesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
