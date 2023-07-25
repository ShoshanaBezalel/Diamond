import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { PasswordValidators } from './password.validators';
import { HttpClient } from '@angular/common/http';
import { CustomerRegistrationService } from './customer-registration.service';
import {Router} from '@angular/router';
// import {ModalOfNgb, ModalOfDismissReasons} from '@ng-bootstrap/ng-bootstrap';  

@Component({
  selector: 'customer-registration',
  templateUrl: './customer-registration.component.html',
  styleUrls: ['./customer-registration.component.css'],
})

export class CustomerRegistrationComponent {
  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', [Validators.required, PasswordValidators.validate]),
    phone: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    date: new FormControl('', Validators.required),
    brideOrGroom: new FormControl('', Validators.required)
  },
  // { validator: PasswordValidators.validate}
    );
  // modalService: any;
  // closeResult: string | undefined;

  constructor(private http: HttpClient, private router: Router) { }
    // onSubmit() {
    //   // Make a POST request to the C# API endpoint
    //   this.http.post('https://jsonplaceholder.typicode.com/users', this.form)
    //     .subscribe(
    //       response => {
    //         console.log('Form submitted successfully');
    //         // Handle the response from the C# API
    //       },
    //       error => {
    //         console.error('An error occurred:', error);
    //         // Handle any error that occurred
    //       }
    //     );
        
    //     this.router.navigate(['/user-area']);
    // }

    onSubmit() {
      
    }

  ngOnInit() {
    this.form.setValidators(PasswordValidators.validate);
  }


  // open(content: any) {  
  //   this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'}).result.then((result: any) => {  
  //     this.closeResult = `Closed with: ${result}`;  
  //   }, (reason: any) => {  
  //     this.closeResult = `Dismissed ${this.getDismissReason(reason)}`;  
  //   });  
  // }  

  // private getDismissReason(reason: any): string {
  //   if(reason === ModalOfDismissReasons.ESC) {
  //     return 'by pressing ESC';
  //   }
  //   else if (reason === ModalOfDismissReasons.BACKDROP_CLICK) {
  //     return 'by clicking in a backdrop';
  //   } else {
  //     return `with: ${reason}`;
  //   }
  // }
    // alert({this.firstName}, {this.lastName} + "נרשם בהצלחה!")
  

  get firstName() {
    return this.form.get('firstName');
  }

  get lastName() {
    return this.form.get('lastName');
  }

  get password() {
    return this.form.get('password');
  }

  get confirmPassword() {
    return this.form.get('confirmPassword');
  }   

  get phone() {
    return this.form.get('phone');
  }

  get email() {
    return this.form.get('email');
  }

  get date() {
    return this.form.get('date');
  }

  get brideOrGroom() {
    return this.form.get('brideOrGroom');
  }

}