import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SupplierService } from '../../_services/supplier.service';

@Component({
  selector: 'app-sort-categories',
  templateUrl: './sort-categories.component.html',
  styleUrls: ['./sort-categories.component.css']
})
export class SortCategoriesComponent {
  sortedCategories: any[] = [];
  showComponent: boolean = false;
  c: any;
  objToSort: { category: number, location: number, priceFrom: number, priceUntil: number } = {
    category: 0,
    location: 0,
    priceFrom: 0,
    priceUntil: 0
  }
  objNamesCategory: { mainCategory: string, categoryN: string, locationN: string, priceFrom: number, priceUntil: number } = {
    mainCategory: '',
    categoryN: '',
    locationN: '',
    priceFrom: 0,
    priceUntil: 0
  }
  constructor(private route: ActivatedRoute, private ss: SupplierService) { }

  arrCategory: any[] = [];

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {

      this.objToSort = JSON.parse(params['objToSort']);
      this.objNamesCategory = JSON.parse(params['objNamesCategory'])

      console.log('זה האוביקט בsort category');
      console.log(this.objToSort.category, this.objToSort.location, this.objToSort.priceFrom);
      console.log(this.objNamesCategory);
      this.ss.sortSupplier(this.objToSort.category, this.objToSort.location, this.objToSort.priceFrom, this.objToSort.priceUntil).subscribe(result => {
        console.log(result);
        this.sortedCategories = result.data;
        console.log(' המהדהים אני המערך', this.sortedCategories)
      });
    });
  }

  toggleComponentVisibility(c: any) {
    this.showComponent = !this.showComponent;
    this.c = c;
  }
}


