import { Component, Input } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
@Component({
  selector: 'user-area',
  templateUrl: './user-area.component.html',
  styleUrls: ['./user-area.component.css']
})
export class UserAreaComponent {
  isSuppllier: boolean=false
  userString: any | undefined;
  user:any
  show:boolean=false
  // isSpecial:boolean=false
  constructor(private sanitizer: DomSanitizer){
   
  }
  ngOnInit(): void {
 
    // this.userId = Number(localStorage.getItem('id_user'));
    if (localStorage.getItem('supplier') == "true"){
      this.isSuppllier=true;
      this.userString = localStorage.getItem('user');
      this.user = JSON.parse(this.userString);
      

    }
 

  }
  get sanitizedUrl(): SafeResourceUrl {
    // console.log(this.supplier.email)
    const url = `https://calendar.google.com/calendar/embed?src=${this.user.email}&ctz=Asia%2FJerusalem`;
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }


}
