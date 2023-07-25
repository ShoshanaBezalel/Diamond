import { Component, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { AccountService } from '../../_services/account.service';
import { Subscription } from 'rxjs';
import { NavServiceService } from '../../_services/nav-service.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit, OnDestroy {
  currentHour: number ;
  isMenuView: boolean = false
  userString: any | undefined;
  private navUpdateSubscription!: Subscription;
  userName: any;
  role: any;
  date: any = new Date();
  today = new Date();
  timeDiff = this.date.getTime() - this.today.getTime();

  isShowDate:boolean=false
  selectedDate!: string;
  daysDiff: number | null = null;
  constructor(private navService: NavServiceService, private router: Router, private accountService: AccountService) { 
    this.currentHour = new Date().getHours();
  }
  ngOnInit() {
    this.navUpdateSubscription = this.navService.updateNav$.subscribe(() => {
      this.updateNavComponent();
    });
    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd && event.urlAfterRedirects === '/login') {
        this.router.navigate([event.urlAfterRedirects]);
      }
    });
  }
  ngOnDestroy() {
    this.navUpdateSubscription.unsubscribe();
  }
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }
  updateNavComponent(): void {
    if (localStorage.getItem('user') == '')
      this.isMenuView = false
    else this.isMenuView = true
    this.userString = localStorage.getItem('user');
    const user = JSON.parse(this.userString);
    this.userName = user.firstName;

    if (localStorage.getItem('supplier') == "true")
      this.role = 1;
    else {this.role = 2;
      this.navService.getDateOfWedding(user.id).subscribe(
        data=>{
          if(data.data!=null){
            this.selectedDate=data.data
            this.isShowDate=true
            this.calculateDays();
          }
        }
      )
    }

  }
  show: boolean = false
  getGreetingTime(): string {
    if (this.currentHour >= 5 && this.currentHour < 12) {
      return '!בוקר טוב';
    } else if (this.currentHour >= 12 && this.currentHour < 17) {
      return '!צהריים טובים';
    } else if (this.currentHour >= 17 && this.currentHour < 21) {
      return '!ערב טוב';
    } else {
      return '!לילה טוב';
    }
  }

  calculateDays() {
    // Get today's date
    const today = new Date();

    // Parse the given date
    const givenDate = new Date(this.selectedDate);

    // Calculate the time difference in milliseconds
    const timeDiff = givenDate.getTime() - today.getTime();

    // Convert the time difference to days
    this.daysDiff = Math.ceil(timeDiff / (1000 * 3600 * 24));
  }

  
}
