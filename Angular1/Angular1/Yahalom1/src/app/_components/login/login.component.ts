import { Component, ViewChild } from '@angular/core';
import { AccountService } from '../../_services/account.service';
import { Router } from '@angular/router';
import { NavServiceService } from '../../_services/nav-service.service';


@Component({
  selector: 'login',
  templateUrl: 'login.component.html',
  styleUrls: ['login.component.scss']
})

export class LoginComponent {
 
  req: any = { Email: '', Password: '', Role: 0 }
  click = false;
  class = '';
  isShowDiv = true;
  role: string = ""

  constructor(public accountService: AccountService, private navService: NavServiceService, private router: Router) { }



  showDiv(): void {
    this.click = !this.click;
    this.isShowDiv = false;
    console.log('clicked');
  }
  login(): void {
    if (this.role == "1")
      this.req.Role = 1;
    else
      this.req.Role = 2;

    this.accountService.login(this.req).subscribe(
      (response: any) => {
        if (!response.IsError) {
          localStorage.setItem('user', JSON.stringify(response.data.user));
          localStorage.setItem('id_user', response.data.user.id);
          console.log(response);
          if (this.role == "1") localStorage.setItem('supplier', "true"); else localStorage.setItem('customer', "true");
          this.updateNavComponent();
          this.router.navigate(['/user-area'])
        }
      },
    );
  }

  updateNavComponent(): void {
    this.navService.updateNav();
  }

}



