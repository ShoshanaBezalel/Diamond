import { AbstractControl, ValidationErrors, FormGroup, ValidatorFn } from '@angular/forms';

export class PasswordValidators {
  static validate(control: AbstractControl): ValidationErrors | null {
    const password = control.get('password')?.value;
    const confirmPassword = control.get('confirmPassword')?.value;

    if (password !== confirmPassword) {
      console.log("passwords do not match");
      return { confirmPassword: true };
      
    }
    return null;
  }
}




