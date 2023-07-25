import { Component } from '@angular/core';
import { SupplierService } from '../../../_services/supplier.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-retrieving-subcategories',
  templateUrl: './retrieving-subcategories.component.html',
  styleUrls: ['./retrieving-subcategories.component.css']
})
export class RetrievingSubcategoriesComponent {
  selectedCategory: any;
  suppliers: any[] | undefined;
  categories: any;

  myArray:any[]=[]
  Halls: any[] = [{name:"גני ארועים עד 250 איש",id:1},{ name:"גני ארועים מעל 250 איש",id:2},{id:3,name:"אולמות ארועים עד 250 איש"},{name:"אולמות ארועים מעל 250 איש", id:4} ,];
  orchestra:any[]=[{name:"זמר",id:5},{name:"כלים",id:6},{name:"תזמורת משולבת-זמר וכילים",id:7}];
  orchestra_dishes:any[]=["חצוצרה","קלרינט","חליל","תופים","גיטרה","כינור"]
  Video_shooting:any[]=["צלם","צלמת","מסריט","מסריטה","חבילה כוללת"];
  Wedding_organization:any[]=["ארגון חתונה","עיצוב ארועים","תכשיטים לכלה","מתנות מעוצבות","הסעות לחתונה","השכרת רכבים"];
  category=''
  location:string[]=["ירושלים והסביבה","מרכז","צפון","דרום"];


  constructor(private supplierService: SupplierService,private route: ActivatedRoute) { }
 
  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.category = params['category'];
      if(this.category=="Halls")
      this.myArray=this.Halls;
      else if(this.category=="orchestra"){

        this.myArray=this.orchestra;

      }
      else if(this.category=="Video_shooting")
      this.myArray=this.Video_shooting;
      else this.myArray=this.Wedding_organization;
    });
  }
  // submitForm() {
  //   this.supplierService.sortSupplier(this.selectedCategory)
  //     .subscribe(
  //       result => {
  //         this.suppliers = result;
  //       },
  //       error => {
  //         console.error('Error fetching suppliers:', error);
  //       }
  //     );
  // }
}

