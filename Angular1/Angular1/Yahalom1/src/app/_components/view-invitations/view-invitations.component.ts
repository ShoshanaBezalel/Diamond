import { Component, Input, OnInit } from '@angular/core';
import { InvitationService } from '../../_services/invitation.service';
import { InvitationDTO } from '../../_services/InvitationDTO'
import { ActivatedRoute } from '@angular/router';
import Swal from 'sweetalert2';
import { FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-view-invitations',
  templateUrl: './view-invitations.component.html',
  styleUrls: ['./view-invitations.component.css']
})
export class ViewInvitationsComponent implements OnInit {
  
  objInvitation:{}={}
  showForm=false
  showcontactSupplier=false
  contactSupplier:string=''
  customerDetails:any=null
 
  invitationToShow:any
  userId!: number;
  invitations: any[] = [];
  isShowDetiles:boolean=false;
  constructor(private invitationService: InvitationService, private route: ActivatedRoute,private formBuilder: FormBuilder) { }
  isSupplier: boolean = false;
  @Input()showOptions:boolean=true

  ngOnInit(): void {
   this.userId = Number(localStorage.getItem('id_user'));
    if(!this.showOptions) this.getInvitations(1);

    if (localStorage.getItem('supplier') == "true"){
      console.log('sup')
      this.isSupplier = true;}
    else {
      this.isSupplier = false;
      this.invitationService.getInvitation_to_Customer(this.userId).subscribe(
        data => {
          console.log(data)
          this.invitations=data.data
        }
      )}}

  getInvitations(status: number) {
    this.showOptions=false;
    this.invitationService.getSupplierInvitations(this.userId, status).subscribe(
      (data) => {
        if (!data.isError) {
          console.log(data)
          this.invitations = data.data;
        }

      },

    );
  }
  showDetiles(invitation:any,index:number){
    this.isShowDetiles=!this.isShowDetiles;
    this.invitationToShow=invitation
    this.invitations[index].isExpanded = !this.invitations[index].isExpanded;
   
  }
  
  getCustomerDetails(id:number): void {
    this.invitationService.getCustomerDetails(id).subscribe(
      data=>{
        console.log(data)
         this.customerDetails= data.data;
         this.openPopap(this.customerDetails)
      }
    )
      
  }
  UpdateIsPaid(id:number){
    this.invitationService.UpdateIsPaid(id).subscribe(
      data=>{
        if(!data.isError)
        {
          console.log(data)
          Swal.fire( 'עדכון התשלום בוצע בהצלחה');
        }}
    )
  }
  addInvitation(){

  }
  ContactUs(id:number){
    this.invitationService.ContactUs(id).subscribe(
      data=>{
        this.contactSupplier=data.data
        Swal.fire({
          html: `
          <svg xmlns="http://www.w3.org/2000/svg"
          width="20" height="20" fill="currentColor" class="bi bi-telephone-fill" viewBox="0 0 16 16">
          <path fill-rule="evenodd"
            d="M1.885.511a1.745 1.745 0 0 1 2.61.163L6.29 2.98c.329.423.445.974.315 1.494l-.547 2.19a.678.678 0 0 0 .178.643l2.457 2.457a.678.678 0 0 0 .644.178l2.189-.547a1.745 1.745 0 0 1 1.494.315l2.306 1.794c.829.645.905 1.87.163 2.611l-1.034 1.034c-.74.74-1.846 1.065-2.877.702a18.634 18.634 0 0 1-7.01-4.42 18.634 18.634 0 0 1-4.42-7.009c-.362-1.03-.037-2.137.703-2.877L1.885.511z" />
        </svg>
        <br>
        <h1>פרטי הספק</h1>
        <h2>${this.contactSupplier}</h2>
          `
        });
      }

    )
    
  }
  openPopap(customerDetails:any){
   
    Swal.fire({
      html: `
        <div style="font-family: Arial, sans-serif;">
          <h3 style="text-align: center;">פרטי לקוח</h3>
          <hr style="border-color: #ccc;">
          <ul style="list-style: none; padding: 0;">
            <li style="margin-bottom: 12px;"><span style="font-weight: bold;">שם:</span> ${customerDetails.firstName}</li>
            <li style="margin-bottom: 12px;"><span style="font-weight: bold;">משפחה:</span> ${customerDetails.lastName}</li>
            <li style="margin-bottom: 12px;"><span style="font-weight: bold;">תאריך החתונה:</span> ${customerDetails.dateOfWedding}</li>
            <li style="margin-bottom: 12px;"><span style="font-weight: bold;">טלפון:</span> ${customerDetails.phone}</li>
            <li style="margin-bottom: 12px;"><span style="font-weight: bold;">אימייל:</span> ${customerDetails.email}</li>
          </ul>
        </div>
      `
    });
  }

}


