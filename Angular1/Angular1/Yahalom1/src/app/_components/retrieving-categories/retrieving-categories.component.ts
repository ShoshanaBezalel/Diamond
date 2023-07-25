import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { SupplierService } from '../../_services/supplier.service';

@Component({
  selector: 'app-retrieving-categories',
  templateUrl: './retrieving-categories.component.html',
  styleUrls: ['./retrieving-categories.component.css']
})
export class RetrievingCategoriesComponent {

  objToSortStr: string = '';
  objNamesCategoryStr: any;
  userString: any;
  user: any;
  elementRef: any = ''
  
  constructor(private router: Router, private s: SupplierService) {

  }

  arrCategory: any[] = []
  arrSecondCategory: any[] = []
  arrLocation: any[5] = [{ id: 1, place: "ירושלים והסביבה" }, { id: 2, place: "מרכז" }, { id: 3, place: "צפון" }, { id: 4, place: "דרום" }, { id: 5, place: "כל האזורים" }]
  priceFrom: number = 0;
  priceUntil: number = 0
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

  isShowDiv = false;
  isSEcond: boolean = false;

  ngOnInit() {
    this.userString = localStorage.getItem('user');
    this.user = JSON.parse(this.userString);
    this.s.getSupplierCategory().subscribe(
      data => {
        console.log(data.data)
        this.arrCategory = data.data;
      }
    )
  }

  getSecondCtegory(item: any) {
    this.objNamesCategory.mainCategory = item.category;

    this.s.getSecondCtegory(item.idCategory).subscribe(
      data => {
        if (!data.isError) {
          this.isSEcond = true;
          console.log(data.data)
          this.arrSecondCategory = data.data;
        }
        else console.log('ssssssssssssssssssssss')
      }
    )
  }

  getCategory(c: any) {
    this.objToSort.category = c.id_Second_Ctegory
    this.objNamesCategory.categoryN = c.description_Second_Ctegory

  }
  // לשנות בהתאם לתשובה של הסרבר..
  getLocation(c: any) {
    this.objToSort.location = c.id
    this.objNamesCategory.locationN = c.place//לשנות..
  }

  search(){
    this.objToSort.priceFrom = this.priceFrom;
    this.objToSort.priceUntil = this.priceUntil;
    this.objNamesCategory.priceFrom = this.priceFrom;
    this.objNamesCategory.priceUntil = this.priceUntil;
    this.objToSortStr = JSON.stringify(this.objToSort);
    this.objNamesCategoryStr = JSON.stringify(this.objNamesCategory);

    console.log(this.objToSort)
    console.log(this.objNamesCategory)
    this.router.navigate(['/sort-categories'], {
      queryParams: {
        objToSort: this.objToSortStr,
        objNamesCategory: this.objNamesCategoryStr
      }
    });
  }
}
