// import { FormControl, FormGroup, Validators } from '@angular/forms';
// import { PasswordValidators } from './password.validator';
// import { HttpClient } from '@angular/common/http';
// import { Router } from '@angular/router';


// export class FormValidations {
//     form = new FormGroup({
//         firstName: new FormControl('', Validators.required),
//         lastName: new FormControl('', Validators.required),
//         password: new FormControl('', Validators.required),
//         confirmPassword: new FormControl('', [Validators.required, PasswordValidators.validate]),
//         phone: new FormControl('', Validators.required),
//         email: new FormControl('', Validators.required),
//         date: new FormControl('', Validators.required),
//         brideOrGroom: new FormControl('', Validators.required)
//       },
//     );

//     constructor(private http: HttpClient, private router: Router) { }


// get firstName() {
//     return this.form.get('firstName');
//   }

//   get lastName() {
//     return this.form.get('lastName');
//   }

//   get password() {
//     return this.form.get('password');
//   }

//   get confirmPassword() {
//     return this.form.get('confirmPassword');
//   }   

//   get phone() {
//     return this.form.get('phone');
//   }

//   get email() {
//     return this.form.get('email');
//   }

//   get date() {
//     return this.form.get('date');
//   }

//   get brideOrGroom() {
//     return this.form.get('brideOrGroom');
//   }

// }


