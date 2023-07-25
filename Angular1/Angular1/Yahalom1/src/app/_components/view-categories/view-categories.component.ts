import { Component } from '@angular/core';
import { ActivatedRoute,  } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-view-categories',
  templateUrl: './view-categories.component.html',
  styleUrls: ['./view-categories.component.css']
})
export class ViewCategoriesComponent {
  searchObj: any;
  constructor(private route: ActivatedRoute,private r:Router) {}
  
  myArray:any[]=[]
  Halls: any[] = [{name:"גני ארועים עד 250 איש",id:1},{ name:"גני ארועים מעל 250 איש",id:7},{id:8,name:"אולמות ארועים עד 250 איש"},{name:"אולמות ארועים מעל 250 איש", id:9}];
  orchestra:any[]=[{name:"זמר",id:10},{name:"כלים",id:11},{name:"תזמורת משולבת-זמר וכילים",id:12}];
  orchestra_dishes:any[]=[{name:"חצוצרה"},{name:"קלרינט", id:9},{name:"חליל",id:10},"תופים","גיטרה","כינור"]
  Video_shooting:any[]=[{name:"צלם",id:13},{name:"צלמת",id:14},{name:"מסריט",id:15},{name:"מסריטה",id:16},{name:"חבילה כוללת",id:17}];
  Wedding_organization:any[]=[{name:"ארגון חתונה",id:18},{name:"עיצוב ארועים",id:19},{name:"תכשיטים לכלה",id:20},{name:"מתנות מעוצבות",id:21},{name:"הסעות לחתונה",id:22},{name:"השכרת רכבים",id:23}];
  category=''
  location:any[]=[{name:"ירושלים והסביבה",id:1},{name:"מרכז",id:2},{name:"צפון",id:3},{name:"דרום",id:4}];
  clicked_d:boolean=false
  item=''
  ObjCategory={Id_Categoty:undefined,Place_Id:undefined,Price_from:undefined,Price_Until:undefined}
  selectedCategory: { name: string, id: number } = { name: '', id: 0};
  selectedLocation: { name: string, id: number } = { name: '', id: 0};
  priceFrom: number =0;
  priceUntil: number=0


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
f(){
  this.r.navigate(['/sort-categories'], { queryParams: { category: this.ObjCategory } });
}





search() {
  const queryParams = {
  };
  console.log(queryParams); 
  this.r.navigate(['/sort-categories'], {
    queryParams: {
      category: JSON.stringify(this.selectedCategory),
      location: JSON.stringify(this.selectedLocation),
      priceFrom: this.priceFrom.toString(),
      priceUntil: this.priceUntil.toString()
    }
  });
}
}