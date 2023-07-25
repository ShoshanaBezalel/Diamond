import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';


@Component({
  selector: 'registration-form',
  templateUrl: './registration-form.component.html',
  styleUrls: ['./registration-form.component.css'],
})

export class RegistrationFormComponent implements OnInit {
  ngOnInit(): void {
  }
  darkForm: FormGroup;

  constructor(private accountService: AccountService, private http: HttpClient, private router: Router, private formBuilder: FormBuilder, public fb: FormBuilder) {

    this.darkForm = fb.group({
      darkFormEmailEx: ['', [Validators.required, Validators.email]],
      darkFormPasswordEx: ['', Validators.required],
    });
  }

  model: any = {
    isGroom: false,
    DateOfWedding: new Date(),
    firstName: "",
    lastName: "",
    password: "",
    phone: 0,
    email: ""
  };

  passwordMismatch: boolean = false;

  form = new FormGroup({
    firstName: new FormControl('', Validators.required),
    lastName: new FormControl('', Validators.required),
    password: new FormControl('', Validators.required),
    confirmPassword: new FormControl('', Validators.required),
    phone: new FormControl('', Validators.required),
    email: new FormControl('', Validators.required),
    dateOfWedding: new FormControl('', Validators.required),
    isGroom: new FormControl('', Validators.required),
  },
  );

  validatePasswords() {
    this.passwordMismatch = this.model.password != this.model.confirmPassword;
    console.log('passwords do not match', this.passwordMismatch);
  }

  register() {
    this.accountService.registerCustomer(this.model).subscribe(

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
  get firstName() { return this.form.get('firstName'); }

  get lastName() { return this.form.get('lastName'); }

  get password() { return this.form.get('password'); }

  get confirmPassword() { return this.form.get('confirmPassword'); }

  get phone() { return this.form.get('phone'); }

  get email() { return this.form.get('email'); }

  get date() { return this.form.get('date'); }

  get brideOrGroom() { return this.form.get('brideOrGroom'); }


}
