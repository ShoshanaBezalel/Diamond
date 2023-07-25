import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { UserServiceService } from '../../_services/user-service.service';
import { Router } from '@angular/router';
import { SupplierService } from '../../_services/supplier.service';

@Component({
  selector: 'user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css']
})
export class UserProfileComponent implements OnInit {
 
  customerForm: FormGroup;
  supplierForm: FormGroup;
  userString: any | undefined;
  user: any = {};
  supplier: any = {};
  customer: any = {};
  isSuppllier!: boolean;
  userId!: number;
  groomOrBride: string = ''
  arrCategory: any[] = [];
  arrSecondCategory: any[] = [];
  constructor(private formBuilder: FormBuilder, private userService: UserServiceService, private router: Router, private s: SupplierService) {
    this.customerForm = this.formBuilder.group({});
    this.supplierForm = this.formBuilder.group({});
  }
  ngOnInit(): void {
   
    this.userString = localStorage.getItem('user');
    this.user = JSON.parse(this.userString);
    this.userId = Number(localStorage.getItem('id_user'));
    if (localStorage.getItem('supplier') == "true") {
      this.isSuppllier = true;
      this.getSupplierCategory()
    }


  }
  updateProfile() {
    if (!this.isSuppllier) {
      this.userService.updateProfileCustomer(this.user).subscribe(
        {
          next: () => {
            this.router.navigate(['/user-area'])
          }

        })

    }
    else {
      this.userService.UpdateSupplier(this.user).subscribe(
        {
          next: () => {
            this.router.navigate(['/user-area'])
          }

        })

    }
  }




  getSupplierCategory() {
    this.s.getSupplierCategory().subscribe(
      data => {
        console.log(data.data)
        this.arrCategory = data.data;
      }
    )
  }
  getSecondCategory(idCategory: number) {
    this.s.getSecondCtegory(idCategory).subscribe(
      data => {
        if (!data.isError) {
          console.log(data.data)
          this.arrSecondCategory = data.data;
        }
      }
    )
  }

}
