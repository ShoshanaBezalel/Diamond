import { Component } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { SupplierService } from '../../_services/supplier.service';

@Component({
  selector: 'supplier-registration',
  templateUrl: './supplier-registration.component.html',
  styleUrls: ['./supplier-registration.component.css']
})
export class SupplierRegistrationComponent {
  arrSecondCategory:any[]=[]
  model: any = {
    idCategory:0,
    idPlace:0,
    aboutMe:"",
    priceFrom:0,
    priceUntill:0,
    firstName:"",
    lastName:"",
    password:"",
    phone:0,
    email:""
  };

  passwordMismatch: boolean = false;

  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    idCategory: new FormControl('', Validators.required),
    idPlace: new FormControl('', Validators.required),
    aboutMe: new FormControl('', Validators.required),
    priceFrom: new FormControl('', Validators.required),
    priceUntill: new FormControl('', Validators.required),
  },
);

  constructor(private accountService: AccountService, private http: HttpClient, private router: Router, private formBuilder: FormBuilder,private s:SupplierService ) { }

  validatePasswords() {
    this.passwordMismatch = this.model.password != this.model.confirmPassword;
    console.log('passwords do not match', this.passwordMismatch);
  }

  register() {
    this.accountService.registerS(this.model).subscribe(
   
      {
      next: () => {
        console.log(this.model),
       
        this.router.navigate(['/user-area'])
      },
      error: error => console.log(error)
    })
  }

  // Alert after register
  successNotification() {
    Swal.fire(this.model.firstName + " " + this.model.lastName, '!ההרשמה בוצעה בהצלחה', 'success');
  }
  getSecondCategory(idCategory:number){
    // this.objNamesCategory.mainCategory=item.category;
    
     this.s.getSecondCtegory(idCategory).subscribe(
       data=>{
         if(!data.isError){
          //  this.isSEcond=true;
         console.log(data.data)
         this.arrSecondCategory=data.data;
       }
    }
     )
   }

  get firstName() { return this.form.get('firstName');}

  get lastName() { return this.form.get('lastName');}

  get password() { return this.form.get('password');}

  get confirmPassword() { return this.form.get('confirmPassword');}   

  get phone() { return this.form.get('phone');}

  get email() { return this.form.get('email');}

  get idCategory() { return this.form.get('businessLine');}

  get idPlace() { return this.form.get('place');}

  get priceFrom() { return this.form.get('freeform');}

}



