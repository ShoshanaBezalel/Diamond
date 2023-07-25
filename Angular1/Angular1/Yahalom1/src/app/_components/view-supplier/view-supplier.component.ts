import { Component, Input } from '@angular/core';
import { InvitationService } from '../../_services/invitation.service';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';

@Component({
  selector: 'app-view-supplier',
  templateUrl: './view-supplier.component.html',
  styleUrls: ['./view-supplier.component.css']
})
export class ViewSupplierComponent {
  invitationToCreate:any={}
  userId!: number;
  today: Date = new Date();
  constructor(private is:InvitationService,private sanitizer: DomSanitizer){
   
  }
  @Input()
  // supplier!: {idSuplier:0, firstName: ''; lastName: ''; aboutMe: ''; email: ''; phone: 0; };
  supplier: { idSuplier: number; firstName: string; lastName: string; aboutMe: string; email: string; phone: number; } = {
    idSuplier: 0,
    firstName: '',
    lastName: '',
    aboutMe: '',
    email: 'example@example.com',
    phone: 0
  };
  @Input()
  categoryName!:string;
  IsEditInvitation:boolean=false
  @Input()
  location!:string;

  get sanitizedUrl(): SafeResourceUrl {
    console.log(this.supplier.email)
    const url = `https://calendar.google.com/calendar/embed?src=${this.supplier.email}&ctz=Asia%2FJerusalem`;
    return this.sanitizer.bypassSecurityTrustResourceUrl(url);
  }
  submitForm() {
    console.log(this.supplier.idSuplier)
  this.userId = Number(localStorage.getItem('id_user'));
 this.invitationToCreate.location=this.location;
 this.invitationToCreate.idCustomer=this.userId;
 this.invitationToCreate.idSuplier=this.supplier.idSuplier;
//  this.invitationToCreate.dateOfInvitation= this.today
 console.log(this.invitationToCreate)
 this.is.CreateInvitationCustomer(this.invitationToCreate).subscribe(
  data=>{
    console.log(data)
  alert('ההזמנה הוספה בהצלחה!!'); 
  }
  )
}
}
